using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using CostCenter = Dermatologic.Domain.CostCenter;

public partial class Derma_Admin_ListCostCenters : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetCostCenters();
    }
    protected void gvCostCenters_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditCostCenter.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteCostCenter(new Guid(e.CommandArgument.ToString()));
                GetCostCenters();
                break;
        }
    }
    
    private void GetCostCenters()
    {
        var response = BussinessFactory.GetCostCenterService().GetAll(u => u.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var costCenters = response.Results.OrderBy(p => p.Name).ToList();
            BindControl<CostCenter>.BindGrid(gvCostCenters, costCenters);    
        }
    }
    private void DeleteCostCenter(Guid id)
    {
        var responseCostCenter = BussinessFactory.GetCostCenterService().Get(id);
        if (responseCostCenter.OperationResult == OperationResult.Success)
        {
            var costCenter = responseCostCenter.Entity;
            costCenter.IsActive = false;
            costCenter.LastModified = LastModified;
            costCenter.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetCostCenterService().Update(costCenter);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó El Centro de Costo");
                return;
            }
        }
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditCostCenter.aspx?action=new");
    }


   
}