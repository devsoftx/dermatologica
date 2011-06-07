using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IPaymentService : IServiceController<Payment>
    {
           PaymentResponse GetPaymentsByParams(Payment example);
    }
}