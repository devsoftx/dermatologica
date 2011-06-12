using Dermatologic.Domain;

namespace Dermatologic.Services
{
    public class InvoiceService : ServiceController<Invoice>, IInvoiceService
    {
        public InvoiceService()
        {
            Repository = RepositoryFactory.GetInvoiceRepository();
        }
    }
}