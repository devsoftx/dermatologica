using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Payment = Dermatologic.Domain.Payment;
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
        var Session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

      //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = Session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);
        
        txtName.Text = "Pago de la Sesión " + Session.Description;
        txtAmount.Text = Convert.ToString(Session.Residue);
        txtPrice.Text = Convert.ToString(Session.Price);
        txtResidue.Text = Convert.ToString(Session.Residue);
    }



    private void Save()
    {

        var IdSession = Request.QueryString.Get("idSession");
        var Session = BussinessFactory.GetSessionService().Get(new Guid(IdSession));

        //  var IdMedication = Request.QueryString.Get("idMedication");
        var IdMedication = Session.Medication.Id;
        var Medication = BussinessFactory.GetMedicationService().Get(IdMedication);

        var Payment = new Payment
        {
            Id = Guid.NewGuid(),
            Name =txtName.Text.Trim(),
            Description = txtName.Text.Trim(),
            DatePayment=Convert.ToDateTime(CreationDate),
            MPayment=txtName.Text.Trim(),
            Invoice=ddlInvoice.SelectedValue,
            NInvoice=txtNInvoice.Text.Trim(),
            Amount=txtAmount.Text.Trim(),
            Currency=ddlCurrency.SelectedValue,
            ExchangeRate=Convert.ToDecimal(txtExchangeRate.Text.Trim()), 
            IsActive = true,

            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy,
           // Patient = patient,
       
        };
          Payment.Pacient=Medication.Patient;
          Payment.Session=Session;

          Session.Account = Convert.ToDecimal(txtAmount.Text.Trim());
          Session.Residue = Session.Price - Session.Account;
        try
        {
           
            var response = BussinessFactory.GetPaymentService().Save(Payment);

            if (response.OperationResult == OperationResult.Success)
            {
                BussinessFactory.GetSessionService().Update(Session);
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