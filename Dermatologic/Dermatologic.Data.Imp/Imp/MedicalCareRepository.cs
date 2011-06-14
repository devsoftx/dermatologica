using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class MedicalCareRepository : Repository<MedicalCare> , IMedicalCareRepository
    {
               
        public IList<MedicalCare> GetMedicalCaresByPerson(Person example)
        {
            const string query = "from MedicalCare m where m.Medical.Id = :personId";
            string[] parameters = { "personId" };
            object[] values = {
                                  example.Id, 
                              };
            return Query(query, parameters, values);
        }
        
    }
}