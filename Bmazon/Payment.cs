using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmazon
{
    class Payment
    {
        private static Payment _instance = null;

        private string paymentMethod;
        private decimal paymentMethodExtraCosts;
        private string bankAccountHolder;
        private string iban;
        private string bic;

        private Payment()
        {

        }

        public static Payment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Payment();
                }

                return _instance;
            }
        }

        public string PaymentMethod { get => paymentMethod; set => paymentMethod = value; }
        public decimal PaymentMethodExtraCosts { get => paymentMethodExtraCosts; set => paymentMethodExtraCosts = value; }
        public string BankAccountHolder { get => bankAccountHolder; set => bankAccountHolder = value; }
        public string Iban { get => iban; set => iban = value; }
        public string Bic { get => bic; set => bic = value; }

    }
}
