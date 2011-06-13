using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IRateService : IServiceController<Rate>
    {
        RateResponse GetRatesByPerson(Person example);   
    }
}