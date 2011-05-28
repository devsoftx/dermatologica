using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using PersonType = Dermatologic.Domain.PersonType;
using Dermatologic.Domain;
using Dermatologic.Services;
public partial class Derma_Admin_EditPersonType : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetPersonType();
        }
    }
    private void SetPersonType()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadPersonType(new Guid(id));
                break;
        }
    }
    void LoadPersonType(Guid id)
    {
        var PersonType = BussinessFactory.GetPersonTypeService().Get(id);
        txtName.Text = PersonType.Name;
        txtDescription.Text = PersonType.Description;
    }

    private void Save()
    {
        var PersonType = new PersonType
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
            var response = BussinessFactory.GetPersonTypeService().Save(PersonType);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPersonTypes.aspx", true);
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
        var PersonType = BussinessFactory.GetPersonTypeService().Get(new Guid(Id));
        if (PersonType != null)
        {
            PersonType.Name = txtName.Text.Trim();
            PersonType.Description = txtDescription.Text.Trim();
            PersonType.IsActive = true;
            PersonType.LastModified = LastModified;
            PersonType.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetPersonTypeService().Update(PersonType);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPersonTypes.aspx", true);
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
        Response.Redirect("~/Derma/Admin/ListPersonTypes.aspx", true);
    }
}