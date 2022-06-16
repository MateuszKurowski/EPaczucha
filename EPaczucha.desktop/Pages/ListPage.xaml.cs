using EPaczucha.desktop.Models;

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

namespace EPaczucha.desktop.Pages
{
    /// <summary>
    /// Interaction logic for ListPage.xaml
    /// </summary>
    public partial class ListPage : Page
    {
        public List<Package> Packages { get; set; }

        public ListPage()
        {
            InitializeComponent();

            using (EPaczuchaDatabaseContext dbContext = new EPaczuchaDatabaseContext())
            {
                Packages = dbContext.Packages.ToList();
            }

            lvDataBinding.ItemsSource = Packages;
        }

        private void Premium_Dialog(object sender, RoutedEventArgs e)
        {
            string messageBoxText = "Funkcja dostępna tylko dla użytkowników premium.";
            string caption = "Premium only";
            MessageBoxButton button = MessageBoxButton.OK;
            MessageBoxImage icon = MessageBoxImage.Warning;
            MessageBoxResult result;

            result = MessageBox.Show(messageBoxText, caption, button, icon, MessageBoxResult.OK);
        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var index = lvDataBinding.SelectedIndex;

            if (index > -1)
            {
                Packages.RemoveAt(index);
                using (EPaczuchaDatabaseContext dbContext = new EPaczuchaDatabaseContext())
                {
                    dbContext.Remove(Packages[index - 1]);
                    dbContext.SaveChanges();
                }
            }
        }
    }
}
