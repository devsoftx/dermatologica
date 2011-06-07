using System;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IExchangeRateService : IServiceController<ExchangeRate>
    {
        ExchangeRateResponse GetExchangeRateByDates(DateTime stardate, DateTime enddate);
        ExchangeRateResponse GetExchangeRateByCurrentRate(DateTime CurrentDate);
    }
}
