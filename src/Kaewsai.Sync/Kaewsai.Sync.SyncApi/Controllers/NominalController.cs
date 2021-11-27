using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kaewsai.Sync.SyncApi.Domain.Model.Nominal;
using Kaewsai.Sync.SyncApi.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Kaewsai.Sync.SyncApi.Controllers
{
    [ApiController]
    [Route("nominal")]
    public class NominalController : ControllerBase
    {
        private readonly INominalRepository _nominalRepository;

        public NominalController(INominalRepository nominalRepository)
        {
            _nominalRepository = nominalRepository ?? throw new ArgumentNullException(nameof(nominalRepository));
        }

        [HttpPost(Name = "UploadNominal")]
        public Task<IEnumerable<NominalCode>> UploadNominal([FromBody] IEnumerable<NominalCode> request)
        {
            return _nominalRepository.Create(request);
        }
    }
}