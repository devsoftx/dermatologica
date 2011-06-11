using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_ListPatients : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchPatients();
    }

    private void SearchPatients()
    {
        const string personType = "9B64DDB9-1C00-4A8B-99E5-FDCD96B3FF68";
        var example = new Person
        {
            PersonType = { Id = new Guid(personType) },
            FirstName = txtSearch.Text.Trim().ToLower(),
            LastNameP = txtSearch.Text.Trim().ToLower(),
            LastNameM = txtSearch.Text.Trim().ToLower(),
        };
        var response = BussinessFactory.GetPersonService().GetPacients(example);
        if (response.OperationResult == OperationResult.Success)
        {
            gvPatients.DataSource = response.Pacients;
            gvPatients.DataBind();
        }
    }
  
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchPatients();
    }

    protected void gvPatients_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("PatientInformation.aspx?id={0}", id), true);
                break;
        }
    }
}