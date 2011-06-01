using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using ExchangeRate = Dermatologic.Domain.ExchangeRate;

public partial class Derma_Admin_ListExchangeRates : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetExchangeRates();
    }
    protected void gvExchangeRates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditExchangeRate.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteService(new Guid(e.CommandArgument.ToString()));
                GetExchangeRates();
                break;

        }
    }
    
    private void GetExchangeRates()
    {
        var Services = BussinessFactory.GetServiceService().GetAll(u => u.IsActive == true);
        
        var ExchangeRates = BussinessFactory.GetExchangeRateService().GetAll(u => u.IsActive == true);
        BindControl<ExchangeRate>.BindGrid(gvExchangeRates, ExchangeRates);
    }
    private void DeleteService(Guid id)
    {
        var Service = BussinessFactory.GetServiceService().Get(id);
        if (Service != null)
        {
            Service.IsActive = false;
            Service.LastModified = LastModified;
            Service.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetServiceService().Update(Service);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó El Servicio");
                return;
            }
        }
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditService.aspx?action=new");
    }
   
}