using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PersonService : ServiceController<Person> , IPersonService
    {
        public PersonService()
        {
            Repository = RepositoryFactory.GetPersonRepository();
        }

        public IList<Person> GetPacients(Person example)
        {
            return RepositoryFactory.GetPersonRepository().GetPacients(example);
        }
    }
}