using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using ExchangeRate = Dermatologic.Domain.ExchangeRate;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_EditExchangeRate :PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (CreationDate != null) txtDateRate.Text = CreationDate.Value.ToShortDateString();
            SetExchangeRate();
        }
    }
    private void SetExchangeRate()
    {
        var action = Request.QueryString.Get("action");
        string id = Request.QueryString.Get("id");
        switch (action)
        {
            case "new":
                break;
            case "edit":
                LoadExchangeRate(new Guid(id));
                break;
        }
    }
    void LoadExchangeRate(Guid id)
    {
        var ExchangeRate = BussinessFactory.GetExchangeRateService().Get(id);
        txtDateRate.Text = Convert.ToString(ExchangeRate.DateRate);
        ddlCurrency.SelectedValue = ExchangeRate.Currency;
        txtBuy.Text = Convert.ToString(ExchangeRate.Buy);
        txtSale.Text = Convert.ToString(ExchangeRate.Sale);
    }

    private void Save()
    {
        var ExchangeRate = new ExchangeRate
        {
            Id = Guid.NewGuid(),
            DateRate = Convert.ToDateTime(txtDateRate.Text),
            Currency= ddlCurrency.SelectedValue,
            Buy=Convert.ToDecimal(txtBuy.Text.Trim()),
            Sale =Convert.ToDecimal(txtSale.Text.Trim()),
            IsActive = true,
            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy
        };

        try
        {
            var response = BussinessFactory.GetExchangeRateService().Save(ExchangeRate);

            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListExchangeRates.aspx", true);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo crear El Tipo de Cambio");
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
        var ExchangeRate = BussinessFactory.GetExchangeRateService().Get(new Guid(Id));
        if (ExchangeRate != null)
        {
              ExchangeRate.DateRate = Convert.ToDateTime(txtDateRate.Text);
             ExchangeRate.Currency= ddlCurrency.SelectedValue;
             ExchangeRate.Buy=Convert.ToDecimal(txtBuy.Text.Trim());
             ExchangeRate.Sale = Convert.ToDecimal(txtSale.Text.Trim());
            
            
            ExchangeRate.IsActive = true;
            ExchangeRate.LastModified = LastModified;
            ExchangeRate.ModifiedBy = ModifiedBy;

            var response = BussinessFactory.GetExchangeRateService().Update(ExchangeRate);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListExchangeRates.aspx", true);
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
        Response.Redirect("~/Derma/Admin/ListExchangeRates.aspx", true);
    }
}