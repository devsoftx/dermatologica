using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_MakePayments : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetPayment();
           
            txtDatePayment.Text = Convert.ToString(CreationDate);
        }
    }

    private void SetPayment()
    {
        var IdSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));
        var IdMedication = session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);
        if (IdMedication != null) LoadSessions(IdMedication.Value);
        txtName.Text = "Pago del Tratamiento " + Medication.Description;
        lblCurrency.Text = Convert.ToString(session.Currency);
        var List = BussinessFactory.GetExchangeRateService().GetAll().Where(p => p.DateRate.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToList();     
        var echangeToday = List.OrderBy(p => p.CreationDate).FirstOrDefault();
        if (echangeToday!=null)
        {
            txtCompra.Text = echangeToday.Buy.ToString();
            txtVenta.Text = echangeToday.Sale.ToString(); 
        }
    }

   

    private void LoadSessions(Guid medicationId)
    {
        var session = new Session { Medication = { Id = medicationId } };
        var response = BussinessFactory.GetSessionService().GetSessionByMedication(session);
        if (response.OperationResult == OperationResult.Success)
        {
            txtPrice.Text = response.Sessions.Sum(p => p.Price).ToString();
            txtResidue.Text = response.Sessions.Sum(p => p.Residue).ToString();
            BindControl<Session>.BindGrid(gvSessions, response.Sessions.OrderBy(p => p.Residue).ToList());
        }
    }

    private void Save()
    {
        var Pago = Convert.ToDecimal(txtAmount.Text.Trim());

        var idsession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(idsession));
        var MedicationId = session.Medication.Id;

        //var MedicationId = Request.QueryString.Get("idMedication");
        foreach (GridViewRow row in gvSessions.Rows)
        {
            if (Pago == 0)
            {
                break;
            }
            if (((CheckBox)row.FindControl("chkIsPaid")).Checked == false)
            {
                var medication = BussinessFactory.GetMedicationService().Get(MedicationId);
                var IdSession = new Guid(gvSessions.DataKeys[row.RowIndex][0].ToString());
                var Session = BussinessFactory.GetSessionService().Get(IdSession);
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
                    Movement="Ingreso",
                    IsActive = true,
                                             
                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                };

                decimal venta=Convert.ToDecimal(txtVenta.Text);
                decimal compra = Convert.ToDecimal(txtCompra.Text);

                if (medication.Currency == ddlCurrency.SelectedValue)//si la moneda de tratamiento=moneda de pago
                {
                    if (Pago > Session.Residue)
                    {
                        Invoice.Amount = Session.Residue;
                        Pago = Pago - Session.Residue;
                    }
                    else
                    {
                        Invoice.Amount = Pago;
                        Pago = Convert.ToDecimal(0);
                    }

                    Session.Account = Session.Account + Invoice.Amount;
                    Session.Residue = Session.Price - Session.Account;
                }
                else if(medication.Currency != ddlCurrency.SelectedValue)
                {
                    if (medication.Currency == "PEN")//pago paciente en $.
                    {
                        if (Pago > Session.Residue/compra)
                        {
                            Invoice.Amount = Session.Residue/compra;
                            Pago = Pago - Session.Residue/compra;
                        }
                        else
                        {
                            Invoice.Amount = Pago;
                            Pago = Convert.ToDecimal(0);
                        }

                        Session.Account = Session.Account + Invoice.Amount*compra ;
                        Session.Residue = Session.Price - Session.Account;
                    }
                    else if (medication.Currency == "USD")//pago paciente S/.
                    {
                        if (Pago > Session.Residue*venta)
                        {
                            Invoice.Amount = Session.Residue * venta;
                            Pago = Pago - Session.Residue * venta;
                        }
                        else
                        {
                            Invoice.Amount = Pago;
                            Pago = Convert.ToDecimal(0);
                        }

                        Session.Account = Session.Account + Invoice.Amount/venta ;
                        Session.Residue = Session.Price - Session.Account;
                    }
                }
               

                Invoice.Patient = medication.Patient;
                Invoice.Session = Session;
                Invoice.CostCenter = medication.Service.CostCenter;
                //Invoice.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue));
                Invoice.Personal = null;
                Invoice.MedicalCare = null;

                if (Session.Residue == 0)
                {
                    Session.IsPaid = true;
                }


                var CashMovement = new CashMovement
                {
                    Id = Guid.NewGuid(),
                    CostCenter = Invoice.CostCenter,
                    Invoice = Invoice,
                    MPayment = ddlMPayment.SelectedValue,
                    Date = Convert.ToDateTime(CreationDate),
                    EmissionAmount = Invoice.Amount,
                    Amount = Invoice.Amount,
                    Factor = 1,
                    Currency = ddlCurrency.SelectedValue,
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
                        BussinessFactory.GetSessionService().Update(Session);
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
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", MedicationId), true);
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtAmount.Text) != 0 & string.IsNullOrEmpty(txtVenta.Text))
        {
            litMensaje.Text = string.Format("No se ha Ingresado el Tipo de Cambio del día");
            Response.Redirect(string.Format("~/Derma/Admin/EditExchangeRate.aspx?action=new&returnUrl={0}",
                                            Page.Request.RawUrl));
        }
       
          if (Convert.ToDecimal(txtAmount.Text) == 0)
        {
            litMensaje.Text = string.Format("El Monto a Pagar No puede Ser Cero");
            return;
        }
        if (txtAmount.Text == "")
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

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        var IdSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));
        var IdMedication = session.Medication.Id;
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", IdMedication), true);
    }
}