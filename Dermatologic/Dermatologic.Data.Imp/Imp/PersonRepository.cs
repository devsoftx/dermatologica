using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public IList<Person> GetPacients(Person example)
        {
            const string query = "from Person p where p.PersonType.Id = :personTypeId and ( p.FirstName = :firstName  or p.LastName = :lastName ) ";
            string[] parameters = { "personTypeId", "firstName", "lastName" };
            object[] values = {example.PersonType.Id, example.FirstName, example.LastName};
            return Query(query, parameters, values);
        }
    }
}