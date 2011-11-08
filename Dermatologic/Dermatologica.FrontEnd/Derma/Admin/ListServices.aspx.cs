using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologica.Web;
using Dermatologic.Domain;
using Dermatologic.Services;
using Service = Dermatologic.Domain.Service;

public partial class Derma_Admin_ListServices :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
            GetServices();
        }
    }

    protected void gvServices_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditService.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteService(new Guid(e.CommandArgument.ToString()));
                GetServices();
                break;
        }
    }

    private void LoadCostCenter()
    {
        var response = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        if(response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<CostCenter>.BindDropDownList(ddlCostCenter, types);   
        }
    }

    private void GetServices()
    {
        var example = BussinessFactory.GetCostCenterService().Get(new Guid (ddlCostCenter.SelectedValue));
        var response = BussinessFactory.GetServiceService().GetServicesByCostCenter(example.Entity);
        if (response.OperationResult == OperationResult.Success)
        {
            gvServices.DataSource = response.Services;
            gvServices.DataBind();
        }
    }

    private void DeleteService(Guid id)
    {
        var responseService = BussinessFactory.GetServiceService().Get(id);
        if (responseService.OperationResult == OperationResult.Success)
        {
            var Service = responseService.Entity;
            Service.IsActive = false;
            Service.LastModified = LastModified;
            Service.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetServiceService().Update(Service);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó el Tratamiento");
                return;
            }
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditService.aspx?action=new");
    }

    protected void ddlCostCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        GetServices();
    }
}