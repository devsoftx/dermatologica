﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using ExchangeRate = Dermatologic.Domain.ExchangeRate;

public partial class Derma_Admin_ListExchangeRates : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetExchangeRates();
    }
    protected void gvExchangeRates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        switch (e.CommandName)
        {
            case "cmd_editar":
                var id = new Guid(e.CommandArgument.ToString());
                Response.Redirect(string.Format("EditExchangeRate.aspx?id={0}&action=edit", id), true);
                break;
            case "cmd_eliminar":
                DeleteExchangeRate(new Guid(e.CommandArgument.ToString()));
                GetExchangeRates();
                break;

        }
    }
    
    private void GetExchangeRates()
    {    
        var response = BussinessFactory.GetExchangeRateService().GetAll(u => u.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var exchangeRates = response.Results;
            BindControl<ExchangeRate>.BindGrid(gvExchangeRates, exchangeRates);    
        }
    }
   
    private void DeleteExchangeRate(Guid id)
    {
        var responseExchangeRate = BussinessFactory.GetExchangeRateService().Get(id);
        if (responseExchangeRate.OperationResult == OperationResult.Success)
        {
            var exchangeRate = responseExchangeRate.Entity;
            exchangeRate.IsActive = false;
            exchangeRate.LastModified = LastModified;
            exchangeRate.ModifiedBy = ModifiedBy;
            var response = BussinessFactory.GetExchangeRateService().Update(exchangeRate);
            if (response.OperationResult == OperationResult.Success)
            {
                litMensaje.Text = string.Format("Se eliminó tipo de cambio");
                return;
            }
        }
    }
    protected void lnkNew_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/EditExchangeRate.aspx?action=new");
    }

    protected void btnSearch_Click(object sender, EventArgs e)
    {
        var dateStart = Convert.ToDateTime(txtStartDate.Text.Trim());
        var dateEnd = Convert.ToDateTime(txtEndDate.Text.Trim());
        var response = BussinessFactory.GetExchangeRateService().GetExchangeRateByDates(dateStart,dateEnd);
        if (response.OperationResult == OperationResult.Success)
        {
            gvExchangeRates.DataSource = response.Results;
            gvExchangeRates.DataBind();
        }
    }
}