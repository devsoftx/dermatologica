using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Person = Dermatologic.Domain.Person;

public partial class Derma_Admin_ListPersons : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetPersons();
    }
  
    protected void gvPersons_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        var id = new Guid(e.CommandArgument.ToString());
        switch (e.CommandName)
        {
            case "cmd_info":
                Response.Redirect(string.Format("PrivateInfomation.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_editar":
                Response.Redirect(string.Format("EditPerson.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeletePerson(new Guid(e.CommandArgument.ToString()));
                GetPersons();
                break;
        }
    }
  
    private void GetPersons()
    {
        var persons = BussinessFactory.GetPersonService().GetAll(u => u.IsActive == true).OrderBy(p => p.LastModified).ToList();
        BindControl<Person>.BindGrid(gvPersons, persons);
    }

    private void DeletePerson(Guid id)
    {
        var Person = BussinessFactory.GetPersonService().Get(id);
        if (Person != null)
        {
            Person.IsActive = false;
            Person.LastModified = LastModified;
            Person.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetPersonService().Update(Person);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó la Persona: {0}", Person.FirstName);
                return;
            }
        }
    }

    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditPerson.aspx?action=new");
    }

    private void SearchPersons()
    {
        var example = new Person
        {
            FirstName = txtSearch.Text.Trim().ToLower(),
            LastNameP = txtSearch.Text.Trim().ToLower(),
            LastNameM = txtSearch.Text.Trim().ToLower(),
        };
        var response = BussinessFactory.GetPersonService().SearchPersons(example);
        if (response.OperationResult == OperationResult.Success)
        {
            gvPersons.DataSource = response.Pacients;
            gvPersons.DataBind();
        }
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchPersons();
    }

    protected void gvPersons_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var entity = e.Row.DataItem as Person;
            if (entity != null)
            {
                var img = ((System.Web.UI.HtmlControls.HtmlImage)e.Row.FindControl("Img1"));
                var lnk = ((LinkButton)e.Row.FindControl("lnk_info"));
                if (entity.PersonType.Id == new Guid(DermaConstants.PERSON_TYPE))
                {
                    if (true)
                    {
                        img.Src = "~/images/security.png";
                    }

                }
                else
                {
                    lnk.CommandName = "#";
                }
            }
        }
    }

}