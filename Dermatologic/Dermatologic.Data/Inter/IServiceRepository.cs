using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IServiceRepository : IRepository<Service>
    {
        IList<Service> GetServicesByCostCenter(CostCenter example);
    }
}