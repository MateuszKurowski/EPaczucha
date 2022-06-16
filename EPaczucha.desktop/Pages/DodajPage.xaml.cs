
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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
            var startDateString = DataNadania.Text;
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

            var city = Miasto.Text;
            var street = Ulica.Text;
            var buildingNmber = NumberBudynku.Text;
            int.TryParse(NumberMieszkania.Text, out var flatNumber);
            var zipCode = KodPocztowy.Text;

            if (string.IsNullOrEmpty(name)) throw new ArgumentNullException();
            if (startDateString == null) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(city)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(street)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(buildingNmber)) throw new ArgumentNullException();
            if (string.IsNullOrEmpty(zipCode)) throw new ArgumentNullException();
            if (zipCode.Length != 6 || zipCode[2] != '-') throw new ArgumentException();

            var gross = (net * 0.23M) + net;
            var endDate = DateTime.Parse(startDateString).AddDays(days);
            var startDate = DateTime.Parse(startDateString);

            var packageDto = new Package()
            {
                FlatNumber = flatNumber,
                BuildingNumber = buildingNmber,
                City = city,
                Street = street,
                ZipCode = zipCode,
                Price = gross,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
            };

            using (EPaczuchaDatabaseContext dbContext = new EPaczuchaDatabaseContext())
            {
                var index = dbContext.Packages.ToList().Count;
                packageDto.Id = index;
                dbContext.Packages.Add(packageDto);
                dbContext.SaveChanges();
            }
        }
    }
}