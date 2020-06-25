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
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ItemSelection produktauswahl;
        ShoppingCartOverview warenkorbübersicht;
        PaymentOption versandZahlungsart;
        ShippingAdress lieferadresse;
        Overview bestellübersicht;

        public MainWindow()
        {
            InitializeComponent();

            // Pages erstellen
            produktauswahl = new ItemSelection(this);
            warenkorbübersicht = new ShoppingCartOverview(this);
            versandZahlungsart = new PaymentOption(this);
            lieferadresse = new ShippingAdress(this);
            bestellübersicht = new Overview(this);

            Back_Button.Visibility = Visibility.Hidden;
            Back_Button.IsEnabled = false;

            MyFrame.Navigate(produktauswahl);
        }

        private void ShoppingCart_Button_Click(object sender, RoutedEventArgs e)
        {
            Back_Button.Visibility = Visibility.Visible;
            Back_Button.IsEnabled = true;

            Continue_Button.Visibility = Visibility.Visible;
            Continue_Button.IsEnabled = true;

            MyFrame.Navigate(warenkorbübersicht);
        }

        private void Continue_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.Content == produktauswahl)
            {
                Back_Button.Visibility = Visibility.Visible;
                Back_Button.IsEnabled = true;

                MyFrame.Navigate(warenkorbübersicht);
            }
            else if (MyFrame.Content == warenkorbübersicht)
            {
                Back_Button.Visibility = Visibility.Visible;
                Back_Button.IsEnabled = true;

                Continue_Button.Visibility = Visibility.Visible;
                Continue_Button.IsEnabled = true;

                MyFrame.Navigate(versandZahlungsart);
            }
            else if (MyFrame.Content == versandZahlungsart)
            {
                Back_Button.Visibility = Visibility.Visible;
                Back_Button.IsEnabled = true;

                Continue_Button.Visibility = Visibility.Visible;
                Continue_Button.IsEnabled = true;

                MyFrame.Navigate(lieferadresse);
            }
            else if (MyFrame.Content == lieferadresse)
            {
                Back_Button.Visibility = Visibility.Visible;
                Back_Button.IsEnabled = true;

                Continue_Button.Visibility = Visibility.Visible;
                Continue_Button.IsEnabled = true;

                MyFrame.Navigate(bestellübersicht);
            }
            else if (MyFrame.Content == bestellübersicht)
            {
                Back_Button.Visibility = Visibility.Visible;
                Back_Button.IsEnabled = true;

                Continue_Button.Visibility = Visibility.Hidden;
                Continue_Button.IsEnabled = false;

                MessageBox.Show("Thank you for shopping at Bmazon. Your order is being processed.");
            }
        }
        private void Back_Button_Click(object sender, RoutedEventArgs e)
        {
            if (MyFrame.Content == produktauswahl)
            {
                Continue_Button.Visibility = Visibility.Visible;
                Continue_Button.IsEnabled = true;
            }
            else if (MyFrame.Content == warenkorbübersicht)
            {
                Back_Button.Visibility = Visibility.Hidden;
                Back_Button.IsEnabled = false;

                MyFrame.Navigate(produktauswahl);
            }
            else if (MyFrame.Content == versandZahlungsart)
            {
                MyFrame.Navigate(warenkorbübersicht);
            }
            else if (MyFrame.Content == lieferadresse)
            {
                MyFrame.Navigate(versandZahlungsart);
            }
            else if (MyFrame.Content == bestellübersicht)
            {
                MyFrame.Navigate(lieferadresse);
            }
        }
    }
}
