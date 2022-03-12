﻿using _1Valet.Device.Domain.Entities;
using _1Valet.Device.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Application.DTOs.Device
{
    public class DeviceResponse
    {
        public long DeviceId { get; set; }
        public decimal Temperature { get; set; }
        public string Info { get; set; }
        public string Usage { get; set; }
        public DeviceStatus Status { get; set; }
        //public List<Device> RelatedDevices { get; set; }

        //public List<DeviceUserDevice> DeviceUserDevices { get; set; }


        public int DeviceTypeId { get; set; }
        public DeviceType DeviceType { get; set; }
    }
}
