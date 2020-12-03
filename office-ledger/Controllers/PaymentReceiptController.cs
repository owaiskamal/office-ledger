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
    public class PaymentReceiptController : ControllerBase
    {
        IPaymentReceipt paymentReceipt;

        public PaymentReceiptController(IPaymentReceipt _paymentReceipt)
        {
            paymentReceipt = _paymentReceipt;

        }

        [Route("api/getPayInvoicePayment")]
        [HttpGet]

        public ActionResult getPayInvoicePayment()
        {
            var result = paymentReceipt.getPayInvoicePayment();
            if (result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/getPaymentReceipt")]
        [HttpGet]

        public ActionResult getPaymentReceipt()
        {
            var result = paymentReceipt.getPaymentReceipt();
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }

        }

        [Route("api/insertPaymentReceipt")]
        [HttpPost]

        public ActionResult insertPaymentReceipt([FromBody] PaymentReceipt payment)
        {
            var result = paymentReceipt.insertPaymentReceipt(payment);
            if(result == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(result);
            }
        }

        [Route("api/updatePaymentReceipt")]
        [HttpPost]

        public ActionResult updatePaymentReceipt([FromBody] PaymentReceipt payment)
        {
            var result = paymentReceipt.updatePaymentReceipt(payment);
            if (result == null)
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