using AutoMapper;
using Kaewsai.Sync.SyncApi.Domain.Model.Nominal;

namespace Kaewsai.Sync.SyncApi.Persistent.Model.Nominal
{
    public interface INominalCodePersistentMapper
    {
        NominalCode MapToDomain(NominalCodePersistent dbModel);
        NominalCodePersistent MapToPersistent(NominalCode dbModel);
    }

    public class NominalCodePersistentMapper : INominalCodePersistentMapper
    {
        private readonly IMapper _mapper;
        
        public NominalCodePersistentMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<NominalCodePersistent, NominalCode>();
                cfg.CreateMap<NominalCode, NominalCodePersistent>();
            });

            _mapper = config.CreateMapper();
        }

        public NominalCode MapToDomain(NominalCodePersistent dbModel)
        {
            return _mapper.Map<NominalCode>(dbModel);
        }
        
        public NominalCodePersistent MapToPersistent(NominalCode dbModel)
        {
            return _mapper.Map<NominalCodePersistent>(dbModel);
        }
    }
}