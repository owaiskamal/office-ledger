using office_ledger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace office_ledger.Repositories
{
    public interface IPaymentReceipt
    {
       

        public string getPayInvoicePayment();

       
        public string getPaymentReceipt();

        public string insertPaymentReceipt(PaymentReceipt paymentReceipt);


        public string updatePaymentReceipt(PaymentReceipt paymentReceipt);
        
    }
}
