using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MedicationService : ServiceController<Medication> , IMedicationService
    {
        public MedicationService()
        {
            Repository = RepositoryFactory.GetMedicationRepository();
        }
    }
}