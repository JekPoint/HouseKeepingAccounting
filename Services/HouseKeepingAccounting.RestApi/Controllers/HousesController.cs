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
    public class HousesController : ControllerBase
    {
        private readonly HousesService _service;

        public HousesController(HousesService service)
        {
            _service = service;
        }

        [HttpGet]
        [EnableQuery]
        public IEnumerable<House> GetHouse()
        {
            return _service.GetModelDbSet();
        }

        [HttpPut]
        public async Task<int> UpdateHouse(House counter)
        {
            return await _service.UpdateModel(counter);
        }

        [HttpPost]
        public async Task<ActionResult<House>> AddHouse(House counter)
        {
            return await _service.AddModel(counter);
        }

        [HttpDelete("{id}")]
        [EnableQuery]
        public async Task<DbSet<House>> DeleteHouse(int id)
        {

            return await _service.DeleteModel(id);
        }
    }
}
 