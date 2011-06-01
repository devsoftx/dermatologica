﻿using System;
using System.Linq;
using System.Linq.Expressions;
using ASP.App_Code;
using Person = Dermatologic.Domain.Person;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditPerson : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            GetPersonTypes();
            SetPerson();
        }
    }

    private void SetPerson()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadPerson(new Guid(id));
                break;
        }
    }

    private void GetPersonTypes()
    {
        var personTypes = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive).OrderBy(u => u.Name).ToList();
        BindControl<PersonType>.BindDropDownList(dwTipoPersona,personTypes);
    }

    private void LoadPerson(Guid id)
    {
        var person = BussinessFactory.GetPersonService().Get(id);
        txtNombres.Text = person.FirstName;
        txtApellidos.Text = person.LastName;
        txtTelefono.Text = person.Phone;
        txtTelefonoEmergencia.Text = person.EmergencyPhone;
        txtNumeroDocumento.Text = person.DocumentNumber;
        txtCelular.Text = person.CellPhone;
        txtEmail.Text = person.Email;
        txtFechaCumpleaños.Text = person.DateBirthDay.Value.ToShortDateString();
        dwTipoPersona.SelectedValue = person.PersonType.Id.ToString();
        txtDireccion.Text = person.Address;
    }
    
    private void Save()
    {
        var person = new Person
        {
            Id = Guid.NewGuid(),
            FirstName = txtNombres.Text.Trim(),
            LastName = txtApellidos.Text.Trim(),
            DateBirthDay = Convert.ToDateTime(txtFechaCumpleaños.Text.Trim()),
            DocumentType = dwTipoDocumento.SelectedValue,
            DocumentNumber = txtNumeroDocumento.Text.Trim(),
            Phone = txtTelefono.Text.Trim(),
            CellPhone = txtCelular.Text.Trim(),
            Email = txtEmail.Text.Trim(),
            PersonType = BussinessFactory.GetPersonTypeService().Get(new Guid(dwTipoPersona.SelectedValue)),
            EmergencyPhone = txtTelefonoEmergencia.Text.Trim(),
            Address = txtDireccion.Text.Trim(),
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };
        try
        {
            var response = BussinessFactory.GetPersonService().Save(person);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPersons.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo crear La Persona");
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
        var person = BussinessFactory.GetPersonService().Get(new Guid(id));
        if (person != null)
        {
            person.FirstName = txtNombres.Text.Trim();
            person.LastName = txtApellidos.Text.Trim();
            person.DocumentType = dwTipoPersona.SelectedValue;
            person.DocumentNumber = txtNumeroDocumento.Text.Trim();
            person.PersonType = BussinessFactory.GetPersonTypeService().Get(new Guid(dwTipoPersona.SelectedValue));
            person.Phone = txtTelefono.Text.Trim();
            person.EmergencyPhone = txtTelefonoEmergencia.Text.Trim();
            person.CellPhone = txtCelular.Text.Trim();
            person.Address = txtDireccion.Text.Trim();
            person.LastModified = LastModified;
            person.ModifiedBy = ModifiedBy;
            person.Email = txtEmail.Text.Trim();
            person.DateBirthDay = Convert.ToDateTime(txtFechaCumpleaños.Text.Trim());
            person.IsActive = true;
            person.LastModified = LastModified;
            person.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetPersonService().Update(person);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPersons.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar la Persona -> {0} ", response.Message);
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
        Response.Redirect("~/Derma/Admin/ListPersons.aspx", true);
    }
}