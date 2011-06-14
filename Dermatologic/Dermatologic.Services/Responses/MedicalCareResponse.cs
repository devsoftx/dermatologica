using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class MedicalCareResponse : ResponseBase<MedicalCare>
    {
        public IList<MedicalCare> MedicalCares { set; get; }
    }
    
}
