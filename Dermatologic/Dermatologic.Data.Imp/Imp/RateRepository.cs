using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class RateRepository : Repository<Rate> , IRateRepository
    {
        public IList<Rate> GetRatesByPerson(Person example)
        {
            const string query = "from Rate r where r.Person.Id = :personId";
            string[] parameters = { "personId" };
            object[] values = {
                                  example.Id, 
                              };
            return Query(query, parameters, values);
        }
        public IList<Rate> GetRatesByPersonService(Person example1,Service example2)
        {
            const string query = "from Rate r where r.Person.Id = :personId and r.Service.Id=:serviceId";
            string[] parameters = { "personId","serviceId" };
            object[] values = {
                                  example1.Id,example2.Id 
                              };
            return Query(query, parameters, values);
        }
    }
}