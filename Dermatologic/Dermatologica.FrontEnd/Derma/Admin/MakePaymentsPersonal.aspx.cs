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
    protected void btnAceptar_Click(object sender, EventArgs e)
    {

    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {

    }
    
}