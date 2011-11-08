using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dermatologica.Web;
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
        var response = BussinessFactory.GetPersonTypeService().Get(id);
        if (response.OperationResult == OperationResult.Success)
        {
            var personType = response.Entity;
            txtName.Text = personType.Name;
            txtDescription.Text = personType.Description;   
        }
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
        var id = Request.QueryString.Get("id");
        var responsePersonType = BussinessFactory.GetPersonTypeService().Get(new Guid(id));
        if (responsePersonType.OperationResult == OperationResult.Success)
        {
            var personType = responsePersonType.Entity;
            personType.Name = txtName.Text.Trim();
            personType.Description = txtDescription.Text.Trim();
            personType.IsActive = true;
            personType.LastModified = LastModified;
            personType.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetPersonTypeService().Update(personType);
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