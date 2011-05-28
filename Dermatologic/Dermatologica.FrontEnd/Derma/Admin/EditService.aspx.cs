using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Service = Dermatologic.Domain.Service;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditService : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetService();
        }
    }
    private void SetService()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadService(new Guid(id));
                break;
        }
    }
    void LoadService(Guid id)
    {
        var Service = BussinessFactory.GetServiceService().Get(id);
        txtName.Text = Service.Name;
        txtDescription.Text = Service.Description;
    }

    private void Save()
    {
        var Service = new Service
        {
            Id = Guid.NewGuid(),
            Name = txtName.Text.Trim(),
            Description = txtDescription.Text.Trim(),
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };

        try
        {
            var response = BussinessFactory.GetServiceService().Save(Service);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListServices.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo crear El Tipo de Persona");
            }
        }
        catch (Exception e)
        {
            throw e;
        }

    }
    private void Update()
    {
        var Id = Request.QueryString.Get("id");
        var Service = BussinessFactory.GetServiceService().Get(new Guid(Id));
        if (Service != null)
        {
            Service.Name = txtName.Text.Trim();
            Service.Description = txtDescription.Text.Trim();
            Service.IsActive = true;
            Service.LastModified = LastModified;
            Service.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetServiceService().Update(Service);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListServices.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el Tipo de Persona");
            }
        }
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        var action = Request.QueryString.Get("action");
        switch (action)
        {
            case "new":
                Save();
                break;
            case "edit":
                Update();
                break;
        }
    }

    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListServices.aspx", true);
    }
}