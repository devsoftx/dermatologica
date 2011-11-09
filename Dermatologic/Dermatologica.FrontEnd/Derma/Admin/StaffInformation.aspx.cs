using System;
using System.Linq;
using System.Web.UI.WebControls;
using Dermatologica.Web;
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
        var response = BussinessFactory.GetCostCenterService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<CostCenter>.BindDropDownList(ddlCostCenter, types);    
        }
        
    }

    private void LoadEmployeeType()
    {
        var response = BussinessFactory.GetEmployeeTypeService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<EmployeeType>.BindDropDownList(ddlEmployeeType, types);   
        }
    }

    private void LoadTypeContract()
    {
        var response = BussinessFactory.GetTypeContractService().GetAll(p => p.IsActive);
        if (response.OperationResult == OperationResult.Success)
        {
            var types = response.Results;
            BindControl<TypeContract>.BindDropDownList(ddlTypeContract, types);
        }
    }

    private void LoadStaffInformation(Guid? idPerson)
    {
        var response = BussinessFactory.GetStaffInformationService().Get(idPerson);
        if (response.OperationResult == OperationResult.Success && response.Entity != null)
        {
            var entity = response.Entity;
            if (entity.JoinDate != null) txtJoinDate.Text = entity.JoinDate.Value.ToShortDateString();
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
        var responseEmployee = BussinessFactory.GetStaffInformationService().Get(new Guid(idPerson));
        if (responseEmployee.Entity != null)
        {
            var employee = responseEmployee.Entity;
            employee.JoinDate = !string.IsNullOrEmpty(txtJoinDate.Text)
                                          ? Convert.ToDateTime(txtJoinDate.Text)
                                          : (DateTime?)null;
            employee.NetMonthlySalary = Convert.ToDecimal(txtNetMonthlySalary.Text);
            employee.OvertimePay = Convert.ToDecimal(txtOvertimePay.Text);
            employee.EmployeeType = BussinessFactory.GetEmployeeTypeService().Get(new Guid(ddlEmployeeType.SelectedValue)).Entity;
            employee.TypeContract = BussinessFactory.GetTypeContractService().Get(new Guid(ddlTypeContract.SelectedValue)).Entity;
            employee.CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue)).Entity;
            var response = BussinessFactory.GetStaffInformationService().Update(employee);
            if (response.OperationResult == OperationResult.Success)
            {
                BussinessFactory.EngineService.Navigate(Dermatologic.Services.Page.Staff);
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
                               EmployeeType = BussinessFactory.GetEmployeeTypeService().Get(new Guid(ddlEmployeeType.SelectedValue)).Entity,
                               TypeContract = BussinessFactory.GetTypeContractService().Get(new Guid(ddlTypeContract.SelectedValue)).Entity,
                               CostCenter = BussinessFactory.GetCostCenterService().Get(new Guid(ddlCostCenter.SelectedValue)).Entity,
                               IsActive = true,
                               LastModified = LastModified,
                               CreationDate = CreationDate,
                               ModifiedBy = ModifiedBy,
                               CreatedBy = CreatedBy
                           };
         var response = BussinessFactory.GetStaffInformationService().Save(info);
         if (response.OperationResult == OperationResult.Success)
         {
             BussinessFactory.EngineService.Navigate(Dermatologic.Services.Page.Staff);
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
        BussinessFactory.EngineService.Navigate(Dermatologic.Services.Page.Staff);
    }
}