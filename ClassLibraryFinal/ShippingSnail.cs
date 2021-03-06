﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClassLibraryFinal
{
    public class ShippingSnail : Snail, IShippingVehicle
    {
        public uint TopSpeed { get; set; }
        public uint MaxDistancePerRefuel { get; set; }

        public uint MaxWeight { get; set; }

        public ShippingSnail()
        {
            TopSpeed = 1;
            MaxWeight = 1;
            MaxDistancePerRefuel = 20;
        }
    }
}