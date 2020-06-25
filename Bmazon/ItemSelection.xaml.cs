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
using System.Runtime.Remoting.Contexts;
using System.Globalization;
using System.Net.Configuration;

namespace Bmazon
{
    /// <summary>
    /// Interaktionslogik für ItemSelection.xaml
    /// </summary>
    public partial class ItemSelection : Page
    {
        ItemEntities connection = new ItemEntities();
        List<Item> productList;

        public MainWindow MainWindow { get; set; }

        public ItemSelection(MainWindow mainWindow)
        {
            this.MainWindow = mainWindow;
            InitializeComponent();
            productList = connection.Items.ToList();

            if (productList.Count() > 0)
            {
                foreach (Item item in productList)
                {
                    StackPanel Item_StackPanel = new StackPanel();
                    Item_StackPanel.Margin = new Thickness(5, 5, 0, 5);

                    Label ItemName_Label = new Label();
                    ItemName_Label.FontSize = 20;
                    ItemName_Label.FontWeight = FontWeights.SemiBold;
                    ItemName_Label.Content = item.Name;
                    ItemName_Label.HorizontalAlignment = HorizontalAlignment.Center;
                    ItemName_Label.VerticalAlignment = VerticalAlignment.Center;

                    Image Product_Image = new Image();
                    Product_Image.Width = 280;
                    Product_Image.Height = 150;
                    Product_Image.Source = new BitmapImage(new Uri(item.Image, UriKind.Relative));

                    TextBlock ProductPrice_TextBlock = new TextBlock();
                    ProductPrice_TextBlock.Width = 150;
                    ProductPrice_TextBlock.FontSize = 24;
                    ProductPrice_TextBlock.HorizontalAlignment = HorizontalAlignment.Center;
                    ProductPrice_TextBlock.VerticalAlignment = VerticalAlignment.Center;
                    ProductPrice_TextBlock.FontWeight = FontWeights.Bold;
                    ProductPrice_TextBlock.TextAlignment = TextAlignment.Center;
                    ProductPrice_TextBlock.Foreground = Brushes.DarkRed;
                    ProductPrice_TextBlock.Text = Convert.ToString(Math.Round(item.Price, 2)) + "€";

                    ComboBox ProductQuantity_ComboBox = new ComboBox();
                    ProductQuantity_ComboBox.Width = 50;
                    ProductQuantity_ComboBox.Margin = new Thickness(0, 0, 0, 10);
                    ProductQuantity_ComboBox.SelectedIndex = 0;
                    addItemsToUnitsInStockQuantityComboBox(ProductQuantity_ComboBox);

                    Button AddToCart_Button = new Button();
                    AddToCart_Button.Content = "Add To Cart";
                    AddToCart_Button.Width = 150;
                    AddToCart_Button.Background = (Brush)new BrushConverter().ConvertFrom("#FF8C1D");
                    AddToCart_Button.BorderBrush = (Brush)new BrushConverter().ConvertFrom("#FF8C1D");
                    AddToCart_Button.Foreground = (Brush)new BrushConverter().ConvertFrom("#DD000000");
                    AddToCart_Button.Click += delegate
                    {
                        try
                        {
                            ShoppingCart shoppingCartItemExist = connection.ShoppingCarts.Where(x => x.ID == item.ID).FirstOrDefault();

                            if (shoppingCartItemExist?.ItemID != item.ID)
                            {
                                ShoppingCart shoppingCartItem = new ShoppingCart()
                                {
                                    ItemID = item.ID,
                                    Quantity = Convert.ToInt32(ProductQuantity_ComboBox.SelectedItem),
                                    TotalPrice = Convert.ToDecimal(ProductQuantity_ComboBox.SelectedItem) * item.Price
                                };

                                connection.ShoppingCarts.Add(shoppingCartItem);
                                connection.SaveChanges();

                                MessageBox.Show("Successfully added " + ProductQuantity_ComboBox.SelectedItem.ToString() + " of " + item.Name + " to your shopping cart!");
                            }
                            else
                            {
                                shoppingCartItemExist.Quantity += Convert.ToInt32(ProductQuantity_ComboBox.SelectedItem);
                                shoppingCartItemExist.TotalPrice = shoppingCartItemExist.Quantity * item.Price;

                                connection.SaveChanges();

                                MessageBox.Show("Successfully added another " + ProductQuantity_ComboBox.SelectedItem.ToString() + " of " + item.Name + " to your shopping cart!");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message.ToString());
                        }
                    };

                    Item_StackPanel.Children.Add(ItemName_Label);
                    Item_StackPanel.Children.Add(Product_Image);
                    Item_StackPanel.Children.Add(ProductPrice_TextBlock);
                    Item_StackPanel.Children.Add(ProductQuantity_ComboBox);
                    Item_StackPanel.Children.Add(AddToCart_Button);

                    ItemSelection_WrapPanel.Children.Add(Item_StackPanel);
                }
            }
            else
            {
                Label NoCurrentProducts_Label = new Label();
                NoCurrentProducts_Label.FontSize = 36;
                NoCurrentProducts_Label.FontWeight = FontWeights.Bold;
                NoCurrentProducts_Label.HorizontalAlignment = HorizontalAlignment.Center;
                NoCurrentProducts_Label.VerticalAlignment = VerticalAlignment.Center;
                NoCurrentProducts_Label.Content = "No products found. Please visit us later again.";

                ItemSelection_WrapPanel.Children.Add(NoCurrentProducts_Label);
            }
            MessageBox.Show("Welcome to Bmazon! We're gonna lift your spirit with spirits!");
        }

        private void addItemsToUnitsInStockQuantityComboBox(ComboBox quantityComboBox)
        {
                for (int i = 1; i <= 99; i++)
                {
                    quantityComboBox.Items.Add(i);
                }
        }

    }
}
