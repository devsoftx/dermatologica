using System;

namespace Dermatologic.Services
{
    public abstract class AbstractServiceFactory
    {
        public static Type SERVICE_FACTORY = typeof(ServiceFactory);

        public static ServiceFactory Instance(Type factory)
        {
            try
            {
                return (ServiceFactory)Activator.CreateInstance(factory);

            }
            catch (Exception ex)
            {
                throw new Exception("No se crear Factory de Servicios:" + ex.Message);
            }
        }

        public abstract IOfficeService GetOfficeService();

        public abstract IAppointmentService GetAppointmentService();

        public abstract IServiceService GetServiceService();

        public abstract IMedicalCareService GetMedicalCareService();

        public abstract IMenuService GetMenuService();

        public abstract ISessionService GetSessionService();

        public abstract IUbigeoService GetUbigeoService();

        public abstract IMenuRoleService GetMenuRoleService();

        public abstract IRoleService GetRoleService();

        public abstract IUsersInRolesService GetUsersInRolesService();

        public abstract IUsersService GetUsersService();

        public abstract IMedicationService GetMedicationService();

        public abstract IRateService GetRateService();

        public abstract ISupplyService GetSupplyService();

        public abstract IMailerService GetMailerService();

        public abstract IPersonService GetPersonService();

        public abstract IPersonTypeService GetPersonTypeService();

        public abstract IExchangeRateService GetExchangeRateService();

        public abstract IAccountService GetAccountService();

        public abstract ICostCenterService GetCostCenterService();

        public abstract IInvoiceService GetInvoiceService();

        public abstract ICashMovementService GetCashMovementService();

        public abstract IPatientInformationService GetPatientInformationService();

        public abstract IStaffInformationService GetStaffInformationService();

        public abstract IEmployeeTypeService GetEmployeeTypeService();

        public abstract ITypeContractService GetTypeContractService();

        public abstract IWebEngineService EngineService { get; }
    
    }
}