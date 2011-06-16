using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public interface IInvoiceService : IServiceController<Invoice>
    {
        InvoiceResponse GetRevenuesByParams(Invoice example);
        InvoiceResponse GetExpensesByParams(Invoice example);
    }
}