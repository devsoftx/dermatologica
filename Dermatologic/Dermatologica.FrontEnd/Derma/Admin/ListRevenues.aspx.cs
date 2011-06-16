using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Invoice = Dermatologic.Domain.Invoice;
using CostCenter = Dermatologic.Domain.CostCenter;
public partial class Derma_Admin_ListRevenues : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
        }
        //GetPayments();
    }
    private void GetPayments()
    {
        //var Payments = BussinessFactory.GetService().GetAll(u => u.IsActive == true);
        //BindControl<Payment>.BindGrid(gvRevenues, Payments);
    }
    private void LoadCostCenter()
    {
        var types = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        BindControl<CostCenter>.BindDropDownList(ddlCostCenter, types);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {
        SearchPayments();
    }
    private void SearchPayments()
    {
        //var personType = Request.QueryString.Get("personType");
        var example = new Invoice
        {
            MPayment = ddlMPayment.SelectedValue,
            Currency = ddlCurrency.SelectedValue,
            InvoiceType = ddlInvoice.SelectedValue,
        };
     

       example.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue));

        var response = BussinessFactory.GetInvoiceService().GetRevenuesByParams(example);
        if (response.OperationResult == OperationResult.Success)
        {
            gvRevenues.DataSource = response.Invoices;
            gvRevenues.DataBind();
        }
    }
}