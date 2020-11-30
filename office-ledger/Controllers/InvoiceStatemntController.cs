using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using office_ledger.Models;
using office_ledger.Repositories;

namespace office_ledger.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class InvoiceStatemntController : ControllerBase
    {
        IInvoiceStatement invoiceStatement;
        public InvoiceStatemntController(IInvoiceStatement _invoiceStatement)
        {
            invoiceStatement = _invoiceStatement;
        }
        [Route("api/invBusinessUnit")]
        [HttpGet]
        public ActionResult invBusinessUnit()
        {
            var result = invoiceStatement.getInvBusinessUnits();
            if(result == null)
            {

                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [Route("api/insertInvBusinessUnit")]
        [HttpPost]
        public ActionResult insertInvBusinessUnit([FromBody] InvoiceStatement invoiceStat)
        {
            var result = invoiceStatement.insertInvBusinessUnits(invoiceStat);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }
        [Route("api/updateInvBusinessUnit")]
        [HttpPost]

        public ActionResult updateInvBusinessUnit([FromBody] InvoiceStatement upInvStat)
        {
            var result = invoiceStatement.updateInvBusinessUnits(upInvStat);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/getInvBusinessUnitCID")]
        [HttpGet]
        public ActionResult getInvBusinessUnitCID(InvoiceStatement InvStatCID)
        {
            var result = invoiceStatement.getInvBusinessUnitCustID(InvStatCID);
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