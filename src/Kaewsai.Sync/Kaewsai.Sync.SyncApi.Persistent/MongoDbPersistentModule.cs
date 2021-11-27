using Kaewsai.Sync.SyncApi.Domain.Repository;
using Kaewsai.Sync.SyncApi.Persistent.Model.Nominal;
using Kaewsai.Sync.SyncApi.Persistent.Repository;
using Kaewsai.Sync.SyncApi.Persistent.Setting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Kaewsai.Sync.SyncApi.Persistent
{
    public static class MongoDbPersistentModule
    {
        public static IServiceCollection AddMongoDbModule(this IServiceCollection services)
        {
            services.AddSingleton<IMongoDbSetting>(sp =>
                sp.GetRequiredService<IOptions<MongoDbSetting>>().Value);
            
            // Nominal
            services.AddTransient<INominalRepository, NominalRepository>();
            services.AddTransient<INominalCodePersistentMapper, NominalCodePersistentMapper>();

            return services;
        }
    }
}