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

      //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);
        
        txtName.Text = "Pago de la Sesión " + session.Description;
        txtAmount.Text = Convert.ToString(session.Residue);
        txtPrice.Text = Convert.ToString(session.Price);
        txtResidue.Text = Convert.ToString(session.Residue);

        var List = BussinessFactory.GetExchangeRateService().GetAll().Where(p => p.DateRate.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToList();
    // p.DateDate.ToShortDate().Equals(Datetime.Now.ToShortDate())
        // GetAll().Where(p => p.DateRate == currentDate).ToList();
        
        var echangeToday = List.OrderBy(p => p.CreationDate).FirstOrDefault();
        txtCompra.Text = echangeToday.Buy.ToString();
        txtVenta.Text = echangeToday.Sale.ToString();
        // var   ExchangeRate1=new ExchangeRate 
       //  ExchangeRate1=ExchangeRates.ExchangeRates.First<ExchangeRate> 

       // txtCompra.Text=ExchangeRates.ExchangeRates.First
       //foreach (ExchangeRate ExchangeRate in ExchangeRates)
       //{
       
       //}
    }



    private void Save()
    {

        var IdSession = Request.QueryString.Get("idSession");
        var session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

        //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);

        var Payment = new Payment
        {
            Id = Guid.NewGuid(),
            Name =txtName.Text.Trim(),
            Description = txtName.Text.Trim(),
            DatePayment=Convert.ToDateTime(CreationDate),
            MPayment=ddlMPayment.SelectedValue,
            Invoice=ddlInvoice.SelectedValue,
            NInvoice=txtNInvoice.Text.Trim(),
            Amount=txtAmount.Text.Trim(),
            Currency=ddlCurrency.SelectedValue,
            //If( txtVenta.Text=="")
            //{
            ExchangeRate=Convert.ToDecimal(txtVenta.Text.Trim()),
            //}
            
            IsActive = true,

            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy,
           // Patient = patient,
       
        };
          Payment.Pacient=Medication.Patient;
          Payment.Session=session;

          session.Account = Convert.ToDecimal(txtAmount.Text.Trim());
          session.Residue = session.Price - session.Account;
        try
        {
           
            var response = BussinessFactory.GetPaymentService().Save(Payment);

            if (response.OperationResult == OperationResult.Success)
            {
                BussinessFactory.GetSessionService().Update(session);
                Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", IdMedication), true);
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

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        //var action = Request.QueryString.Get("action");
        //switch (action)
        //{
        //    case "new":
        Save();
        //    break;
        //case "edit":
        //    Update();
        //    break;
        // }
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