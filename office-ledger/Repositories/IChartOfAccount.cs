using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface IChartOfAccount
    {
        public String getChartOfAccount();

        public String insertChartOfAccount();

        public String updateChartOfAccount();
    }
}
