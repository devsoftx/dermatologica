using System;
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
        var personTypes = BussinessFactory.GetPersonTypeService().GetAll();
        BindControl<PersonType>.BindDropDownList(dwTipoPersona,personTypes);
    }

    void LoadPerson(Guid id)
    {
        var Person = BussinessFactory.GetPersonService().Get(id);
        txtNombres.Text = Person.FirstName;
        txtApellidos.Text = Person.LastName;
        txtTelefono.Text = Person.Phone;
        txtTelefonoEmergencia.Text = Person.EmergencyPhone;
        txtNumeroDocumento.Text = Person.DocumentNumber;
        txtCelular.Text = Person.CellPhone;
        txtEmail.Text = Person.Email;
        txtFechaCumpleaños.Text = Person.DateBirthDay.Value.ToShortDateString();
        dwTipoPersona.SelectedValue = Person.PersonType.Id.ToString();
        txtDireccion.Text = Person.Address;
    }
    
    private void Save()
    {
        var Person = new Person
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
            EmergencyPhone = txtTelefonoEmergencia.Text.Trim(),
            Address = txtDireccion.Text.Trim(),
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };
        Person.PersonType = new PersonType() {Id = new Guid(dwTipoPersona.SelectedValue)};
        try
        {
            
            var response = BussinessFactory.GetPersonService().Save(Person);
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
        var Id = Request.QueryString.Get("id");
        var Person = BussinessFactory.GetPersonService().Get(new Guid(Id));
        if (Person != null)
        {
            Person.FirstName = txtNombres.Text.Trim();
            Person.LastName = txtApellidos.Text.Trim();
            Person.DocumentType = dwTipoPersona.SelectedValue;
            Person.DocumentNumber = txtNumeroDocumento.Text.Trim();
            Person.PersonType.Id = new Guid(dwTipoPersona.SelectedValue);
            Person.Phone = txtTelefono.Text.Trim();
            Person.EmergencyPhone = txtTelefonoEmergencia.Text.Trim();
            Person.CellPhone = txtCelular.Text.Trim();
            Person.Address = txtDireccion.Text.Trim();
            Person.LastModified = LastModified;
            Person.ModifiedBy = ModifiedBy;
            Person.Email = txtEmail.Text.Trim();
            Person.DateBirthDay = Convert.ToDateTime(txtFechaCumpleaños.Text.Trim());
            Person.IsActive = true;
            Person.LastModified = LastModified;
            Person.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetPersonService().Update(Person);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListPersons.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar la Persona -> {0}", response.Message);
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