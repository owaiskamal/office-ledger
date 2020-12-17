using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface IExpenseUnit
    {
        public String getExpenseUnits(ExpenseUnits expenseUnits);

        public String getExpBusinessUnits();

        public String insertExpenseUnit(ExpenseUnits expenseUnits);
    }
}
