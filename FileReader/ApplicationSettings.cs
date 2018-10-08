namespace FileReader
{
    using System;
    using Microsoft.Extensions.Configuration;

    public static class ApplicationSettings
    {
        public static string FileReaderBaseUrl { get; }
        public static string SharedDirectory { get; }


        static ApplicationSettings()
        {
            var settingsResolver = GetSettingsResolver();
            FileReaderBaseUrl = settingsResolver("Spike.FileReader.BaseUrl");
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