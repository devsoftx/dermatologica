using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IPersonService : IServiceController<Person>
    {
        PersonResponse GetPacients(Person example);
        PersonResponse GetStaff(Person example);
        PersonResponse GetPersonByDni(string dni);
        PersonResponse SearchPersons(Person example);
    }
}