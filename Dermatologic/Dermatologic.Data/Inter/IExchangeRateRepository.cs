using System;
using System.Collections.Generic;
using Dermatologic.Domain;


namespace Dermatologic.Data
{
    public interface IExchangeRateRepository : IRepository<ExchangeRate>
    {
        IList<ExchangeRate> GetExchangeRateByDates(DateTime stardate, DateTime enddate);
        IList<ExchangeRate> GetExchangeRateByCurrentRate(DateTime CurrentDate);
    }
}