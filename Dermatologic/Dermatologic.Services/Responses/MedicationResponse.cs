using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MedicationResponse : ResponseBase<Medication>
    {

        public IList<Medication> Medications { set; get; }
      
    }
}