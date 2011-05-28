using System;

namespace Dermatologic.Services
{
    public class ServiceFactory : AbstractServiceFactory
    {
        public override IAppointmentService GetAppointmentService()
        {
            return new AppointmentService();
        }

        public override ITableService GetTableService()
        {
            return new TableService();
        }

        public override IItemTableService GetItemTableService()
        {
            return new ItemTableService();
        }

        public override IServiceService GetServiceService()
        {
            return new ServiceService();
        }

        public override IMedicalCareService GetMedicalCareService()
        {
            return  new MedicalCareService();
        }

        public override IPaymentService GetPaymentService()
        {
            return new PaymentService();
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
    }
}