using System;
using System.IO;
using System.Windows;
using DotNetEnv;

namespace SearchEngine
{
    class Config
    {
        public readonly string apiKey;
        public readonly string searchEngineID;

        public Config()
        {
            Env.Load("../../../.env");

            apiKey = Environment.GetEnvironmentVariable("API_KEY");
            searchEngineID = Environment.GetEnvironmentVariable("SEARCH_ENGINE_ID");
        }

    }
}
