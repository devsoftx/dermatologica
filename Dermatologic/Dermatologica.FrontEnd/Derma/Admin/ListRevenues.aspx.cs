using System;
using System.Activities.Statements;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Domain;
using Dermatologic.Services;
public partial class Derma_Admin_ListRevenues : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
            var movement = Request.QueryString.Get("Movement");
            if(!string.IsNullOrEmpty(movement))
                lblTitle.Text = string.Format("Listado de {0}s", movement);
        }
        GetPayments();
    }

    private void GetPayments()
    {
        var movement = Request.QueryString.Get("Movement");
        if (!string.IsNullOrEmpty(movement))
        {
            var invoices = BussinessFactory.GetInvoiceService().GetAll(p => p.IsActive && p.Movement == movement);
            BindControl<Invoice>.BindGrid(gvRevenues, new List<Invoice>(invoices));
        }
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
        var example = new Invoice
                          {
                              MPayment = ddlMPayment.SelectedValue,
                              Currency = ddlCurrency.SelectedValue,
                              InvoiceType = ddlInvoice.SelectedValue,
                              CostCenter =
                                  BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue))
                          };

        var movement = Request.QueryString.Get("Movement");
        var response = new InvoiceResponse();
        if (!string.IsNullOrEmpty(movement))
        {
            switch (movement)
            {
                case "Ingreso":
                    response = BussinessFactory.GetInvoiceService().GetRevenuesByParams(example);
                    break;
                case "Egreso":
                    response = BussinessFactory.GetInvoiceService().GetExpensesByParams(example);
                    break;
                default:
                    break;

            }
            if (response.OperationResult == OperationResult.Success)
            {
                gvRevenues.DataSource = response.Invoices;
                gvRevenues.DataBind();
            }
        }
    }

    protected void gvRevenues_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            var entity = e.Row.DataItem as Invoice;
            if (entity != null)
            {
                var movement = Request.QueryString.Get("Movement");
                if (!string.IsNullOrEmpty(movement))
                {
                    var literal = ((Literal) e.Row.FindControl("litPersona"));
                    switch (movement)
                    {
                        case "Ingreso":
                            literal.Text = string.Format("{0} {1} {2}", entity.Patient.FirstName, entity.Patient.LastNameP, entity.Patient.LastNameM);
                            break;
                        case "Egreso":
                            literal.Text = string.Format("{0} {1} {2}", entity.Personal.FirstName, entity.Personal.LastNameP, entity.Personal.LastNameM);
                            break;
                        default:
                            literal.Text = string.Empty;
                            break;
                    }
                }
            }
        }
    }
}