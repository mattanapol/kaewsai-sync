using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kaewsai.Sync.SyncApi.Domain.Model.Nominal;
using Kaewsai.Sync.SyncApi.Domain.Repository;
using Kaewsai.Sync.SyncApi.Persistent.Model.Nominal;
using Kaewsai.Sync.SyncApi.Persistent.Setting;
using MongoDB.Driver;

namespace Kaewsai.Sync.SyncApi.Persistent.Repository
{
    public class NominalRepository: INominalRepository
    {
        private readonly IMongoCollection<NominalCodePersistent> _nominalCodes;
        private readonly INominalCodePersistentMapper _mapper;

        public NominalRepository(IMongoDbSetting settings, INominalCodePersistentMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _nominalCodes = database.GetCollection<NominalCodePersistent>(settings.NominalCollectionName);
        }
        
        public List<NominalCodePersistent> Get() =>
            _nominalCodes.Find(nominalCode => true).ToList();

        public NominalCodePersistent Get(string id) =>
            _nominalCodes.Find(nominalCode => nominalCode.Id == id).FirstOrDefault();

        public NominalCode Create(NominalCode nominalCode)
        {
            _nominalCodes.InsertOne(_mapper.MapToPersistent(nominalCode));
            return nominalCode;
        }

        public async Task<IEnumerable<NominalCode>> Create(IEnumerable<NominalCode> nominalCodes)
        {
            await _nominalCodes.InsertManyAsync(nominalCodes.Select(code => _mapper.MapToPersistent(code)));
            return nominalCodes;
        }

        public void Update(string id, NominalCodePersistent nominalCodeIn) =>
            _nominalCodes.ReplaceOne(nominalCode => nominalCode.Id == id, nominalCodeIn);

        public void Remove(NominalCodePersistent nominalCodeIn) =>
            _nominalCodes.DeleteOne(nominalCode => nominalCode.Id == nominalCodeIn.Id);

        public void Remove(string id) => 
            _nominalCodes.DeleteOne(nominalCode => nominalCode.Id == id);
    }
}