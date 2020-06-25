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
    /// Interaktionslogik für PaymentOption.xaml
    /// </summary>
    public partial class PaymentOption : Page
    {
        public MainWindow MainWindow { get; set; }

        public PaymentOption(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            InitializeComponent();

            DirectDebit_Button.IsChecked = true;
            Dhl_Button.IsChecked = true;
            PaymentMethodInfo_TextBlock.Visibility = Visibility.Hidden;
        }

        private void DirectDebit_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (DirectDebit_Button.IsChecked == true)
            {
                BankAccountInfo_StackPanel.Visibility = Visibility.Visible;
                PaymentMethodInfo_TextBlock.Visibility = Visibility.Hidden;
            }
        }

        private void DirectDebit_Button_Unchecked(object sender, RoutedEventArgs e)
        {
            if (DirectDebit_Button.IsChecked == false)
            {
                BankAccountInfo_StackPanel.Visibility = Visibility.Hidden;
                Payment.Instance.PaymentMethod = PaymentMethod_Label.Content.ToString();
                Payment.Instance.PaymentMethodExtraCosts = 0.00m;
            }
        }

        private void BankTransfer_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (BankTransfer_Button.IsChecked == true)
            {
                PaymentMethodInfo_TextBlock.Text = "Please transfer the money to following bank account ... immediately. Afterwards the package will be shipped.";
                Payment.Instance.PaymentMethod = PaymentMethod_Label.Content.ToString();
                Payment.Instance.PaymentMethodExtraCosts = 0.00m;
            }
        }

        private void CashOnDelivery_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (CashOnDelivery_Button.IsChecked == true)
            {
                PaymentMethodInfo_TextBlock.Text = "Please keep the money ready for the delivery.";
                Payment.Instance.PaymentMethod = PaymentMethod_Label.Content.ToString();
                Payment.Instance.PaymentMethodExtraCosts = 4.00m;
            }
        }

        private void Invoice_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (Invoice_Button.IsChecked == true)
            {
                PaymentMethodInfo_TextBlock.Text = "Please transfer the money to following bank account ... within the next 14 days.";
                Payment.Instance.PaymentMethod = PaymentMethod_Label.Content.ToString();
                Payment.Instance.PaymentMethodExtraCosts = 0.00m;
            }
        }

        private void Dhl_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (Dhl_Button.IsChecked == true)
            {
                Shipment.Instance.ShippingMethod = ShippingMethod_Label.Content.ToString();
                Shipment.Instance.ShippingMethodExtraCosts = 0.00m;
            }
        }

        private void Hermes_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (Hermes_Button.IsChecked == true)
            {
                Shipment.Instance.ShippingMethod = ShippingMethod_Label.Content.ToString();
                Shipment.Instance.ShippingMethodExtraCosts = 2.00m;
            }
        }

        private void Dpd_Button_Checked(object sender, RoutedEventArgs e)
        {
            if (Dpd_Button.IsChecked == true)
            {
                Shipment.Instance.ShippingMethod = ShippingMethod_Label.Content.ToString();
                Shipment.Instance.ShippingMethodExtraCosts = 4.00m;
            }
        }
    }
}
