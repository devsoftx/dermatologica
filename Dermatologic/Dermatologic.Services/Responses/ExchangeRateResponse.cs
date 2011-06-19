using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class ExchangeRateResponse : ResponseBase<ExchangeRate>
    {
        public IList<ExchangeRate> ExchangeRates { set; get; }
    }
}