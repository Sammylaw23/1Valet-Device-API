using OneValet.DeviceGallery.Application.DTOs.Device;
using OneValet.DeviceGallery.Application.Wrappers;
using OneValet.DeviceGallery.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OneValet.DeviceGallery.API.UnitTests.MockData
{
    public class DeviceMockData
    {
        public static Response<IEnumerable<DeviceResponse>> GetDevices()
        {
            var response = new List<DeviceResponse>
            {

                new DeviceResponse()
                {
                    Id = 9,
                    Name = "Nokia 3310",
                    IconBase64String = "dfergfr",
                    Online = true,
                    TemperatureC = 15.3
                },
                 new DeviceResponse()
                {
                    Id = 10,
                    Name = "Nokia 3310",
                    IconBase64String = "dfergfr",
                    Online = true,
                    TemperatureC = 15.3
                }


            };

            return new Response<IEnumerable<DeviceResponse>>(response.AsEnumerable());






        }



        public static List<Device> GetDevicesEntity()
        {
            return new List<Device>
            {
                  new Device {
                    Id = 11,
                    Name = "Nokia 7 Plus",
                    TemperatureC =  49,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = true
                  },
                  new Device {
                      Id=12,
                    Name = "iPad 11",
                    TemperatureC =  67,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  },
                  new Device {
                      Id=13,
                    Name = "HP Elitebook",
                    TemperatureC =  72,
                    IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                    Online = false
                  }
                  //,
                  //new Device {
                  //    Id=4,
                  //  Name = "Samsung Tablet",
                  //  TemperatureC =  31,
                  //  IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                  //  Online = false
                  //},
                  //new Device {
                  //    Id=5,
                  //  Name = "DELL 205",
                  //  TemperatureC =  55,
                  //  IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                  //  Online = false
                  //},
                  //new Device {
                  //    Id=6,
                  //  Name = "Tecno Spark 6",
                  //  TemperatureC =  84,
                  //  IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                  //  Online = false
                  //},
                  //new Device {
                  //    Id=7,
                  //  Name = "iPhone 13 Pro Max",
                  //  TemperatureC =  50,
                  //  IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                  //  Online = true
                  //},
                  //new Device {
                  //    Id = 8,
                  //  Name = "Nokia 3310",
                  //  TemperatureC =  37,
                  //  IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                  //  Online = false
                  //}
            };
        }

        public static DeviceRequest AddDevice()
        {
            return new DeviceRequest()
            {
                Name = "Nokia 3310",
                TemperatureC = 49,
                IconBase64String = "FLKLihJHggJJKklKOhjGJkjKLkLJKjhjHHkhhjgJKJLklkh",
                Online = true
            };
        }
    }
}
