using EPaczucha.desktop.Models;
using EPaczucha.desktop.Pages;

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

namespace EPaczucha.desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            FramePages.Content = new Pages.MainPage();
            Packages.PackageList = new List<PackageViewModel>();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Grid_DragOver(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
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

        public void MainPage_Click(object sender, RoutedEventArgs e)
        {
            FramePages.Content = new Pages.MainPage();
        }

        private void ListaPage_Click(object sender, RoutedEventArgs e)
        {
            FramePages.Content = new Pages.ListPage();
        }

        private void DodajPage_Click(object sender, RoutedEventArgs e)
        {
            FramePages.Content = new Pages.DodajPage();
        }
    }

    public static class Packages
    {
        public static List<PackageViewModel> PackageList { get; set; }

        public static void InitList()
        {
            PackageList.Add(new PackageViewModel()
            {
                DestinationApartmentNumber = "13",
                DestinationBuildingNumber = "12",
                DestinationCity = "Kraków",
                DestinationStreet = "Rynek",
                DestinationZipCode = "11-123",
                EndDate = "2022-06-16",
                PackagePrice = 13,
                SimpleName = "Zestaw urodzinowy",
                StartDate = "2022-06-09",
            });

            PackageList.Add(new PackageViewModel()
            {
                DestinationApartmentNumber = "11",
                DestinationBuildingNumber = "6",
                DestinationCity = "Warszawa",
                DestinationStreet = "Uczelniana",
                DestinationZipCode = "67-487",
                EndDate = "2022-06-11",
                PackagePrice = 32,
                SimpleName = "Pragmatyczny programista",
                StartDate = "2022-06-09",
            });
        }
    }
}