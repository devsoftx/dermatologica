using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Dermatologic.Services;
using Payment = Dermatologic.Domain.Payment;
public partial class Derma_Admin_ListRevenues : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack) return;
        GetPayments();
    }
    private void GetPayments()
    {
        var Payments = BussinessFactory.GetPaymentService().GetAll(u => u.IsActive == true);
        BindControl<Payment>.BindGrid(gvRevenues, Payments);
    }
    protected void btnSearch_Click(object sender, EventArgs e)
    {

    }
}