using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Bmazon
{
    /// <summary>
    /// Interaktionslogik für ShippingAdress.xaml
    /// </summary>
    public partial class ShippingAdress : Page
    {
        public MainWindow MainWindow { get; set; }

        // Verhalten beim erstmaligen Aufruf der Lieferadresse Page
        public ShippingAdress(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Shipment.Instance.LastName = LastName_TextBox.Text.ToString().Trim();
            Shipment.Instance.FirstName = FirstName_TextBox.Text.ToString().Trim();
            Shipment.Instance.Street = StreetName_TextBox.Text.ToString().Trim();
            Shipment.Instance.HouseNumber = HouseNr_TextBox.Text.ToString().Trim();
            Shipment.Instance.PostalCode = PostalCode_TextBox.Text.ToString().Trim();
            Shipment.Instance.City = City_TextBox.Text.ToString().Trim();
            Shipment.Instance.Country = Country_TextBox.Text.ToString().Trim();
        }
    }
}
