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
           
           
        }
       // GetRates();
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }
    protected void gvRates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                //var idpersontype=new Guid(ucSearchPersonsMedical.SelectedValue);
                //Response.Redirect(string.Format("EditRate.aspx?id={0}&idpersontype={1}&action=edit", id), true);
                Response.Redirect(string.Format("EditRate.aspx?id={0}&action=edit", id), true);
                //idSession={0}&idMedication={1}
                break;
            case "cmd_eliminar":
                DeleteRate(new Guid(e.CommandArgument.ToString()));
                SearchRatesByPerson();
                break;
        }
    }
    private void LoadPersonType()
    {
        var types = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        BindControl<PersonType>.BindDropDownList(ddlPersonType, types);
    }
 

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }
    
    private void SearchRatesByPerson()
    {
       var example = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
        
       var response = BussinessFactory.GetRateService().GetRatesByPerson(example);
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
        var Rate = BussinessFactory.GetRateService().Get(id);
        if (Rate != null)
        {
            Rate.IsActive = false;
            Rate.LastModified = LastModified;
            Rate.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetRateService().Update(Rate);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó El Tipo de Persona");
                return;
            }
        }
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditRate.aspx?action=new");
    }
   
}