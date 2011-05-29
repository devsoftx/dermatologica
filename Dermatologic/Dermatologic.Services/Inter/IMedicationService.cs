using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IMedicationService : IServiceController<Medication>
    {
        MedicationResponse SaveMedication(Medication medication, IEnumerable<Session> sessions);
    }
}