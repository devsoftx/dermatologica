using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class PaymentRepository : Repository<Payment>, IPaymentRepository
    {
        public IList<Payment> GetPaymentsByParams(Payment example)
        {
            const string query = "from Payment p where p.Currency = :Currency and p.MPayment = :MPayment";
            string[] parameters = { "Currency", "MPayment"};
            object[] values = {
                                  example.Currency, example.MPayment 
                              };
            return Query(query, parameters, values);
        }
        
        
        //public IList<Person> GetPacients(Person example)
        //{
        //    const string query = "from Person p where p.PersonType.Id = :personTypeId and ( lower(p.FirstName) like :firstName or lower(p.LastName) like :lastName) ";
        //    string[] parameters = { "personTypeId", "firstName", "lastName" };
        //    object[] values = {
        //                          example.PersonType.Id, string.Format("{0}" + example.FirstName + "{0}", "%"),
        //                          string.Format("{0}" + example.LastName + "{0}", "%")
        //                      };
        //    return Query(query, parameters, values);
        //}
    }
}