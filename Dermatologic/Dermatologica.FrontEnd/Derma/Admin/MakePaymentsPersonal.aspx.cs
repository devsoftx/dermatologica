using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_MakePaymentsPersonal : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetPayment();
            LoadPersonType();
        }
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }

    private void SetPayment()
    {
        if (CreationDate != null) txtDatePayment.Text = CreationDate.Value.ToShortDateString();
        var response = BussinessFactory.GetExchangeRateService().GetAll(p => p.DateRate.ToShortDateString().Equals(DateTime.Now.ToShortDateString()));
        if (response.OperationResult == OperationResult.Success)
        {
            var list = response.Results;
            var echangeToday = list.OrderBy(p => p.CreationDate).FirstOrDefault();
            if (echangeToday != null)
            {
                txtCompra.Text = echangeToday.Buy.ToString();
                txtVenta.Text = echangeToday.Sale.ToString();
                txtName.Text = "Pago de Honorarios";
            }
        }
    }

    private void LoadPersonType()
    {
        var response = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<PersonType>.BindDropDownList(ddlPersonType, types);
        }
    }

    private void SearchMedicalcaresByPerson()
    {
        if (!string.IsNullOrEmpty(ucSearchPersonsMedical.SelectedValue))
        {
            var example = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
            MedicalCareResponse response;
            switch (ddlMedicalCareType.SelectedValue)
            {
                case "Normales":
                    response = BussinessFactory.GetMedicalCareService().GetMedicalCaresByPerson(example.Entity);
                    if (response.OperationResult == OperationResult.Success)
                    {
                        gvMedicalCares.DataSource = response.MedicalCares.OrderBy(p => p.Session.RowId).ToList();
                        gvMedicalCares.DataBind();
                        var MedicalCareUSD = response.MedicalCares.Where(p => p.Rate.Currency == "USD" & p.Session.IsPaid);
                        var MedicalCarePEN = response.MedicalCares.Where(p => p.Rate.Currency == "PEN" & p.Session.IsPaid);

                        txtPayUSD.Text = MedicalCareUSD.Sum(p => p.Rate.UnitCost).ToString();
                        txtPayPEN.Text = MedicalCarePEN.Sum(p => p.Rate.UnitCost).ToString();
                    }
                    break;
                case "Por Partner":
                    response = BussinessFactory.GetMedicalCareService().GetTitularidadByPerson(example.Entity);
                    if (response.OperationResult == OperationResult.Success)
                    {
                        gvMedicalCares.DataSource = response.MedicalCares.OrderBy(p => p.Session.RowId).ToList();
                        gvMedicalCares.DataBind();
                        var MedicalCareUSD = response.MedicalCares.Where(p => p.Rate.Currency == "USD" & p.Session.IsPaid);
                        var MedicalCarePEN = response.MedicalCares.Where(p => p.Rate.Currency == "PEN" & p.Session.IsPaid);
                        txtPayUSD.Text = MedicalCareUSD.Sum(p => p.Rate.UnitCostPartner).ToString();
                        txtPayPEN.Text = MedicalCarePEN.Sum(p => p.Rate.UnitCostPartner).ToString();
                    }
                    break;
                case "Por Reemplazo":
                    response = BussinessFactory.GetMedicalCareService().GetReemplazosByPerson(example.Entity);
                    if (response.OperationResult == OperationResult.Success)
                    {
                        gvMedicalCares.DataSource = response.MedicalCares.OrderBy(p => p.Session.RowId).ToList();
                        gvMedicalCares.DataBind();
                        var MedicalCareUSD =
                            response.MedicalCares.Where(p => p.Rate.Currency == "USD" & p.Session.IsPaid);
                        var MedicalCarePEN =
                            response.MedicalCares.Where(p => p.Rate.Currency == "PEN" & p.Session.IsPaid);
                        txtPayUSD.Text = MedicalCareUSD.Sum(p => p.Rate.UnitCost).ToString();
                        txtPayPEN.Text = MedicalCarePEN.Sum(p => p.Rate.UnitCost).ToString();
                    }
                    break;
            }


        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchMedicalcaresByPerson();
    }

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }

    private void Save()
    {
        var medical = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue)).Entity;
        var StaffInformation = BussinessFactory.GetStaffInformationService().Get(new Guid(ucSearchPersonsMedical.SelectedValue)).Entity;
        foreach (GridViewRow row in gvMedicalCares.Rows)
        {
            if (!((CheckBox)row.FindControl("chkIsPaid")).Checked & ((CheckBox)row.FindControl("chkPay")).Checked)
            {
                litMensaje.Text = string.Format("Falta Cancelar las sesiones por el Paciente");
                return;
            }

            if ((((CheckBox)row.FindControl("chkIsPaid")).Checked | Convert.ToDecimal(((Literal)row.FindControl("litPrice")).Text) == 0) & ((CheckBox)row.FindControl("chkPay")).Checked)
            {
                var IdMedicalCare = new Guid(gvMedicalCares.DataKeys[row.RowIndex][0].ToString());
                var medicalCare = BussinessFactory.GetMedicalCareService().Get(IdMedicalCare).Entity;
                var Invoice = new Invoice
                                  {
                                      Id = Guid.NewGuid(),
                                      Name = txtName.Text.Trim(),
                                      Description = txtName.Text.Trim(),
                                      DatePayment = Convert.ToDateTime(CreationDate),
                                      MPayment = ddlMPayment.SelectedValue,
                                      InvoiceType = ddlInvoice.SelectedValue,
                                      NInvoice = txtNInvoice.Text.Trim(),
                                      Currency = ((Literal)row.FindControl("litCurrency")).Text,
                                      ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                                      Movement = "Egreso",
                                      IsActive = true,
                                      LastModified = LastModified,
                                      CreationDate = CreationDate,
                                      ModifiedBy = ModifiedBy,
                                      CreatedBy = CreatedBy
                                  };

                switch (ddlMedicalCareType.SelectedValue)
                {
                    case "Normales":
                        Invoice.Amount = Convert.ToDecimal(((Literal)row.FindControl("litUnitCost")).Text);
                        medicalCare.IsPaid = true;
                        break;
                    case "Por Partner":
                        Invoice.Amount = Convert.ToDecimal(((Literal)row.FindControl("litUnitCostPartner")).Text);
                        medicalCare.IsPaidPartner = true;
                        break;
                    case "Por Reemplazo":
                        var Invoice1 = new Invoice
                           {
                               Id = Guid.NewGuid(),
                               Name = txtName.Text.Trim(),
                               Description = txtName.Text.Trim(),
                               DatePayment = Convert.ToDateTime(CreationDate),
                               MPayment = ddlMPayment.SelectedValue,
                               InvoiceType = ddlInvoice.SelectedValue,
                               NInvoice = txtNInvoice.Text.Trim(),
                               Currency = ((Literal)row.FindControl("litCurrency")).Text,
                               Amount = Convert.ToDecimal(((Literal)row.FindControl("litUnitCost")).Text),
                               ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                               Movement = "Egreso",
                               IsActive = true,
                               MedicalCare = null,
                               CostCenter = medicalCare.CostCenter,
                               Personal = null,
                               Patient = null,
                               Session = null,
                               LastModified = LastModified,
                               CreationDate = CreationDate,
                               ModifiedBy = ModifiedBy,
                               CreatedBy = CreatedBy,
                           };

                        var CashMovement1 = new CashMovement
                        {
                            Id = Guid.NewGuid(),
                            CostCenter = Invoice1.CostCenter,
                            Invoice = Invoice1,
                            MPayment = ddlMPayment.SelectedValue,
                            Date = Convert.ToDateTime(CreationDate),
                            EmissionAmount = Invoice1.Amount,
                            Amount = Invoice1.Amount,
                            Factor = -1,
                            Currency = Invoice1.Currency,
                            ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                            IsActive = true,
                            LastModified = LastModified,
                            CreationDate = CreationDate,
                            ModifiedBy = ModifiedBy,
                            CreatedBy = CreatedBy,
                        };
                        var Invoice2 = new Invoice
                        {
                            Id = Guid.NewGuid(),
                            Name = txtName.Text.Trim(),
                            Description = txtName.Text.Trim(),
                            DatePayment = Convert.ToDateTime(CreationDate),
                            MPayment = ddlMPayment.SelectedValue,
                            InvoiceType = ddlInvoice.SelectedValue,
                            NInvoice = txtNInvoice.Text.Trim(),
                            Currency = ((Literal)row.FindControl("litCurrency")).Text,
                            Amount = Convert.ToDecimal(((Literal)row.FindControl("litUnitCost")).Text),
                            ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                            Movement = "Ingreso",
                            IsActive = true,
                            MedicalCare = null,
                            CostCenter = StaffInformation.CostCenter,
                            Personal = null,
                            Patient = null,
                            Session = null,
                            LastModified = LastModified,
                            CreationDate = CreationDate,
                            ModifiedBy = ModifiedBy,
                            CreatedBy = CreatedBy,
                        };
                        var CashMovement2 = new CashMovement
                        {
                            Id = Guid.NewGuid(),
                            CostCenter = Invoice2.CostCenter,
                            Invoice = Invoice2,
                            MPayment = ddlMPayment.SelectedValue,
                            Date = Convert.ToDateTime(CreationDate),
                            EmissionAmount = Invoice2.Amount,
                            Amount = Invoice2.Amount,
                            Factor = 1,
                            Currency = Invoice2.Currency,
                            ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                            IsActive = true,
                            LastModified = LastModified,
                            CreationDate = CreationDate,
                            ModifiedBy = ModifiedBy,
                            CreatedBy = CreatedBy,
                        };

                        Invoice1.CashMovements.Add(CashMovement1);
                        Invoice2.CashMovements.Add(CashMovement2);
                        medicalCare.IsPaid = true;
                        try
                        {
                            var response1 = BussinessFactory.GetInvoiceService().Save(Invoice1);
                            var response2 = BussinessFactory.GetInvoiceService().Save(Invoice2);
                            if (response1.OperationResult == OperationResult.Success & response2.OperationResult == OperationResult.Success)
                            {
                                BussinessFactory.GetMedicalCareService().Update(medicalCare);
                                litMensaje.Text = string.Format("Se Guardó Correctamente");
                            }
                            else
                            {
                                litMensaje.Text = string.Format("No se pudo Guardar el Pago {0}", response1.Message);
                            }
                        }
                        catch (Exception e)
                        {
                            litMensaje.Text = string.Format("No se pudo Guardar el Pago, Error : {0}", e.Message);
                        }

                        return;
                }

                Invoice.Personal = medical;
                Invoice.MedicalCare = medicalCare;
                Invoice.CostCenter = medicalCare.Session.Medication.Service.CostCenter;
                Invoice.Patient = null;
                Invoice.Session = null;
                var CashMovement = new CashMovement
                {
                    Id = Guid.NewGuid(),
                    CostCenter = Invoice.CostCenter,
                    Invoice = Invoice,
                    MPayment = ddlMPayment.SelectedValue,
                    Date = Convert.ToDateTime(CreationDate),
                    EmissionAmount = Invoice.Amount,
                    Amount = Invoice.Amount,
                    Factor = -1,
                    Currency = ((Literal)row.FindControl("litCurrency")).Text,
                    ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                    IsActive = true,
                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                };
                Invoice.CashMovements.Add(CashMovement);
                try
                {
                    var response = BussinessFactory.GetInvoiceService().Save(Invoice);
                    if (response.OperationResult == OperationResult.Success)
                    {
                        BussinessFactory.GetMedicalCareService().Update(medicalCare);
                        litMensaje.Text = string.Format("Se Guardó Correctamente");
                    }
                    else
                    {
                        litMensaje.Text = string.Format("No se pudo Guardar el Pago {0}", response.Message);
                    }
                }
                catch (Exception e)
                {
                    litMensaje.Text = string.Format("No se pudo Guardar el Pago, Error : {0}", e.Message);
                }
            }
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtPayUSD.Text) != 0 & string.IsNullOrEmpty(txtVenta.Text))
        {
            litMensaje.Text = string.Format("No se ha Ingresado el Tipo de Cambio del día");
            Response.Redirect(string.Format("~/Derma/Admin/EditExchangeRate.aspx?action=new&returnUrl={0}",
                                            Page.Request.RawUrl));
        }
        Save();
    }
}