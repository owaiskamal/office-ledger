using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface IJournalVoucher
    {
        public string insertJorunalVoucher(string p_xml);

        public string selectJournalVoucherByFile(string id);

        public string getJournalVoucher();

        public string getVochChartOfAccount();
    }
}
