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
    /// Interaktionslogik für ShoppingCartOverview.xaml
    /// </summary>
    public partial class ShoppingCartOverview : Page
    {
        ItemEntities connection = new ItemEntities();
        List<ShoppingCart> shoppingCartList;
        decimal totalPrice;

        public MainWindow MainWindow { get; set; }

        public ShoppingCartOverview(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            InitializeComponent();

            shoppingCartList = connection.ShoppingCarts.ToList();

            if (connection.ShoppingCarts.Where(x => x.TotalPrice >= 0).FirstOrDefault() != null)
            {
                totalPrice = connection.ShoppingCarts.Sum(x => x.TotalPrice);
            }
            else
            {
                totalPrice = 0.00m;
            }

            Label TotalPrice_Label = new Label();
            TotalPrice_Label.HorizontalAlignment = HorizontalAlignment.Right;
            TotalPrice_Label.Margin = new Thickness(0, 0, 30, 0);
            TotalPrice_Label.FontWeight = FontWeights.Bold;
            TotalPrice_Label.FontSize = 20;
            TotalPrice_Label.Content = "Total Price: " + Math.Round(totalPrice, 2).ToString() + "€";

            if (shoppingCartList.Count() > 0)
            {
                foreach (ShoppingCart shoppingCartItem in shoppingCartList)
                {
                    DockPanel ShoppingCartItem_DockPanel = new DockPanel();
                    ShoppingCartItem_DockPanel.LastChildFill = false;
                    ShoppingCartItem_DockPanel.Background = (Brush)new BrushConverter().ConvertFrom("#D4D4D4");
                    ShoppingCartItem_DockPanel.Margin = new Thickness(5, 0, 5, 5);

                    Item product = connection.Items.Where(x => x.ID == shoppingCartItem.ItemID).First();

                    Image ShoppingCartItem_Image = new Image();
                    ShoppingCartItem_Image.Width = 200;
                    ShoppingCartItem_Image.Height = 100;
                    ShoppingCartItem_Image.Source = new BitmapImage(new Uri(product.Image, UriKind.Relative));

                    Label ShoppingCartItemName_Label = new Label();
                    ShoppingCartItemName_Label.FontSize = 20;
                    ShoppingCartItemName_Label.Height = 50;
                    ShoppingCartItemName_Label.FontWeight = FontWeights.SemiBold;
                    ShoppingCartItemName_Label.Content = product.Name;

                    TextBlock ShoppingCartItemPrice_TextBlock = new TextBlock();
                    ShoppingCartItemPrice_TextBlock.Width = 150;
                    ShoppingCartItemPrice_TextBlock.FontSize = 18;
                    ShoppingCartItemPrice_TextBlock.Foreground = Brushes.DarkRed;
                    ShoppingCartItemPrice_TextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    ShoppingCartItemPrice_TextBlock.VerticalAlignment = VerticalAlignment.Center;
                    ShoppingCartItemPrice_TextBlock.FontWeight = FontWeights.Bold;
                    ShoppingCartItemPrice_TextBlock.TextAlignment = TextAlignment.Center;
                    ShoppingCartItemPrice_TextBlock.Text = Convert.ToString(Math.Round(shoppingCartItem.TotalPrice, 2)) + "€";

                    ComboBox ShoppingCartItemQuantity_ComboBox = new ComboBox();
                    ShoppingCartItemQuantity_ComboBox.Width = 50;
                    ShoppingCartItemQuantity_ComboBox.Margin = new Thickness(10, 10, 10, 10);
                    ShoppingCartItemQuantity_ComboBox.SelectedIndex = shoppingCartItem.Quantity - 1;
                    addItemsToUnitsInStockQuantityComboBox(ShoppingCartItemQuantity_ComboBox);
                    ShoppingCartItemQuantity_ComboBox.SelectionChanged += delegate
                    {
                        try
                        {
                            ShoppingCart shoppingCartItemExist = connection.ShoppingCarts.Where(x => x.ItemID == product.ID).FirstOrDefault();

                            shoppingCartItemExist.Quantity = Convert.ToInt32(ShoppingCartItemQuantity_ComboBox.SelectedItem);
                            shoppingCartItemExist.TotalPrice = shoppingCartItemExist.Quantity * product.Price;

                            connection.SaveChanges();

                            ShoppingCartItemPrice_TextBlock.Text = Convert.ToString(Math.Round(shoppingCartItem.TotalPrice, 2)) + "€";

                            totalPrice = connection.ShoppingCarts.Sum(x => x.TotalPrice);
                            TotalPrice_Label.Content = "Total Price: " + Math.Round(totalPrice, 2).ToString() + "€";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    };

                    Button DeleteFromCart_Button = new Button();
                    DeleteFromCart_Button.Content = "Delete";
                    DeleteFromCart_Button.Width = 150;
                    DeleteFromCart_Button.Background = (Brush)new BrushConverter().ConvertFrom("#ffa500");
                    DeleteFromCart_Button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#ffa500");
                    DeleteFromCart_Button.Foreground = (Brush)new BrushConverter().ConvertFrom("#DD000000");
                    DeleteFromCart_Button.Click += delegate
                    {
                        try
                        {
                            connection.ShoppingCarts.Remove(shoppingCartItem);
                            connection.SaveChanges();

                            Warenkorbübersicht_Item_StackPanel.Children.Remove(ShoppingCartItem_DockPanel);

                            if (connection.ShoppingCarts.Where(x => x.TotalPrice >= 0).FirstOrDefault() != null)
                            {
                                totalPrice = connection.ShoppingCarts.Sum(x => x.TotalPrice);
                            }
                            else
                            {
                                totalPrice = 0.00m;
                            }

                            TotalPrice_Label.Content = "Total Price: " + Math.Round(totalPrice, 2).ToString() + "€";
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    };

                    DockPanel.SetDock(ShoppingCartItem_Image, Dock.Left);
                    ShoppingCartItem_DockPanel.Children.Add(ShoppingCartItem_Image);

                    DockPanel.SetDock(ShoppingCartItemName_Label, Dock.Top);
                    ShoppingCartItem_DockPanel.Children.Add(ShoppingCartItemName_Label);

                    DockPanel.SetDock(ShoppingCartItemQuantity_ComboBox, Dock.Left);
                    ShoppingCartItem_DockPanel.Children.Add(ShoppingCartItemQuantity_ComboBox);

                    DockPanel.SetDock(DeleteFromCart_Button, Dock.Left);
                    ShoppingCartItem_DockPanel.Children.Add(DeleteFromCart_Button);

                    DockPanel.SetDock(ShoppingCartItemPrice_TextBlock, Dock.Right);
                    ShoppingCartItem_DockPanel.Children.Add(ShoppingCartItemPrice_TextBlock);

                    Warenkorbübersicht_Item_StackPanel.Children.Add(ShoppingCartItem_DockPanel);
                }
            }
            else
            {
                Label ShoppingCartEmpty_Label = new Label();
                ShoppingCartEmpty_Label.FontSize = 36;
                ShoppingCartEmpty_Label.FontWeight = FontWeights.Bold;
                ShoppingCartEmpty_Label.HorizontalAlignment = HorizontalAlignment.Center;
                ShoppingCartEmpty_Label.VerticalAlignment = VerticalAlignment.Center;
                ShoppingCartEmpty_Label.Content = "Your shopping cart is empty.";

                Warenkorbübersicht_Item_StackPanel.Children.Add(ShoppingCartEmpty_Label);
            }

            Warenkorbübersicht_Bottom_StackPanel.Children.Add(TotalPrice_Label);
        }

        private void addItemsToUnitsInStockQuantityComboBox(ComboBox quantityComboBox)
        {
            for (int i = 1; i <= 99; i++)
            {
                quantityComboBox.Items.Add(i);
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
