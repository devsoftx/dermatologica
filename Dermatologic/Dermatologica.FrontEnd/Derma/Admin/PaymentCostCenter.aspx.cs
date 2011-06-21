using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
using Invoice = Dermatologic.Domain.Invoice;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_PaymentCostCenter : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
            SetPayment();
            
        }
    }
    private void SetPayment()
    {
        if (CreationDate != null) txtDatePayment.Text = CreationDate.Value.ToShortDateString();
        var List = BussinessFactory.GetExchangeRateService().GetAll().Where(p => p.DateRate.ToShortDateString().Equals(DateTime.Now.ToShortDateString())).ToList();
        var echangeToday = List.OrderBy(p => p.CreationDate).FirstOrDefault();
        if (echangeToday != null)
        {
            txtCompra.Text = echangeToday.Buy.ToString();
            txtVenta.Text = echangeToday.Sale.ToString();
            txtName.Text = "Pago de Honorarios";
        }
    }

    private void LoadCostCenter()
    {
        var types = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        BindControl<CostCenter>.BindDropDownList(ddlDebtorCostCenter, types);
        BindControl<CostCenter>.BindDropDownList(ddlCreditorCostCenter, types);
    }
    private void Save()
    {

        var Invoice1 = new Invoice
        {
            Id = Guid.NewGuid(),
            Name = txtName.Text.Trim(),
            Description = txtName.Text.Trim(),
            DatePayment = Convert.ToDateTime(CreationDate),
            MPayment = ddlMPayment.SelectedValue,
            InvoiceType = ddlInvoice.SelectedValue,
            NInvoice = txtNInvoice.Text.Trim(),
            Currency = ddlCurrency.SelectedValue,
            Amount = Convert.ToDecimal(txtAmount.Text),
            ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
            Movement = "Egreso",
            IsActive = true,

            MedicalCare = null,
            CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlDebtorCostCenter.SelectedValue)),
            Personal = null,
            Patient = null,
            Session = null,

            LastModified = LastModified,
            CreationDate = CreationDate,
            ModifiedBy = ModifiedBy,
            CreatedBy = CreatedBy,
        };           

                var CashMovement1 = new CashMovement
                {
                    Id = Guid.NewGuid(),
                    CostCenter = Invoice1.CostCenter,
                    Invoice = Invoice1,
                    MPayment = ddlMPayment.SelectedValue,
                    Date = Convert.ToDateTime(CreationDate),
                    EmissionAmount = Invoice1.Amount,
                    Amount = Invoice1.Amount,
                    Factor = -1,
                    Currency = ddlCurrency.SelectedValue,
                    ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                    IsActive = true,
                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                };
                var Invoice2 = new Invoice
                {
                    Id = Guid.NewGuid(),
                    Name = txtName.Text.Trim(),
                    Description = txtName.Text.Trim(),
                    DatePayment = Convert.ToDateTime(CreationDate),
                    MPayment = ddlMPayment.SelectedValue,
                    InvoiceType = ddlInvoice.SelectedValue,
                    NInvoice = txtNInvoice.Text.Trim(),
                    Currency = ddlCurrency.SelectedValue,
                    Amount = Convert.ToDecimal(txtAmount.Text),
                    ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                    Movement = "Ingreso",
                    IsActive = true,

                    MedicalCare = null,
                    CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCreditorCostCenter.SelectedValue)),
                    Personal = null,
                    Patient = null,
                    Session = null,

                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                };
                var CashMovement2 = new CashMovement
                {
                    Id = Guid.NewGuid(),
                    CostCenter = Invoice2.CostCenter,
                    Invoice = Invoice2,
                    MPayment = ddlMPayment.SelectedValue,
                    Date = Convert.ToDateTime(CreationDate),
                    EmissionAmount = Invoice2.Amount,
                    Amount = Invoice2.Amount,
                    Factor = 1,
                    Currency = ddlCurrency.SelectedValue,
                    ExchangeRate = Convert.ToDecimal(txtVenta.Text.Trim()),
                    IsActive = true,
                    LastModified = LastModified,
                    CreationDate = CreationDate,
                    ModifiedBy = ModifiedBy,
                    CreatedBy = CreatedBy,
                };

                Invoice1.CashMovements.Add(CashMovement1);
                Invoice2.CashMovements.Add(CashMovement2);
                try
                {
                    var response1 = BussinessFactory.GetInvoiceService().Save(Invoice1);
                    var response2 = BussinessFactory.GetInvoiceService().Save(Invoice2);
                    if (response1.OperationResult == OperationResult.Success & response2.OperationResult == OperationResult.Success)
                    {
                        
                        litMensaje.Text = string.Format("Se Guardó Correctamente");
                    }
                    else
                    {
                        litMensaje.Text = string.Format("No se pudo Guardar el Pago {0}", response1.Message);
                    }
                }
                catch (Exception e)
                {
                    throw e;
                }
            
    }

    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        if (Convert.ToDecimal(txtAmount.Text) != 0 & string.IsNullOrEmpty(txtVenta.Text))
        {
            litMensaje.Text = string.Format("No se ha Ingresado el Tipo de Cambio del día");
            Response.Redirect(string.Format("~/Derma/Admin/EditExchangeRate.aspx?action=new&returnUrl={0}",
                                            Page.Request.RawUrl));
        }
        if (Convert.ToDecimal(txtAmount.Text) == 0 )
        {
            litMensaje.Text = string.Format("El Monto a Pagar No puede Ser Cero");
            return;
        }
        Save();
    }
}