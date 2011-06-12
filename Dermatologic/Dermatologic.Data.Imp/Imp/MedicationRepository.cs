using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class MedicationRepository : Repository<Medication> , IMedicationRepository
    {
        public IList<Medication> GetMedicationsByPatient(Person example)
        {
            const string query = "from Medication m where lower(m.Patient.FirstName) like : firstName or lower(m.Patient.LastNameP) like :lastNameP or lower(m.Patient.LastNameM) like :lastNameM";
            string[] parameters = { "firstName", "lastNameP", "lastNameM" };
            object[] values = {
                                      string.Format("{0}" + example.FirstName + "{0}", "%"),
                                      string.Format("{0}" + example.LastNameP + "{0}", "%"),
                                      string.Format("{0}" + example.LastNameM + "{0}", "%")
                                  };
            return Query(query, parameters, values);
        }
                
    }
}