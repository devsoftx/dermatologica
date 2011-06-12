using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class StaffInformationService : ServiceController<StaffInformation> , IStaffInformationService
    {
        public StaffInformationService()
        {
            Repository = RepositoryFactory.GetStaffInformationRepository();
        }
    }
}