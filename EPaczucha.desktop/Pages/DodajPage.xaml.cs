using EPaczucha.core;
using EPaczucha.database;
using EPaczucha.desktop.Models;

using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for DodajPage.xaml
    /// </summary>
    public partial class DodajPage : Page
    {
        public DodajPage()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var name = NazwaPaczki.Text;
            var startDate = DataNadania.Text;
            var net = 0m;
            int days;
            switch (SposobWyslania.Text)
            {
                case "Ekonomiczna":
                    net += 8;
                    days = 7;
                    break;
                case "Priorytetowa":
                    net += 13;
                    days = 4;
                    break;
                default:
                    net += 18;
                    days = 2;
                    break;

            }
            switch(TypPaczki.Text)
            {
                case "Typ C":
                    net += 14;
                    break;
                case "Typ B":
                    net += 9;
                    break;
                default:
                    net += 5;
                    break;
            }
            var gross = (net * 0.23M) + net;
            var endDate = DateTime.Parse(startDate).AddDays(days).ToString();

            var city = Miasto.Text;
            var street = Ulica.Text;
            var buildingNmber = NumberBudynku.Text;
            var flatNumber = NumberMieszkania.Text;
            var zipCode = KodPocztowy.Text;
            
            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            if (startDate == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(street)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(buildingNmber)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(zipCode)) throw new ArgumentNullException();
            if (zipCode.Length != 6 || zipCode[2] != '-') throw new ArgumentException();

            var packageDto = new PackageViewModel()
            {
                DestinationApartmentNumber = flatNumber,
                DestinationBuildingNumber = buildingNmber,
                DestinationCity = city,
                DestinationStreet = street,
                DestinationZipCode = zipCode,
                EndDate = endDate,
                PackagePrice = gross,
                SimpleName = name,
                StartDate = startDate
            };

            Packages.PackageList.Add(packageDto);
        }
    }
}