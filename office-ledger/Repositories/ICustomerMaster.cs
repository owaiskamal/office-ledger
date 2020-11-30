using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
   public interface ICustomerMaster
    {
        public String getCustomerMaster();

        public String insertCustomerMaster(CustomerMaster customer);

        public String updateCustomerMaster(CustomerMaster customer);

        public String getCustChartOfAccount();
    }
}
