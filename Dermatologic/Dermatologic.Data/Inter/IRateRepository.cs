using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IRateRepository : IRepository<Rate>
    {
        IList<Rate> GetRatesByPerson(Person example);
    }
}