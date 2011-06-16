using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Dermatologic.Data;
using Dermatologic.Domain;
namespace Dermatologic.Services
{
    public class InvoiceService : ServiceController<Invoice>, IInvoiceService
    {
        public InvoiceService()
        {
            Repository = RepositoryFactory.GetInvoiceRepository();
        }
        public InvoiceResponse GetRevenuesByParams(Invoice example)
        {
            var response = new InvoiceResponse();
            try
            {
                IInvoiceRepository repository = new InvoiceRepository();
                response.Invoices=repository.GetRevenuesByParams( example);
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
        public InvoiceResponse GetExpensesByParams(Invoice example)
        {
            var response = new InvoiceResponse();
            try
            {
                IInvoiceRepository repository = new InvoiceRepository();
                response.Invoices = repository.GetExpensesByParams(example);
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
        //public PaymentResponse GetPaymentsByParams(Payment example)
        //{
        //    var response = new PaymentResponse();
        //    try
        //    {
        //        IPaymentRepository repository = new PaymentRepository();
        //        response.Payments = repository.GetPaymentsByParams(example);
        //        response.OperationResult = OperationResult.Success;
        //        return response;
        //    }
        //    catch (Exception e)
        //    {
        //        response.Message = e.Message;
        //        response.OperationResult = OperationResult.Failed;
        //        return response;
        //    }
        //}
    }
}