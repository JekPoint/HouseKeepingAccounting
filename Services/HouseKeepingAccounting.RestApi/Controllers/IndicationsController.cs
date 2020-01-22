using System.Collections.Generic;
using System.Threading.Tasks;
using HouseKeepingAccounting.DAL.Models;
using HouseKeepingAccounting.RestApi.Services;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseKeepingAccounting.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class IndicationsController : ControllerBase
    {
        private readonly IndicationsService _service;

        public IndicationsController(IndicationsService service)
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<Indication> GetCounters()
        {
            return _service.GetModelDbSet();
        }

        [HttpPut]
        public async Task<int> UpdateCounter(Indication counter)
        {
            return await _service.UpdateModel(counter);
        }

        [HttpPost]
        public async Task<ActionResult<Indication>> AddIndication(Indication counter)
        {
            return await _service.AddModel(counter);
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        public async Task<DbSet<Indication>> DeleteIndication(int id)
        {

            return await _service.DeleteModel(id);
        }
    }
}
