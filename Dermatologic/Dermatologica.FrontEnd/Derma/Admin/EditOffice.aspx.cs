﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditOffice : PageBase
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
        var office = BussinessFactory.GetOfficeService().Get(id);
        txtName.Text = office.Name;
        txtDescription.Text = office.Description;
    }

    private void Save()
    {
        var PersonType = new Office()
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
            var response = BussinessFactory.GetOfficeService().Save(PersonType);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListOffices.aspx", true);
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
        var office = BussinessFactory.GetOfficeService().Get(new Guid(Id));
        if (office != null)
        {
            office.Name = txtName.Text.Trim();
            office.Description = txtDescription.Text.Trim();
            office.IsActive = true;
            office.LastModified = LastModified;
            office.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetOfficeService().Update(office);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListOffices.aspx", true);
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
        Response.Redirect("~/Derma/Admin/ListOffices.aspx", true);
    }
}