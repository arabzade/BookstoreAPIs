using System;
namespace MongoBookApis
{
    public class MongoDbSettings
    {
        public string Host { get; set; }
        public int Port { get; set; }
        // computed property
        public string ConnectionString
        {
            get
            {
                return $"mongodb://{Host}:{Port}";
            }
        }
    }

}
