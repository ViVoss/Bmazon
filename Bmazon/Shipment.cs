using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bmazon
{
    class Shipment
    {
        private static Shipment _instance = null;

        private string shippingMethod;
        private decimal shippingMethodExtraCosts;

        private string lastName;
        private string firstName;
        private string street;
        // String, da Hausnummern nicht immer nur numerisch sein muss
        private string houseNumber;
        // String, da je nach Land die Postleitszahl nicht nur numerisch sein muss
        private string postalCode;
        private string city;
        private string country;

        private Shipment()
        {

        }

        public static Shipment Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Shipment();
                }

                return _instance;
            }
        }

        public string ShippingMethod { get => shippingMethod; set => shippingMethod = value; }
        public decimal ShippingMethodExtraCosts { get => shippingMethodExtraCosts; set => shippingMethodExtraCosts = value; }

        public string LastName { get => lastName; set => lastName = value; }
        public string FirstName { get => firstName; set => firstName = value; }
        public string Street { get => street; set => street = value; }
        public string HouseNumber { get => houseNumber; set => houseNumber = value; }
        public string PostalCode { get => postalCode; set => postalCode = value; }
        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }

    }
}
