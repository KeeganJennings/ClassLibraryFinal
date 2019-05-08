using ClassLibraryFinal;
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

namespace ClassLibraryFinalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IShippingVehicle vehicle;
        IDeliveryService delivery;
        DefaultShippingService shippingService;
        List<IProduct> products = new List<IProduct>();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void EnterBtn_Click(object sender, RoutedEventArgs e)
        {
            string zipcode = DestinationTxtb.Text;
            string service = ServiceTypecmbb.Text;

            Location newShippingLocation = new Location(zipcode);

            GetShippingService(service);
            


            shippingService = new DefaultShippingService(delivery, products, newShippingLocation);

            DisplayShippingCostAndRefuels();
        }

        private void DisplayShippingCostAndRefuels()
        {
            TextEntryTxtb.Text = $"The number of refuels from 60605 to {shippingService.ShippingLocation.DestinationZipCode} is {shippingService.NumRefuels}. The shipping distance is {shippingService.ShippingDistance}.";
        }

        public class Location : IShippingLocation
        {
            public uint StartZipCode { get; }

            public uint DestinationZipCode { get; }

            public Location (string zipcode)
            {
                StartZipCode = 60605;

                DestinationZipCode = Convert.ToUInt32(zipcode);
            }
        }

        public void GetShippingService(string service)
        {
            switch(service)
            {
                case "Delivery Service":
                    vehicle = new Truck();
                    delivery = new UnclesTruck(vehicle);
                    break;

                case "Shipping Service":
                    vehicle = new Plane();
                    delivery = new AirExpress(vehicle);
                    break;

                case "Shipping Vehicle":
                    vehicle = new ShippingSnail();
                    delivery = new SnailService(vehicle);
                    break;

            }
        }
    }
}
