using System;
using System.Collections.Generic;
using Dermatologic.Domain;

namespace Dermatologic.Data
{
    public class InvoiceRepository : Repository<Invoice>, IInvoiceRepository
    {
        public IList<Invoice> GetRevenuesByParams(Invoice example)
        {
            const string query = "from Invoice i where i.Currency = :Currency and i.MPayment = :MPayment and i.InvoiceType = :InvoiceType and i.CostCenter.Id=:CostCenterId and i.Movement='Ingreso'";
            string[] parameters = { "Currency", "MPayment", "InvoiceType","CostCenterId" };
            object[] values = {
                                  example.Currency, example.MPayment ,example.InvoiceType,example.CostCenter.Id
                              };
            return Query(query, parameters, values);
        }
        public IList<Invoice> GetExpensesByParams(Invoice example)
        {
            const string query = "from Invoice i where i.Currency = :Currency and i.MPayment = :MPayment and i.InvoiceType = :InvoiceType and i.CostCenter.Id=:CostCenterId and i.Movement='Egreso'";
            string[] parameters = { "Currency", "MPayment", "InvoiceType", "CostCenterId" };
            object[] values = {
                                  example.Currency, example.MPayment ,example.InvoiceType,example.CostCenter.Id
                              };
            return Query(query, parameters, values);
        }
    }
}