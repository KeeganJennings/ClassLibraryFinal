using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public abstract class DeliveryService : IDeliveryService
    {

        protected double costPerRefuel;

        public double CostPerRefuel { get { return costPerRefuel; } set { costPerRefuel = value; } }


        public IShippingVehicle ShippingVehicle { get; set; }


        protected IShippingVehicle shippingVehicle;

        public DeliveryService(IShippingVehicle vehicle)
        {
            ShippingVehicle = vehicle;
        }
    }
}