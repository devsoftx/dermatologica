using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PatientInformationService : ServiceController<PatientInformation> , IPatientInformationService
    {
        public PatientInformationService()
        {
            Repository = RepositoryFactory.GetPatientInformationRepository();
        }
    }
}