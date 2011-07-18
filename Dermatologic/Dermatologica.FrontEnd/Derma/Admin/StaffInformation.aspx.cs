using System;
using System.Linq;
using System.Web.UI.WebControls;
using ASP.App_Code;
//using Invoice = Dermatologic.Domain.Invoice;
using Dermatologic.Domain;
using Dermatologic.Services;

public partial class Derma_Admin_StaffInformation : PageBase
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            LoadCostCenter();
            LoadEmployeeType();
            LoadTypeContract();

            var idPerson = Request.QueryString.Get("id");
            if (!string.IsNullOrEmpty(idPerson))
            {
                LoadStaffInformation(new Guid(idPerson));
            }
        }
    }
    private void LoadCostCenter()
    {
        var types = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        BindControl<CostCenter>.BindDropDownList(ddlCostCenter, types);
    }
    private void LoadEmployeeType()
    {
        var types = BussinessFactory.GetEmployeeTypeService().GetAll(p => p.IsActive);
        BindControl<EmployeeType>.BindDropDownList(ddlEmployeeType, types);
    }
    private void LoadTypeContract()
    {
        var types = BussinessFactory.GetTypeContractService().GetAll(p => p.IsActive);
        BindControl<TypeContract>.BindDropDownList(ddlTypeContract, types);
    }
    private void LoadStaffInformation(Guid? idPerson)
    {
        var entity = BussinessFactory.GetStaffInformationService().Get(idPerson);
        if (entity != null)
        {
            txtJoinDate.Text = Convert.ToString(entity.JoinDate);
            txtNetMonthlySalary.Text = Convert.ToString(entity.NetMonthlySalary);
            txtOvertimePay.Text = Convert.ToString(entity.OvertimePay);
            ddlEmployeeType.SelectedValue = Convert.ToString(entity.EmployeeType.Id);
            ddlTypeContract.SelectedValue = Convert.ToString(entity.TypeContract.Id);
            ddlCostCenter.SelectedValue = Convert.ToString(entity.CostCenter.Id);
        }

    }
    private void Save()
    {
        var idPerson = Request.QueryString.Get("id");
        var employee = BussinessFactory.GetStaffInformationService().Get(new Guid(idPerson));
        if (employee != null)
        {
            employee.JoinDate = !string.IsNullOrEmpty(txtJoinDate.Text)
                                          ? Convert.ToDateTime(txtJoinDate.Text)
                                          : (DateTime?)null;
            employee.NetMonthlySalary = Convert.ToDecimal(txtNetMonthlySalary.Text);
            employee.OvertimePay = Convert.ToDecimal(txtOvertimePay.Text);
            employee.EmployeeType = BussinessFactory.GetEmployeeTypeService().Get(new Guid(ddlEmployeeType.SelectedValue));
            employee.TypeContract = BussinessFactory.GetTypeContractService().Get(new Guid(ddlTypeContract.SelectedValue));
             employee.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue));
       
              var response = BussinessFactory.GetStaffInformationService().Update(employee);
            if (response.OperationResult == OperationResult.Success)
            {
                Response.Redirect("~/Derma/Admin/Staff.aspx", true);
            }
            else
            {
                litMensajes.Text = string.Format("No se puedo guardar -> Error : {0}", response.Message);
            }
        }
        else
        {
         var info = new StaffInformation
                           {                                                                                         
                               Id =new Guid(idPerson),
                               JoinDate = !string.IsNullOrEmpty(txtJoinDate.Text) ? Convert.ToDateTime(txtJoinDate.Text) : (DateTime?)null,
                               NetMonthlySalary = Convert.ToDecimal(txtNetMonthlySalary.Text),
                               OvertimePay = Convert.ToDecimal(txtOvertimePay.Text),
                               EmployeeType = BussinessFactory.GetEmployeeTypeService().Get(new Guid(ddlEmployeeType.SelectedValue)),
                               TypeContract = BussinessFactory.GetTypeContractService().Get(new Guid(ddlTypeContract.SelectedValue)),
                               CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue)),


                               IsActive = true,
                               LastModified = LastModified,
                               CreationDate = CreationDate,
                               ModifiedBy = ModifiedBy,
                               CreatedBy = CreatedBy
                           };
         var response = BussinessFactory.GetStaffInformationService().Save(info);
         if (response.OperationResult == OperationResult.Success)
         {
             Response.Redirect("~/Derma/Admin/Staff.aspx", true);
         }
         else
         {
             litMensajes.Text = string.Format("No se puedo guardar -> Error : {0}", response.Message);
         }

        }
    }
    protected void btnAceptar_Click(object sender, EventArgs e)
    {
        Save();
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Derma/Admin/ListPatients.aspx", true);
    }
}