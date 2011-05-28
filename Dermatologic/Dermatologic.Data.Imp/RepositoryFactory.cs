using System;

namespace Dermatologic.Data
{
    public class RepositoryFactory : AbstractRepositoryFactory
    {
        public override IAppointmentRepository GetAppointmentRepository()
        {
            return new AppointmentRepository();
        }

        public override ITableRepository GetTableRepository()
        {
            return new TableRepository();
        }

        public override IItemTableRepository GetItemTableRepository()
        {
            return new ItemTableRepository();
        }

        public override IMedicalCareRepository GetMedicalCareRepository()
        {
            return new MedicalCareRepository();
        }

        public override IServiceRepository GetServiceRepository()
        {
            return new ServiceRepository();
        }

        public override IPaymentRepository GetPaymentRepository()
        {
            return new PaymentRepository();
        }

        public override ISessionRepository GetSessionRepository()
        {
            return new SessionRepository();
        }

        public override IUbigeoRepository GetUbigeoRepository()
        {
            return new UbigeoRepository();
        }

        public override IMenuRepository GetMenuRepository()
        {
            return  new MenuRepository();
        }

        public override IMenuRoleRepository GetMenuRoleRepository()
        {
            return new MenuRoleRepository();
        }

        public override IUsersInRolesRepository GetUsersInRolesRepository()
        {
            return new UsersInRolesRepository();
        }

        public override IUsersRepository GetUsersRepository()
        {
            return new UsersRepository();
        }

        public override IRoleRepository GetRoleRepository()
        {
            return new RoleRepository();
        }

        public override IMedicationRepository GetMedicationRepository()
        {
            return new MedicationRepository();
        }

        public override IRateRepository GetRateRepository()
        {
            return new RateRepository();
        }

        public override ISupplyRepository GetSupplyRepository()
        {
            return new SupplyRepository();
        }

        public override IPersonRepository GetPersonRepository()
        {
            return new PersonRepository();
        }

        public override IPersonTypeRepository GetPersonTypeRepository()
        {
            return new PersonTypeRepository();
            ;
        }
    }
}