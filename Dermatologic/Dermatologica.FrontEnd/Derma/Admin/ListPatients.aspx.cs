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
        var personType = "c78ca3d8-f0c5-450e-aa64-5afa0a5e2c54";
        var example = new Person
        {
            PersonType = { Id = new Guid(personType) },
            FirstName = txtSearch.Text.Trim().ToLower(),
            LastName = txtSearch.Text.Trim().ToLower(),
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
}