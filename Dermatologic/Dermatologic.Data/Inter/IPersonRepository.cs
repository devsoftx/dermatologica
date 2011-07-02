using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IPersonRepository : IRepository<Person>
    {
        IList<Person> GetPacients(Person example);
        IList<Person> SearchPersons(Person example);
        IList<Person> GetStaff(Person example);
    }
}