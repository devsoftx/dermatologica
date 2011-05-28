using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IPersonService : IServiceController<Person>
    {
        IList<Person> GetPacients(Person example);

    }
}