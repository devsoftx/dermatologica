using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Session = Dermatologic.Domain.Session;
using Dermatologic.Domain;
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
    void LoadSession(Guid id)
    {
        var Session = BussinessFactory.GetSessionService().Get(id);
        //txtName.Text = Session.Name;
        txtDescription.Text = Session.Description;
        txtPrice.Text = Convert.ToString(Session.Price);
        ddlCurrency.SelectedValue = Session.Currency;
      
    }

    //private void Save()
    //{
    //    var Session = new Session
    //    {
    //        Id = Guid.NewGuid(),
    //        Name = txtName.Text.Trim(),
    //        Description = txtDescription.Text.Trim(),
    //        IsActive = true,
    //        LastModified = LastModified,
    //        CreationDate = CreationDate,
    //        ModifiedBy = ModifiedBy,
    //        CreatedBy = CreatedBy
    //    };

    //    try
    //    {
    //        var response = BussinessFactory.GetSessionService().Save(Session);

    //        if (response.OperationResult == OperationResult.Success)
    //        {
    //            Response.Redirect("~/Derma/Admin/ListSessions.aspx", true);
    //        }
    //        else
    //        {
    //            litMensaje.Text = string.Format("No se puedo crear El Tipo de Persona");
    //        }
    //    }
    //    catch (Exception e)
    //    {
    //        throw e;
    //    }

    //}
    private void Update()
    {
        var Id = Request.QueryString.Get("id");
        var Session = BussinessFactory.GetSessionService().Get(new Guid(Id));
        if (Session != null)
        {
           
            Session.Description = txtDescription.Text.Trim();
            Session.Price = Convert.ToDecimal(txtPrice.Text.Trim());
            Session.Currency = ddlCurrency.SelectedValue;
            Session.IsActive = true;
            Session.LastModified = LastModified;
            Session.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetSessionService().Update(Session);
            if (response.OperationResult == OperationResult.Success)
            {
                //Response.Redirect("~/Derma/Admin/EditMedication.aspx", true);

                Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", Session.Medication.Id), true);
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
            //case "new":
            //    Save();
            //    break;
            case "edit":
                Update();
                break;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        //Response.Redirect("~/Derma/Admin/EditMedication.aspx", true);
        var Id = Request.QueryString.Get("id");
        var Session = BussinessFactory.GetSessionService().Get(new Guid(Id));
        Response.Redirect(string.Format("EditMedication.aspx?id={0}&action=edit", Session.Medication.Id), true);
    }
}