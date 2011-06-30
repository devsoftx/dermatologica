using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IServiceService : IServiceController<Service>
    {
        ServiceResponse GetServicesByCostCenter(CostCenter example);
       
    }
}