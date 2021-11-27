namespace Kaewsai.Sync.SyncApi.Persistent.Setting
{
    public interface IMongoDbSetting
    {
        string? NominalCollectionName { get; set; }
        string? ConnectionString { get; set; }
        string? DatabaseName { get; set; }
    }

    public class MongoDbSetting : IMongoDbSetting
    {
        public string? NominalCollectionName { get; set; }
        public string? ConnectionString { get; set; }
        public string? DatabaseName { get; set; }
    }
}