using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IPersonService : IServiceController<Person>
    {
        PersonResponse GetPacients(Person example);

        PersonResponse GetPersonByDni(string dni);
    }
}