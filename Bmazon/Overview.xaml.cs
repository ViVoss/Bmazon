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
    /// Interaktionslogik für Overview.xaml
    /// </summary>
    public partial class Overview : Page
    {
        //Adressdata Adressdata = new Adressdata();
        //List<Product> Products = new List<Product>();
        //VersandZahlung VersandZahlung = new VersandZahlung();
        //StringBuilder StrBuilder = new StringBuilder();
        public MainWindow MainWindow { get; set; }

        public Overview(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            InitializeComponent();

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            TextBlock LastName_TextBlock = new TextBlock();
            LastName_TextBlock.Text = Shipment.Instance.LastName;

            DeliveryAddress_StackPanel.Children.Add(LastName_TextBlock);

            TextBlock FirstName_TextBlock = new TextBlock();
            FirstName_TextBlock.Text = Shipment.Instance.FirstName;

            DeliveryAddress_StackPanel.Children.Add(FirstName_TextBlock);

            TextBlock Street_TextBlock = new TextBlock();
            Street_TextBlock.Text = Shipment.Instance.Street;

            DeliveryAddress_StackPanel.Children.Add(Street_TextBlock);

            TextBlock HouseNr_TextBlock = new TextBlock();
            HouseNr_TextBlock.Text = Shipment.Instance.HouseNumber;

            DeliveryAddress_StackPanel.Children.Add(HouseNr_TextBlock);

            TextBlock PostalCode_TextBlock = new TextBlock();
            PostalCode_TextBlock.Text = Shipment.Instance.PostalCode;

            DeliveryAddress_StackPanel.Children.Add(PostalCode_TextBlock);

            TextBlock City_TextBlock = new TextBlock();
            City_TextBlock.Text = Shipment.Instance.City;

            DeliveryAddress_StackPanel.Children.Add(City_TextBlock);

            TextBlock Country_TextBlock = new TextBlock();
            Country_TextBlock.Text = Shipment.Instance.Country;

            DeliveryAddress_StackPanel.Children.Add(Country_TextBlock);
        }
    }
}
