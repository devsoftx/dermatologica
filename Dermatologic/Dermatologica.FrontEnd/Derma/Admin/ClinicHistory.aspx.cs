using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;

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
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("ClinicHistoryInformation.aspx?id={0}&action=edit", id), true);
                break;
        }
    }

    private void GetCostCenter()
    {
        var list = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive == true);
        BindControl<CostCenter>.BindDropDownList(ddlCostCenter,list);
    }

    private void GetMedications()
    {
        var Medications = BussinessFactory.GetMedicationService().GetAll(u => u.IsActive == true).OrderBy(p => p.LastModified).ToList();
        BindControl<Medication>.BindGrid(gvMedications, Medications);
    }
}