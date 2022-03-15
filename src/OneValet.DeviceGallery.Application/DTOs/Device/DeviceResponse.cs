using OneValet.DeviceGallery.Domain.Entities;
using OneValet.DeviceGallery.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneValet.DeviceGallery.Application.DTOs.Device
{
    public class DeviceResponse
    {
        public int DeviceId { get; set; }
        public double TemperatureC { get; set; }
        //public string Info { get; set; }
        //public string Usage { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string IconBase64String { get; set; }
        public bool Online { get; set; }

        //public int DeviceTypeId { get; set; }
        //public DeviceType DeviceType { get; set; }




        //public List<Device> RelatedDevices { get; set; }

        //public List<DeviceUserDevice> DeviceUserDevices { get; set; }



    }
}
