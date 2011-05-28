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

    }

    private void SearchPersons()
    {
        var example = new Person
                          {
                              DocumentType = "",
                              PersonType = {Id = new Guid("")},
                              FirstName = "",
                              LastName = "",
                              DocumentNumber = ""
                          };
        var pacients = BussinessFactory.GetPersonService().GetPacients(example);
    }

    protected void gvPersons_RowCommand(object sender, GridViewCommandEventArgs e)
    {

    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}