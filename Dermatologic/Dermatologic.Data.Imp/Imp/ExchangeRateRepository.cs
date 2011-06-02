using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data.Imp
{
    public class ExchangeRateRepository : Repository<ExchangeRate>,IExchangeRateRepository
    {
        public IList<ExchangeRate> GetExchangeRateByDates(DateTime stardate, DateTime enddate)
        {
            const string query = "from ExchangeRate er where er.DateRate beetween :stardate and :enddate ";
            string[] parameters = { "stardate", "enddate" };
            object[] values = {
                                  stardate,enddate
                              };
            return Query(query, parameters, values);
        }
    }
}
