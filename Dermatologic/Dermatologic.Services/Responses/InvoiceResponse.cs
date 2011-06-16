using System.Collections.Generic;
using Dermatologic.Domain;


namespace Dermatologic.Services
{
    public class InvoiceResponse : ResponseBase<Invoice>
    {
        public IList<Invoice> Invoices { set; get; }
    }
}
