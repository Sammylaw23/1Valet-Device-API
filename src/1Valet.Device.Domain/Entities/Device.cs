using _1Valet.Device.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Domain.Entities
{
    public class Device
    {
        public int DeviceId { get; set; }
        public string Name { get; set; }
        public double Temperature { get; set; }
        public bool Online { get; set; }

        //public string Usage { get; set; }
        //public DeviceStatus Status { get; set; }
        //public List<Device> RelatedDevices { get; set; } list of Ids

        //public List<DeviceUserDevice> DeviceUserDevices { get; set; }


        public int DeviceTypeId { get; set; } //FK
        public DeviceType DeviceType { get; set; } 


    }



}
