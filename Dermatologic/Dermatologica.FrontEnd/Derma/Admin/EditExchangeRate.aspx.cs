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

public partial class Derma_Admin_EditExchangeRate : PageBase
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

    public void LoadExchangeRate(Guid id)
    {
        var response = BussinessFactory.GetExchangeRateService().Get(id);
        if (response.OperationResult == OperationResult.Success)
        {
            var exchangeRate = response.Entity;
            txtDateRate.Text = Convert.ToString(exchangeRate.DateRate);
            ddlCurrency.SelectedValue = exchangeRate.Currency;
            txtBuy.Text = Convert.ToString(exchangeRate.Buy);
            txtSale.Text = Convert.ToString(exchangeRate.Sale);
        }
    }

    private void Save()
    {
        var ExchangeRate = new ExchangeRate
        {
            Id = Guid.NewGuid(),
            DateRate = Convert.ToDateTime(txtDateRate.Text),
            Currency = ddlCurrency.SelectedValue,
            Buy = Convert.ToDecimal(txtBuy.Text.Trim()),
            Sale = Convert.ToDecimal(txtSale.Text.Trim()),
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
                var returnUrl = Request.QueryString.Get("returnUrl");
                Response.Redirect(string.IsNullOrEmpty(returnUrl) ? "~/Derma/Admin/ListExchangeRates.aspx" : returnUrl, true);
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
        var responseExchangeRate = BussinessFactory.GetExchangeRateService().Get(new Guid(Id));
        if (responseExchangeRate.OperationResult == OperationResult.Success)
        {
            var exchangeRate = responseExchangeRate.Entity;
            exchangeRate.DateRate = Convert.ToDateTime(txtDateRate.Text);
            exchangeRate.Currency = ddlCurrency.SelectedValue;
            exchangeRate.Buy = Convert.ToDecimal(txtBuy.Text.Trim());
            exchangeRate.Sale = Convert.ToDecimal(txtSale.Text.Trim());
            exchangeRate.LastModified = LastModified;
            exchangeRate.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetExchangeRateService().Update(exchangeRate);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/ListExchangeRates.aspx", false);
            }
            else
            {
                litMensaje.Text = string.Format("No se puedo actualizar el tipo de cambio");
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
        var returnUrl = Request.QueryString.Get("returnUrl");
        Response.Redirect(string.IsNullOrEmpty(returnUrl) ? "~/Derma/Admin/ListExchangeRates.aspx" : returnUrl, true);
    }
}