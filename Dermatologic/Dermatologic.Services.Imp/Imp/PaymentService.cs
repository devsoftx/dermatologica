using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PaymentService : ServiceController<Payment> , IPaymentService
    {
        public PaymentService ()
        {
            Repository=RepositoryFactory.GetPaymentRepository();
        }
       
        public PaymentResponse GetPaymentsByParams(Payment example)
        {
            var response = new PaymentResponse();
            try
            {
                IPaymentRepository repository = new PaymentRepository();
                response.Payments = repository.GetPaymentsByParams(example);
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