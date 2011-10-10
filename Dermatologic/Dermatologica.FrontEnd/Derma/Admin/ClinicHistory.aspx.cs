using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ClinicHistory : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetCostCenter();
            GetMedications();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }

    protected void gvMedication_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName != "Page")
        {
            switch (e.CommandName)
            {
                case "cmd_editar":
                    var id = new Guid(e.CommandArgument.ToString());
                    Response.Redirect(string.Format("ClinicHistoryInformation.aspx?id={0}&action=edit", id), true);
                    break;
            }
        }
    }

    private void GetCostCenter()
    {
        var response = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive == true);
        if (response.OperationResult == OperationResult.Success)
        {
            var list = response.Results;
            BindControl<CostCenter>.BindDropDownList(ddlCostCenter, list);    
        }
        
    }

    private void GetMedications()
    {
        var response = BussinessFactory.GetMedicationService().GetAll(u => u.IsActive == true);
        if(response.OperationResult == OperationResult.Success)
        {
            var medications = response.Results.OrderBy(p => p.LastModified).ToList();
            BindControl<Medication>.BindGrid(gvMedications, medications);
        }
        
    }
    protected void gvMedications_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {

    }
}