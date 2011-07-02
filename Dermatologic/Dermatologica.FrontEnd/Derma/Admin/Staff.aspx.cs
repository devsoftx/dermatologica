using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_Staff : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Search();
        }
    }

    private void Search()
    {
        const string personType = "9B64DDB9-1C00-4A8B-99E5-FDCD96B3FF68"; // not in with Patient Id
        var example = new Person
        {
            PersonType = { Id = new Guid(personType) },
            FirstName = txtSearch.Text.Trim().ToLower(),
            LastNameP = txtSearch.Text.Trim().ToLower(),
            LastNameM = txtSearch.Text.Trim().ToLower(),
        };
        var response = BussinessFactory.GetPersonService().GetStaff(example);
        if (response.OperationResult == OperationResult.Success)
        {
            var staff = response.Staff;
            BindControl<Person>.BindGrid(gvStaff,staff);
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        Search();
    }

    protected void gvStaff_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("StaffInformation.aspx?id={0}", id), true);
                break;
        }
    }
}