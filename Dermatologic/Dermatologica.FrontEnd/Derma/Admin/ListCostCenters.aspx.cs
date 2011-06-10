using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
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
        //var CostCenters = BussinessFactory.GetCostCenterService().GetAll(u => u.IsActive == true).OrderBy(p => p.Name).ToList();
        //BindControl<CostCenter>.BindGrid(gvCostCenters, CostCenters);
    }
    private void DeleteCostCenter(Guid id)
    {
        var CostCenter = BussinessFactory.GetCostCenterService().Get(id);
        if (CostCenter != null)
        {
            CostCenter.IsActive = false;
            CostCenter.LastModified = LastModified;
            CostCenter.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetCostCenterService().Update(CostCenter);
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