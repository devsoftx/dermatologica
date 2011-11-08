using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class PersonRepository : Repository<Person>, IPersonRepository
    {
        public IList<Person> GetPacients(Person example)
        {
            const string query = "from Person p where p.PersonType.Id = :personTypeId and ( lower(p.FirstName) like :firstName or lower(p.LastNameP) like :lastNameP or lower(p.LastNameM) like :lastNameM ) and p.IsActive = true ";
            string[] parameters = { "personTypeId", "firstName", "lastNameP", "lastNameM" };
            object[] values = {
                                  example.PersonType.Id, string.Format("{0}" + example.FirstName + "{0}", "%"),
                                  string.Format("{0}" + example.LastNameP + "{0}", "%"),
                                  string.Format("{0}" + example.LastNameM + "{0}", "%")
                              };
            return Query(query, parameters, values);
        }

        public IList<Person> GetStaff(Person example)
        {
            const string query = "from Person p where p.PersonType.Id not in (:personTypeId) and ( lower(p.FirstName) like :firstName or lower(p.LastNameP) like :lastNameP or lower(p.LastNameM) like :lastNameM ) and p.IsActive = true ";
            string[] parameters = { "personTypeId", "firstName", "lastNameP", "lastNameM" };
            object[] values = {
                                  example.PersonType.Id, string.Format("{0}" + example.FirstName + "{0}", "%"),
                                  string.Format("{0}" + example.LastNameP + "{0}", "%"),
                                  string.Format("{0}" + example.LastNameM + "{0}", "%")
                              };
            return Query(query, parameters, values);
        }

        public IList<Person> SearchPersons(Person example)
        {
            const string query = "from Person p where (lower(p.FirstName) like :firstName or lower(p.LastNameP) like :lastNameP or lower(p.LastNameM) like :lastNameM ) and p.IsActive = true ";
            string[] parameters = { "firstName", "lastNameP", "lastNameM" };
            object[] values = {
                                  string.Format("{0}" + example.FirstName + "{0}", "%"),
                                  string.Format("{0}" + example.LastNameP + "{0}", "%"),
                                  string.Format("{0}" + example.LastNameM + "{0}", "%")
                              };
            return Query(query, parameters, values);
        }
    }
}