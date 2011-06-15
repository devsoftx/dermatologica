using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Invoice = Dermatologic.Domain.Invoice;
using CashMovement = Dermatologic.Domain.CashMovement;
using ExchangeRate = Dermatologic.Domain.ExchangeRate;
//using MedicalCare = Dermatologic.Domain.MedicalCare;

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

        txtDatePayment.Text = Convert.ToString(CreationDate);
        
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
        //var example = new Person
        //{
        var example = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
        //};
        var response = BussinessFactory.GetMedicalCareService().GetMedicalCaresByPerson(example);
        if (response.OperationResult == OperationResult.Success)
        {
            gvMedicalCares.DataSource = response.MedicalCares;
            gvMedicalCares.DataBind();
            txtResidue.Text = response.MedicalCares.Sum(p => p.Rate.UnitCost).ToString();
            txtAmount.Text = txtResidue.Text;
           // BindControl<Session>.BindGrid(gvSessions, response.Sessions.OrderBy(p => p.Residue).ToList());
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

            if (((CheckBox)row.FindControl("chkIsPaid")).Checked == true)
            {


              //  var Medication = BussinessFactory.GetMedicationService().Get(new Guid(MedicationId));


                var IdMedicalCare = new Guid(gvMedicalCares.DataKeys[row.RowIndex][0].ToString());

               // var session = BussinessFactory.GetSessionService().Get(IdSession);
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
                     //Amount = Convert.ToDecimal(((Literal)row.FindControl("litRate")).Text),
                    Currency = ddlCurrency.SelectedValue,
                    ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                    IsActive = true,
                    Movement="Ingreso",

                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                    
                    Personal=medical,
                   

                };

                Invoice.Amount = Convert.ToDecimal(((Literal)row.FindControl("litRate")).Text);
                medicalCare.IsPaid = true;
                Invoice.MedicalCare = medicalCare;
                Invoice.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue));

                                              

                //session.Account = session.Account + Convert.ToDecimal(Payment.Amount);
                //session.Residue = session.Price - session.Account;
                //if (session.Residue == 0)
                //{
                //    session.IsPaid = true;
                //}

                try
                {

                    var response = BussinessFactory.GetInvoiceService().Save(Invoice);

                    if (response.OperationResult == OperationResult.Success)
                    {
                        BussinessFactory.GetMedicalCareService().Update(medicalCare);
                        //Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", MedicationId), true);
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

    }

   
}