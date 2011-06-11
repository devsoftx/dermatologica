using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_SearchPersons : PageBase
{
    
    protected void Page_Load(object sender, EventArgs e)
    {
        SearchPersons();
    }

    private void SearchPersons()
    {
        var personType = Request.QueryString.Get("personType");
        var example = new Person
                          {
                              PersonType = { Id = new Guid(personType) },
                              FirstName = txtSearch.Text.Trim().ToLower(),
                              LastNameP = txtSearch.Text.Trim().ToLower(),
                              LastNameM = txtSearch.Text.Trim().ToLower()
                          };
        var response = BussinessFactory.GetPersonService().GetPacients(example);
        if (response.OperationResult == OperationResult.Success)
        {
            gvPersons.DataSource = response.Pacients;
            gvPersons.DataBind();
        }
    }

    protected void gvPersons_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchPersons();
    }

    protected void btnAcept_Click(object sender, EventArgs e)
    {

    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {

    }
}