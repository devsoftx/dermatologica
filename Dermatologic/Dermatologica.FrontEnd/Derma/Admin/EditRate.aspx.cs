using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Rate = Dermatologic.Domain.Rate;
using PersonType = Dermatologic.Domain.PersonType;
using Service = Dermatologic.Domain.Service;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditRatet : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            SetRate();
            LoadPersonType();
            LoadServices();
        }
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }
    private void SetRate()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadRate(new Guid(id));
                break;
        }
    }
    void LoadRate(Guid id)
    {
        var Rate = BussinessFactory.GetRateService().Get(id);
        ddlCurrency.SelectedValue = Rate.Currency;
        txtUnitCost.Text = Rate.UnitCost.ToString();
        txtObservation.Text = Rate.Observation;

    }
    private void LoadPersonType()
    {
        var types = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        BindControl<PersonType>.BindDropDownList(ddlPersonType, types);
    }
    private void LoadServices()
    {
        var services = BussinessFactory.GetServiceService().GetAll().OrderBy(p => p.Name).ToList();
        BindControl<Service>.BindDropDownList(ddlService, services);
       
    }

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }
    private void Save()
    {
        var medical = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));

        var Rate = new Rate
        {
            Id = Guid.NewGuid(),
            Currency = ddlCurrency.SelectedValue,
            UnitCost = Convert.ToDecimal(txtUnitCost.Text.Trim()),
            Observation = txtObservation.Text.Trim(),
            Person=medical,
            Service = BussinessFactory.GetServiceService().Get(new Guid(ddlService.SelectedValue)),
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };

        try
        {
            var response = BussinessFactory.GetRateService().Save(Rate);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListRates.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se pudo crear La Tarifa");
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
        var Rate = BussinessFactory.GetRateService().Get(new Guid(Id));
        if (Rate != null)
        {
            Rate.Currency = ddlCurrency.SelectedValue;
            Rate.UnitCost = Convert.ToDecimal(txtUnitCost.Text.Trim());
            Rate.Observation = txtObservation.Text.Trim();
            Rate.IsActive = true;
            Rate.LastModified = LastModified;
            Rate.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetRateService().Update(Rate);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListRates.aspx", true);
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
        Response.Redirect("~/Derma/Admin/ListRates.aspx", true);
    }
}