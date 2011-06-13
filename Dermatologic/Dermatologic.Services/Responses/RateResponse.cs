using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class RateResponse : ResponseBase<Rate>
    {
        public IList<Rate> Rates {set; get;}
    }
    
}
