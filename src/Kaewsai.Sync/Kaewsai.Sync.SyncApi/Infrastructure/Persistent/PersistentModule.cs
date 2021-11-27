using Kaewsai.Sync.SyncApi.Persistent;
using Kaewsai.Sync.SyncApi.Persistent.Setting;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Kaewsai.Sync.SyncApi.Infrastructure.Persistent
{
    public static class PersistentModule
    {
        public static WebApplicationBuilder AddPersistentModule(this WebApplicationBuilder builder)
        {
            builder.Services.Configure<MongoDbSetting>(
                builder.Configuration.GetSection(nameof(MongoDbSetting)));

            builder.Services.AddMongoDbModule();
            return builder;
        }
    }
}