using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IMedicationRepository : IRepository<Medication>
    {
        IList<Medication> GetMedicationsByPatient(Person example);
    }
}