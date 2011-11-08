using System;

namespace Dermatologic.Services
{
    public class ServiceFactory : AbstractServiceFactory
    {
        public override IOfficeService GetOfficeService()
        {
            return new OfficeService();
        }

        public override IAppointmentService GetAppointmentService()
        {
            return new AppointmentService();
        }

        public override IServiceService GetServiceService()
        {
            return new ServiceService();
        }

        public override IMedicalCareService GetMedicalCareService()
        {
            return  new MedicalCareService();
        }

        public override ISessionService GetSessionService()
        {
            return new SessionService();
        }

        public override IUbigeoService GetUbigeoService()
        {
            return new UbigeoService();
        }
        public override IMenuService GetMenuService()
        {
            return new MenuService();
        }

        public override IMenuRoleService GetMenuRoleService()
        {
            return new MenuRoleService();
        }

        public override IUsersInRolesService GetUsersInRolesService()
        {
            return new UsersInRolesService();
        }

        public override IUsersService GetUsersService()
        {
            return new UsersService();
        }

        public override IRoleService GetRoleService()
        {
            return new RoleService();
        }

        public override IMedicationService GetMedicationService()
        {
            return new MedicationService();
        }

        public override IRateService GetRateService()
        {
            return new RateService();
        }

        public override ISupplyService GetSupplyService()
        {
            return new SupplyService();
        }

        public override IMailerService GetMailerService()
        {
            return new MailerService();
        }

        public override IPersonService GetPersonService()
        {
            return new PersonService();
        }

        public override IPersonTypeService GetPersonTypeService()
        {
            return new PersonTypeService();
        }
        public override IExchangeRateService GetExchangeRateService()
        {
            return new ExchangeRateService();
        }

        public override IAccountService GetAccountService()
        {
            return new AccountService();
        }

        public override ICostCenterService GetCostCenterService()
        {
            return new CostCenterService();
        }

        public override IInvoiceService GetInvoiceService()
        {
            return new InvoiceService();
        }

        public override ICashMovementService GetCashMovementService()
        {
            return new CashMovementService();
        }

        public override IPatientInformationService GetPatientInformationService()
        {
            return new PatientInformationService();
        }

        public override IStaffInformationService GetStaffInformationService()
        {
            return new StaffInformationService();
        }

        public override IEmployeeTypeService GetEmployeeTypeService()
        {
            return new EmployeeTypeService();
        }
        public override ITypeContractService GetTypeContractService()
        {
            return new TypeContractService();
        }

        public override IWebEngineService EngineService()
        {
            return new WebEngineService();
        }
    }
}