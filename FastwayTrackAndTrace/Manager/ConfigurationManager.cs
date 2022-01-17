using FastwayTrackAndTrace.Model;
using FastwayTrackAndTrace.Properties;
using System;

namespace FastwayTrackAndTrace.Manager
{
    public class ConfigurationManager
    {
        public static void Initialize()
        {
            if (string.IsNullOrWhiteSpace(BaseUrl))
                BaseUrl = Default.Client.BASE_URL;

            if (string.IsNullOrWhiteSpace(ConfigurationManager.InvocationUrl))
                InvocationUrl = Default.Client.INVOCATION_URL;

            if (string.IsNullOrWhiteSpace(ApiKey))
                ApiKey = Default.Client.API_KEY;

            if (string.IsNullOrWhiteSpace(DefaultSaveLocation))
                DefaultSaveLocation = Default.File.DEFAULT_DIR;
        }

        public static string BaseUrl
        {
            get => Settings.Default.BaseUrl;
            set => Settings.Default.BaseUrl = value;
        }

        public static string InvocationUrl
        {
            get => Settings.Default.InvocationUrl;
            set => Settings.Default.InvocationUrl = value;
        }

        public static string ApiKey
        {
            get => Settings.Default.ApiKey;
            set => Settings.Default.ApiKey = value;
        }

        public static string DefaultSaveLocation
        {
            get => Settings.Default.DefaultSaveLocation;
            set => Settings.Default.DefaultSaveLocation = value;
        }

        public static void Save() => Settings.Default.Save();
    }
}
