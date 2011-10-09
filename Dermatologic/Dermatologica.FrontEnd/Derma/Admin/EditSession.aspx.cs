using System;
using ASP.App_Code;
using Dermatologic.Services;

public partial class Derma_Admin_EditSession : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetSession();
        }
    }
    private void SetSession()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadSession(new Guid(id));
                break;
        }
    }

    private void LoadSession(Guid id)
    {
        var response = BussinessFactory.GetSessionService().Get(id);
        if (response.OperationResult == OperationResult.Success)
        {
            var session = response.Entity;
            txtDescription.Text = session.Description;
            txtPrice.Text = Convert.ToString(session.Price);
            ddlCurrency.SelectedValue = session.Currency;   
        }
    }

    private void Update()
    {
        var id = Request.QueryString.Get("id");
        var responseSession = BussinessFactory.GetSessionService().Get(new Guid(id));
        if (responseSession.OperationResult == OperationResult.Success)
        {
            var session = responseSession.Entity;
            session.Description = txtDescription.Text.Trim();
            session.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            session.Currency = ddlCurrency.SelectedValue;
            session.IsActive = true;
            session.LastModified = LastModified;
            session.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetSessionService().Update(session);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", session.Medication.Id), true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar la Sesión");
            }
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "edit":
                Update();
                break;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        var id = Request.QueryString.Get("id");
        var response = BussinessFactory.GetSessionService().Get(new Guid(id));
        if (response.OperationResult == OperationResult.Success)
        {
            var session = response.Entity;
            Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", session.Medication.Id), true);   
        }
    }
}