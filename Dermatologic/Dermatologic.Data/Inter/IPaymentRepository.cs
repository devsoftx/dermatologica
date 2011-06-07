using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IPaymentRepository : IRepository<Payment>
    {
        IList<Payment> GetPaymentsByParams(Payment example);
    }
}