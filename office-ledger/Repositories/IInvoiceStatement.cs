using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
   public interface IInvoiceStatement
    {
        String getInvBusinessUnits();
        String insertInvBusinessUnits(InvoiceStatement invoiceStatement);

        String updateInvBusinessUnits(InvoiceStatement invoiceStatement);

        String getInvBusinessUnitCustID(InvoiceStatement invoiceStatement);
    }
}
