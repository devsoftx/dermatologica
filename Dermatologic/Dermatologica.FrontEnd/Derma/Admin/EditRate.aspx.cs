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
            LoadCostCenter();
        }
        ucSearchPersonsMedical.PersonTypeControlName = ddlPersonType.ClientID;
    }

    private void LoadCostCenter()
    {
        var response = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var costcenters = response.Results;
            BindControl<CostCenter>.BindDropDownList(dwCostCenter, costcenters);
            if (!string.IsNullOrEmpty(dwCostCenter.SelectedValue))
                LoadServices(new Guid(dwCostCenter.SelectedValue));
        }
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

    private void LoadRate(Guid id)
    {
        var response = BussinessFactory.GetRateService().Get(id);
        if (response.OperationResult == OperationResult.Success)
        {
            var rate = response.Entity;
            ddlCurrency.SelectedValue = rate.Currency;
            txtUnitCost.Text = rate.UnitCost.ToString();
            txtObservation.Text = rate.Observation;
            ucSearchPersonsMedical.SelectedValue = Convert.ToString(rate.Person.PersonType.Id);
            ddlPersonType.SelectedValue = Convert.ToString(rate.Person.PersonType.Id);
            ucSearchPersonsMedical.Text = rate.Person.CompleteName;
        }
    }

    private void LoadPersonType()
    {
        var response = BussinessFactory.GetPersonTypeService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<PersonType>.BindDropDownList(ddlPersonType, types);   
        }
    }

    private void LoadServices(Guid costCenterId)
    {
        var response = BussinessFactory.GetServiceService().GetAll(p => p.IsActive && p.CostCenter.Id == costCenterId);
        if(response.OperationResult == OperationResult.Success)
        {
            var services = response.Results.OrderBy(p => p.Name).ToList();
            BindControl<Service>.BindDropDownList(ddlService, services);   
        }
    }

    protected void ddlPersonType_SelectedIndexChanged(object sender, EventArgs e)
    {
        ucSearchPersonsMedical.SelectedValue = string.Empty;
        ucSearchPersonsMedical.Text = string.Empty;
    }

    private void Save()
    {
        if (string.IsNullOrEmpty(txtUnitCostPartner.Text))
        {
            txtUnitCostPartner.Text = "0";
        }
        var responseMedical = BussinessFactory.GetPersonService().Get(new Guid(ucSearchPersonsMedical.SelectedValue));
        Person medical = null;
        if (responseMedical.OperationResult == OperationResult.Success)
            medical = responseMedical.Entity;

        var Rate = new Rate
        {
            Id = Guid.NewGuid(),
            Currency = ddlCurrency.SelectedValue,
            UnitCost = Convert.ToDecimal(txtUnitCost.Text.Trim()),
            UnitCostPartner = Convert.ToDecimal(txtUnitCostPartner.Text.Trim()),
            Observation = txtObservation.Text.Trim(),
            Person = medical,
            Service = BussinessFactory.GetServiceService().Get(new Guid(ddlService.SelectedValue)).Entity,
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
        var responseRate = BussinessFactory.GetRateService().Get(new Guid(Id));
        if (responseRate.OperationResult == OperationResult.Success)
        {
            var rate = responseRate.Entity;
            rate.Currency = ddlCurrency.SelectedValue;
            rate.UnitCost = Convert.ToDecimal(txtUnitCost.Text.Trim());
            rate.UnitCostPartner = Convert.ToDecimal(txtUnitCostPartner.Text.Trim());
            rate.Observation = txtObservation.Text.Trim();
            rate.IsActive = true;
            rate.LastModified = LastModified;
            rate.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetRateService().Update(rate);
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

    protected void dwCostCenter_SelectedIndexChanged(object sender, EventArgs e)
    {
        var idCostCenter = dwCostCenter.SelectedValue;
        LoadServices(new Guid(idCostCenter));
    }
}