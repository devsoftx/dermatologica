using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services.Responses
{
    class PaymentResponse : ResponseBase<Payment>
    {
        public IList<Payment> Payments { set; get; }
    }
}
