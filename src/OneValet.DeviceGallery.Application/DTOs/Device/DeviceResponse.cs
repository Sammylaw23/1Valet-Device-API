namespace OneValet.DeviceGallery.Application.DTOs.Device
{
    public class DeviceResponse
    {
        //public DeviceResponse()
        //{

        //}
        public int Id { get; set; }
        public double TemperatureC { get; set; }
        
        public string Status { get; set; }
        public string Name { get; set; }
        public string IconBase64String { get; set; }
        public bool Online { get; set; }



    }
}
