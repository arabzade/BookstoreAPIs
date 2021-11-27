using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoBookApis.Models
{
    public class OwnerClass
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public string OwnerName { get; set; }

        
    }
}
