using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class MedicationRepository : Repository<Medication> , IMedicationRepository
    {
        public IList<Medication> GetMedicationsByPatient(Person example)
        {
        const string query ="from Medication m where lower(m.Patient.FirstName) like : firstName or lower(m.Patient.LastName) like :lastName";
        string[] parameters = { "firstName", "lastName" };
        object[] values = {
                                  string.Format("{0}" + example.FirstName + "{0}", "%"),
                                  string.Format("{0}" + example.LastName + "{0}", "%")
                              };

            return Query(query, parameters, values);
        }
                
    }
}