using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class PaymentService : ServiceController<Payment> , IPaymentService
    {
        public PaymentService ()
        {
            Repository=RepositoryFactory.GetPaymentRepository();
        }
        
    }
}