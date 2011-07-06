using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class MedicalCareRepository : Repository<MedicalCare> , IMedicalCareRepository
    {
               
        public IList<MedicalCare> GetMedicalCaresByPerson(Person example)
        {
            const string query = "from MedicalCare m where m.Medical.Id = :personId and m.IsPaid=0";
            string[] parameters = { "personId" };
            object[] values = {
                                  example.Id, 
                              };
            return Query(query, parameters, values);
        }
        public IList<MedicalCare> GetTitularidadByPerson(Person example)
        {
            const string query = "from MedicalCare m where m.Partner.Id = :personId and m.IsPaidPartner=0";
            string[] parameters = { "personId" };
            object[] values = {
                                  example.Id, 
                              };
            return Query(query, parameters, values);
        }
        public IList<MedicalCare> GetReemplazosByPerson(Person example)
        {
            const string query = "from MedicalCare m where m.Medical.Id = :personId and m.IsReplacement=1 and m.IsPaid=0";
            string[] parameters = { "personId" };
            object[] values = {
                                  example.Id, 
                              };
            return Query(query, parameters, values);
        }
        
    }
}