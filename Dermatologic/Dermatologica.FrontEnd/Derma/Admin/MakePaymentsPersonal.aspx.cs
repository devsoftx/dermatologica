using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Invoice = Dermatologic.Domain.Invoice;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_MakePaymentsPersonal : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
            SetPayment();
            LoadPersonType();
        }
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }

    private void SetPayment()
    {
        if (CreationDate != null) txtDatePayment.Text = CreationDate.Value.ToShortDateString();
        var List = BussinessFactory.GetExchangeRateService().GetAll().Where(p => p.DateRate.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToList();
        var echangeToday = List.OrderBy(p => p.CreationDate).FirstOrDefault();
        if (echangeToday != null)
        {
            txtCompra.Text = echangeToday.Buy.ToString();
            txtVenta.Text = echangeToday.Sale.ToString();
        }
    }

    private void LoadCostCenter()
    {
        var types = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        BindControl<CostCenter>.BindDropDownList(ddlCostCenter, types);
    }

    private void LoadPersonType()
    {
        var types = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        BindControl<PersonType>.BindDropDownList(ddlPersonType, types);
    }

    private void SearchMedicalcaresByPerson()
    {
        if (!string.IsNullOrEmpty(ucSearchPersonsMedical.SelectedValue))
        {
            var example = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
            var response = BussinessFactory.GetMedicalCareService().GetMedicalCaresByPerson(example);
            if (response.OperationResult == OperationResult.Success)
            {
                gvMedicalCares.DataSource = response.MedicalCares.OrderBy(p => p.Session.RowId).ToList();
                gvMedicalCares.DataBind();
                txtResidue.Text = response.MedicalCares.Sum(p => p.Rate.UnitCost).ToString();
                txtAmount.Text = txtResidue.Text;
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
        var Pago = Convert.ToDecimal(txtAmount.Text.Trim());
        foreach (GridViewRow row in gvMedicalCares.Rows)
        {
            if (Pago == 0)
            {
                break;
            }

            if (((CheckBox)row.FindControl("chkIsPaid")).Checked)
            {
                var IdMedicalCare = new Guid(gvMedicalCares.DataKeys[row.RowIndex][0].ToString());
                var medicalCare = BussinessFactory.GetMedicalCareService().Get(IdMedicalCare);
                var medical = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
                var Invoice = new Invoice
                                  {
                                      Id = Guid.NewGuid(),
                                      Name = txtName.Text.Trim(),
                                      Description = txtName.Text.Trim(),
                                      DatePayment = Convert.ToDateTime(CreationDate),
                                      MPayment = ddlMPayment.SelectedValue,
                                      InvoiceType = ddlInvoice.SelectedValue,
                                      NInvoice = txtNInvoice.Text.Trim(),
                                      Currency = ddlCurrency.SelectedValue,
                                      ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                                      IsActive = true,
                                      Movement = "Ingreso",
                                      LastModified = LastModified,
                                      CreationDate = CreationDate,
                                      ModifiedBy = ModifiedBy,
                                      CreatedBy = CreatedBy,
                                      Personal = medical,
                                      Amount = Convert.ToDecimal(((Literal) row.FindControl("litRate")).Text),
                                  };

                medicalCare.IsPaid = true;
                Invoice.MedicalCare = medicalCare;
                Invoice.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue));
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
                        litMensaje.Text = string.Format("No se pudo Guardar el Pago");
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (ddlCurrency.SelectedValue == "USD" & string.IsNullOrEmpty(txtVenta.Text))
        {
            litMensaje.Text = string.Format("No se ha Ingresado el Tipo de Cambio del día");
            Response.Redirect("~/Derma/Admin/EditExchangeRate.aspx?action=new");
        }
        if (Convert.ToDecimal(txtAmount.Text) == 0)
        {
            litMensaje.Text = string.Format("El Monto a Pagar No puede Ser Cero");
            return;
        }
        if (string.IsNullOrEmpty(txtAmount.Text))
        {
            litMensaje.Text = string.Format("Debe Ingresar Una Cantidad a Pagar");
            return;
        }
        if (Convert.ToDecimal(txtAmount.Text.Trim()) > Convert.ToDecimal(txtResidue.Text))
        {
            litMensaje.Text = string.Format("El Monto a Pagar es mayor que el Saldo");
            return;
        }
        Save();
    }
}