using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Domain;
namespace Dermatologic.Services
{
    public class MedicalCareService : ServiceController<MedicalCare>, IMedicalCareService
    {
        public MedicalCareService()
        {
            Repository = RepositoryFactory.GetMedicalCareRepository();
        }
        public MedicalCareResponse GetMedicalCaresByPerson(Person example)
        {
            var response = new MedicalCareResponse();
            try
            {
                IMedicalCareRepository repository = new MedicalCareRepository();
                response.MedicalCares = repository.GetMedicalCaresByPerson(example);
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
        public MedicalCareResponse GetTitularidadByPerson(Person example)
        {
            var response = new MedicalCareResponse();
            try
            {
                IMedicalCareRepository repository = new MedicalCareRepository();
                response.MedicalCares = repository.GetTitularidadByPerson(example);
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
        public MedicalCareResponse GetReemplazosByPerson(Person example)
        {
            var response = new MedicalCareResponse();
            try
            {
                IMedicalCareRepository repository = new MedicalCareRepository();
                response.MedicalCares = repository.GetReemplazosByPerson(example);
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