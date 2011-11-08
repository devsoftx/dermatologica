using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologica.Web;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_SearchPersons : PageBase{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["personSelected"] = null;
            SearchPersons();
        }
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
            gvPersons.DataSource = response.Pacients.OrderBy(p => p.LastNameP).ToList();
            gvPersons.DataBind();
        }
    }
    
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchPersons();
    }

    protected void btnAcept_Click(object sender, EventArgs e)
    {
        if(gvPersons.SelectedValue != null)
        {
            var id = new Guid(gvPersons.SelectedValue.ToString());
            Session.Add("personSelected",id);
            const string javascript = "onClose()";
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "", javascript, true);
        }
    }

}