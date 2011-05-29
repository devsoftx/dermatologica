using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;

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
                              LastName = txtSearch.Text.Trim().ToLower(),
                          };
        var pacients = BussinessFactory.GetPersonService().GetPacients(example);
        gvPersons.DataSource = pacients;
        gvPersons.DataBind();
    }

    protected void gvPersons_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}