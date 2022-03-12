﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Domain.Entities
{
    public class DeviceType
    {
        public int DeviceTypeId { get; set; }
        public string Name { get; set; } //(Phone, tablet, PC), 
        public string Description { get; set; }

        public ICollection<Device> Devices { get; set; }

    }
}
