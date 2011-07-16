using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PersonService : ServiceController<Person> , IPersonService
    {
        public PersonService()
        {
            Repository = RepositoryFactory.GetPersonRepository();
        }

        public PersonResponse GetPacients(Person example)
        {
            var response = new PersonResponse();
            try
            {
                IPersonRepository repository = new PersonRepository();
                response.Pacients = repository.GetPacients(example);
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch(Exception e)
            {
                response.Message = e.Message;
                response.OperationResult = OperationResult.Failed;
                return response;
            }
        }

        public PersonResponse GetStaff(Person example)
        {
            var response = new PersonResponse();
            try
            {
                IPersonRepository repository = new PersonRepository();
                response.Staff = repository.GetStaff(example);
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.OperationResult = OperationResult.Failed;
                return response;
            }
        }

        public PersonResponse SearchPersons(Person example)
        {
            var response = new PersonResponse();
            try
            {
                IPersonRepository repository = new PersonRepository();
                response.Pacients = repository.SearchPersons(example);
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.OperationResult = OperationResult.Failed;
                return response;
            }
        }


        public PersonResponse GetPersonByDni(string dni)
        {
            var response = new PersonResponse();
            try
            {
                var example = new Person { DocumentNumber = dni, IsActive = true};
                var persons = Repository.GetByExample(example);
                response.Person = persons.Count > 0 ? persons.FirstOrDefault() : null;
                response.OperationResult = OperationResult.Success;
                return response;
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                response.OperationResult = OperationResult.Failed;
                return response;
            }
        }
    }
}