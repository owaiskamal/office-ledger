using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface IBusinessUnits
    {
        String GetBusinessUnits();
        String GetBusinessUnitById(BusinessUnits businessUnits);
    }


}
