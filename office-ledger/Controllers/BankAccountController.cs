using Microsoft.AspNetCore.Mvc;
using office_ledger.Models;
using office_ledger.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class BankAccountController: ControllerBase
    {
        IBankAccount bankAccount;

        public BankAccountController(IBankAccount _bankAccount)
        {
            bankAccount = _bankAccount;
        }

        [Route("api/getBankAccount")]
        [HttpGet]
        
        public ActionResult getBankAccount()
        {
            var result = bankAccount.getBankAccounts();
            if(result == null)
            {
                return NotFound();

            }
            else
            {
                return Ok(result);
            }

        

        }
        [Route("api/insertBankAccount")]
        [HttpPost]

        public ActionResult insertBankAccount([FromBody] BankAccount bankAcc)
        {
            var result = bankAccount.insertBankAccount(bankAcc);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

            
        }
        [Route("api/updateBankAccount")]
        [HttpPost]
        public ActionResult updateBankAccount([FromBody] BankAccount bankAcc)
        {
            var result = bankAccount.updateBankAccount(bankAcc);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
    }
}
