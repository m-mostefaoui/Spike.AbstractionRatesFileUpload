namespace FileUpload
{
    using System;
    using Microsoft.Extensions.Configuration;

    public static class ApplicationSettings
    {
        public static string FileUploadBaseUrl { get; }
        public static string SharedDirectory { get; }


        static ApplicationSettings()
        {
            var settingsResolver = GetSettingsResolver();
            FileUploadBaseUrl = settingsResolver("Spike.FileUpload.BaseUrl");
            SharedDirectory = settingsResolver("Spike.SharedDirectory");
        }

        private static Func<string, string> GetSettingsResolver()
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.json");
            var configuration = configurationBuilder.Build();

            return (name) => configuration.GetSection(name).Value;
        }
    }
}