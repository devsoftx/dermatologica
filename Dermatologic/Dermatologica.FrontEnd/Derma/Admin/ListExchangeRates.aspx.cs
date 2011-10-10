using System;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;

public partial class Derma_Admin_ListExchangeRates : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        LoadExchangeRates(GetExchangeRates());
    }
    protected void gvExchangeRates_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName != "Page")
        {
            switch (e.CommandName)
            {
                case "cmd_editar":
                    var id = new Guid(e.CommandArgument.ToString());
                    Response.Redirect(string.Format("EditExchangeRate.aspx?id={0}&action=edit", id), true);
                    break;
                case "cmd_eliminar":
                    DeleteExchangeRate(new Guid(e.CommandArgument.ToString()));
                    LoadExchangeRates(GetExchangeRates());
                    break;
            }   
        }
    }
    
    private ExchangeRateResponse GetExchangeRates()
    {
        DateTime? startDate = null;
        DateTime? endDate = null;
        if (!string.IsNullOrEmpty(txtStartDate.Text))
        {
            var date = Convert.ToDateTime(txtStartDate.Text.Trim());
            startDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        if (!string.IsNullOrEmpty(txtEndDate.Text))
        {
            var date = Convert.ToDateTime(txtEndDate.Text.Trim());
            endDate = new DateTime(date.Year, date.Month, date.Day, 0, 0, 0);
        }
        if (startDate == null)
        {
            var date = DateTime.Now;
            startDate = new DateTime(date.Year, date.Month, 1, 0, 0, 0);
        }
        if (endDate == null)
        {
            var date = DateTime.Now;
            endDate = AppointmentService.GetNroDaysFromMonth(date) > 30
                                       ? new DateTime(date.Year, date.Month, 31, 0, 0, 0)
                                       : new DateTime(date.Year, date.Month, 30, 0, 0, 0);
        }
        return BussinessFactory.GetExchangeRateService().GetExchangeRateByDates(startDate, endDate);
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
        ExchangeRateResponse response = GetExchangeRates();
        LoadExchangeRates(response);
    }

    private void LoadExchangeRates(ExchangeRateResponse response)
    {
        if (response.OperationResult == OperationResult.Success)
        {
            gvExchangeRates.DataSource = response.Results;
            gvExchangeRates.DataBind();
        }
        else
        {
            litMensaje.Text = string.Format("Error: {0}", response.Message);
        }
    }

    protected void gvExchangeRates_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        var response = GetExchangeRates();
        if (response.OperationResult == OperationResult.Success)
        {
            var persons = response.Results;
            gvExchangeRates.DataSource = persons;
            gvExchangeRates.PageIndex = e.NewPageIndex;
            gvExchangeRates.DataBind();
        }
        else
        {
            litMensaje.Text = string.Format("Error: {0}", response.Message);
        }
    }
}