using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface IChartOfAccount
    {
        public String getChartOfAccount();

        public String insertChartOfAccount(ChartOfAccount chartOfAccount);

        public String updateChartOfAccount(ChartOfAccount chartOfAccount);
    }
}
