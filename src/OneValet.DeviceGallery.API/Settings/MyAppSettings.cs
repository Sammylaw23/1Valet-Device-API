namespace OneValet.DeviceGallery.API.Settings
{
    public class MyAppSettings
    {
        public Logging Logging { get; set; }
        public Connectionstrings ConnectionStrings { get; set; }
    }

    public class Logging
    {
        public Loglevel LogLevel { get; set; }
    }

    public class Loglevel
    {
        public string Default { get; set; }
        public string MicrosoftAspNetCore { get; set; }
    }

    public class Connectionstrings
    {
        public string ApplicationDbConnectionString { get; set; }
    }
}


