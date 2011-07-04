using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IMedicalCareRepository : IRepository<MedicalCare>
    {
        IList<MedicalCare> GetMedicalCaresByPerson(Person example);
        IList<MedicalCare> GetTitularidadByPerson(Person example);
    }
}