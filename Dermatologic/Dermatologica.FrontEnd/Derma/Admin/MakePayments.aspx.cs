using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Payment = Dermatologic.Domain.Payment;
using ExchangeRate = Dermatologic.Domain.ExchangeRate;
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

        var MedicationId = Request.QueryString.Get("idMedication");
        

        var IdMedication = session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);

        LoadSessions(new Guid(MedicationId));

        txtName.Text = "Pago del Tratamiento " + Medication.Description;
        //txtAmount.Text = Convert.ToString(session.Residue);
        //txtPrice.Text = Convert.ToString(session.Price);
        //txtResidue.Text = Convert.ToString(session.Residue);
        lblCurrency.Text = Convert.ToString(session.Currency);

        var List = BussinessFactory.GetExchangeRateService().GetAll().Where(p => p.DateRate.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToList();     
        var echangeToday = List.OrderBy(p => p.CreationDate).FirstOrDefault();
        if (echangeToday!=null)
        {
            txtCompra.Text = echangeToday.Buy.ToString();
            txtVenta.Text = echangeToday.Sale.ToString(); 
        }
          
        //else
        //{
        //    txtCompra.Text = echangeToday.Buy.ToString();
        //    txtVenta.Text = echangeToday.Sale.ToString();    
        //}
        
       
       
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
        var MedicationId = Request.QueryString.Get("idMedication");

        foreach (GridViewRow row in gvSessions.Rows)
        {
            if (Pago == 0)
            {
                break;
            }

            if (((CheckBox)row.FindControl("chkIsPaid")).Checked == false)
            {
                
             
                var Medication = BussinessFactory.GetMedicationService().Get(new Guid(MedicationId));


                var IdSession = new Guid(gvSessions.DataKeys[row.RowIndex][0].ToString());
                
                var session = BussinessFactory.GetSessionService().Get(IdSession);

                var Payment = new Payment
                {
                    Id = Guid.NewGuid(),
                    Name = txtName.Text.Trim(),
                    Description = txtName.Text.Trim(),
                    DatePayment = Convert.ToDateTime(CreationDate),
                    MPayment = ddlMPayment.SelectedValue,
                    Invoice = ddlInvoice.SelectedValue,
                    NInvoice = txtNInvoice.Text.Trim(),
                    Currency = ddlCurrency.SelectedValue,
                    ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                    IsActive = true,

                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                    // Patient = patient,

                };


                if (Pago > session.Residue)
                {
                    Payment.Amount = Convert.ToString(session.Residue);
                    Pago = Pago - session.Residue;
                }
                else
                {
                    Payment.Amount = Pago.ToString();
                    Pago = Convert.ToDecimal(0);
                }

                Payment.Pacient = Medication.Patient;
                Payment.Session = session;

                session.Account = session.Account + Convert.ToDecimal(Payment.Amount);
                session.Residue = session.Price - session.Account;
                if (session.Residue == 0)
                {
                    session.IsPaid = true;
                }

                try
                {

                    var response = BussinessFactory.GetPaymentService().Save(Payment);

                    if (response.OperationResult == OperationResult.Success)
                    {
                        BussinessFactory.GetSessionService().Update(session);
                        //Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", MedicationId), true);
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
        if (ddlCurrency.SelectedValue == "USD" & txtVenta.Text == "")
        {
            litMensaje.Text = string.Format("No se ha Ingresado el Tipo de Cambio del día");
            Response.Redirect("~/Derma/Admin/EditExchangeRate.aspx?action=new");
           //return;
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
        var Session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

        //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = Session.Medication.Id;
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", IdMedication), true);
    }
}