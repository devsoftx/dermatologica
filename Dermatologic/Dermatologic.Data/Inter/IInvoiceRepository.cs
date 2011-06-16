using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public interface IInvoiceRepository : IRepository<Invoice>
    {
        
        IList<Invoice> GetRevenuesByParams(Invoice example);
        IList<Invoice> GetExpensesByParams(Invoice example);
    }
}