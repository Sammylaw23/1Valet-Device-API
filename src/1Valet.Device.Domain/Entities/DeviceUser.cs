using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1Valet.Device.Domain.Entities
{
    public class DeviceUser
    {
        public long DeviceUserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        //public string Password { get; set; }
        public List<DeviceUserDevice> DeviceUserDevices { get; set; }

    }
}
