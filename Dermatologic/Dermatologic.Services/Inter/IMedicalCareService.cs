using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IMedicalCareService : IServiceController<MedicalCare>
    {
        MedicalCareResponse GetMedicalCaresByPerson(Person example);
        MedicalCareResponse GetTitularidadByPerson(Person example);
        MedicalCareResponse GetReemplazosByPerson(Person example);
    }
}

