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
        String insertInvoiceStatement(InvoiceStatement invoiceStatement);

        String updateInvoiceStatement(InvoiceStatement invoiceStatement);

        String getInvCustID();

        String getInvoiceStatement();

        String getInvCostCenters();
        
    }
}
