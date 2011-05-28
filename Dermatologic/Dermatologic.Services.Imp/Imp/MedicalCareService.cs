using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MedicalCareService : ServiceController<MedicalCare>, IMedicalCareService
    {
        public MedicalCareService()
        {
            Repository = RepositoryFactory.GetMedicalCareRepository();
        }
    }
}