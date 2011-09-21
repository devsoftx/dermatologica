using System;
using System.Web.Security;
using ASP.App_Code;

public partial class Derma_Admin_EditUser : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetUser();
        }
        ErrorMessage.Text = String.Empty;
    }

    private void SetUser()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                
                break;
            case "edit":
                LoadUser(id);
                break;
        }
    }

    private void LoadUser(string id)
    {
        var user = Membership.GetUser(new Guid(id), false);
        Answer.Enabled = false;
        Question.Enabled = false;
        if (user != null)
        {
            UserName.Text = user.UserName;
            Email.Text = user.Email;
        }
    }
    
    private void Update()
    {
        string id = Request.QueryString.Get("id");
        var user = Membership.GetUser(new Guid(id), false);
        if (user != null)
        {
            user.Email = Email.Text;
            try
            {
                Membership.UpdateUser(user);
                Response.Redirect("~/Derma/Admin/ListUsers.aspx", true);
                return;
            }
            catch (Exception ex)
            {
                ErrorMessage.Text = string.Format("No se pudo actualizar usuario - {0}",ex.Message);
            }
        }
    }

    private void New()
    {
        var userName = UserName.Text;
        var password = Password.Text;
        var email = Email.Text;
        var question = Question.Text;
        var passwordAnswer = Answer.Text;
        MembershipCreateStatus status;
        var response = Membership.CreateUser(userName, password, email, question, passwordAnswer, true, out status);
        if(status == MembershipCreateStatus.Success)
        {
            Response.Redirect("~/Derma/Admin/ListUsers.aspx", true);
            return;
        }
        ErrorMessage.Text = "No se pudo crear usuario";
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListUsers.aspx", true);
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "new":
                New();
                break;
            case "edit":
                Update();
                break;
        }
    }
}