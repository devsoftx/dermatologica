using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PersonResponse : ResponseBase<Person>
    {
        public IList<Person> Pacients { set; get; }

        public Person Person { set; get; }
    }
}