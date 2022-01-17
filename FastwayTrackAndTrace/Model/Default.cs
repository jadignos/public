namespace FastwayTrackAndTrace.Model
{
    public class Default
    {
        public class Client
        {
            public const string BASE_URL = "https://au.api.fastway.org";
            public const string INVOCATION_URL = "v5/tracktrace/detail";
            public const string API_KEY = "KEY";
        }

        public class File
        {
            public const string DEFAULT_DIR = @"C:\ExportedFiles\";
        }

        public class Input
        {
            public const int MAX_LINES = 5000;
        }
    }
}
