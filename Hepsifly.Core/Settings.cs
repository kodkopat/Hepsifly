using Newtonsoft.Json;
using System;
using System.IO;
using System.Reflection;

namespace Hepsifly.Core
{

    public static class Settings
    {

        private static readonly dynamic settingsJson = JsonConvert.DeserializeObject<dynamic>(File.ReadAllText(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "/settings" + (IsDevelopment ? ".Development" : "") + ".json"));
        public static  bool IsDevelopment { get { return Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development"; } }
        public class Database
        {
            public static string ConnectionString = settingsJson.Database.ConnectionString;

        }
        public class Redis
        {
            public static string Host = settingsJson.Redis.Host;
            public static string Port = settingsJson.Redis.Port;
        }
  
    }
}
