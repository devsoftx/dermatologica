using System;
using System.Collections.Generic;
using Dermatologic.Data;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class MedicationRepository : Repository<Medication> , IMedicationRepository
    {
        public void SaveMedication(Medication medication, IEnumerable<Session> sessions)
        {
            try
            {

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}