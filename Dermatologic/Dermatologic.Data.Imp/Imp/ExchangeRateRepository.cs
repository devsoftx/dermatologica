using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data.Imp
{
    public class ExchangeRateRepository : Repository<ExchangeRate>,IExchangeRateRepository
    {
        public IList<ExchangeRate> GetExchangeRateByDates(DateTime? startdate, DateTime? enddate)
        {
            const string query = "from ExchangeRate e where e.DateRate beetween :startdate and :enddate";
            string[] parameters = { "startdate", "enddate" };
            object[] values = {
                                  startdate.Value, enddate.Value
                              };
            return Query(query, parameters, values);
        }
        public IList<ExchangeRate> GetExchangeRateByCurrentRate(DateTime CurrentDate)
        {
            const string query = "from ExchangeRate e where e.DateRate = :CurrentDate";
            string[] parameters = { "CurrentDate" };
            object[] values = {
                                  CurrentDate
                              };
            return Query(query, parameters, values);

        }
    }
}
