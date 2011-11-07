using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Rate = Dermatologic.Domain.Rate;
using PersonType = Dermatologic.Domain.PersonType;
using Person = Dermatologic.Domain.Person;


public partial class Derma_Admin_ListRates : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadPersonType();
            LoadRates();
        }
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }

    private void LoadRates()
    {
        var response = BussinessFactory.GetRateService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var rates = response.Results;
            BindControl<Rate>.BindGrid(gvRates, rates);
        }
    }

    protected void gvRates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditRate.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteRate(new Guid(e.CommandArgument.ToString()));
                SearchRatesByPerson();
                break;
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

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }
    
    private void SearchRatesByPerson()
    {
        if (string.IsNullOrEmpty(ucSearchPersonsMedical.Text))
        {
            litMensaje.Text = string.Format("Falta Seleccionar la Persona Tratante");
            return;
        }
       var example = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
       var response = BussinessFactory.GetRateService().GetRatesByPerson(example.Entity);
        if (response.OperationResult == OperationResult.Success)
        {
            gvRates.DataSource = response.Rates;
            gvRates.DataBind();
        }
    }
      
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchRatesByPerson();
    }

    private void DeleteRate(Guid id)
    {
        var responseRate = BussinessFactory.GetRateService().Get(id);
        if (responseRate.OperationResult == OperationResult.Success)
        {
            var rate = responseRate.Entity;
            rate.IsActive = false;
            rate.LastModified = LastModified;
            rate.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetRateService().Update(rate);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó la tarifa");
                return;
            }
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditRate.aspx?action=new");
    }
   
}