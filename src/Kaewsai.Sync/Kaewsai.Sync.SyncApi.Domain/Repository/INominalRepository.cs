using System.Collections.Generic;
using System.Threading.Tasks;
using Kaewsai.Sync.SyncApi.Domain.Model.Nominal;

namespace Kaewsai.Sync.SyncApi.Domain.Repository
{
    public interface INominalRepository
    {
        NominalCode Create(NominalCode nominalCode);
        Task<IEnumerable<NominalCode>> Create(IEnumerable<NominalCode> nominalCodes);
    }
}