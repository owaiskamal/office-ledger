using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface ICostCenter
    {
        public String GetCostCenters();

        public String InsertCostCenters(CostCenter costCenter);

        public String UpdateCostCenter(CostCenter costCenter);

        public String GetCostCentersById(CostCenter costCenter);    
    }
}
