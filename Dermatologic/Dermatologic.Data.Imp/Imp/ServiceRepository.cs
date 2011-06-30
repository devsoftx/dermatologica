using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class ServiceRepository : Repository<Service> , IServiceRepository
    {
        public IList<Service> GetServicesByCostCenter(CostCenter example)
        {
            const string query = "from Service s where s.CostCenter.Id=:costcenterId and IsActive=1";
            string[] parameters = { "costcenterId"};
            object[] values = { example.Id};
            return Query(query, parameters, values);
        }     
       
    }
}