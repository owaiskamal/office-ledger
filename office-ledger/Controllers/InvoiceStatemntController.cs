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
            var result = invoiceStatement.insertInvoiceStatement(invoiceStat);
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
            var result = invoiceStatement.updateInvoiceStatement(upInvStat);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/getInvCustID")]
        [HttpGet]
        public ActionResult getInvBusinessUnitCID()
        {
            var result = invoiceStatement.getInvCustID();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/getInvoiceStatement")]
        [HttpGet]
        public ActionResult getInvoiceStatement()
        {
            var result = invoiceStatement.getInvoiceStatement();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/getInvCostCenters")]
        [HttpGet]
        public ActionResult getInvCostCenters()
        {
            var result = invoiceStatement.getInvCostCenters();
            if(result ==null)
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