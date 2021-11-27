using Kaewsai.Sync.SyncApi.Domain.Model.Nominal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Kaewsai.Sync.SyncApi.Persistent.Model.Nominal
{
    public class NominalCodePersistent: NominalCode
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }
    }
}