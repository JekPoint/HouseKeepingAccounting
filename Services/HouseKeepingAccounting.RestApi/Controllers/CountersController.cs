using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using HouseKeepingAccounting.RestApi.Base;
using HouseKeepingAccounting.RestApi.Services;
using HouseKeepingAccounting.RestApi.ViewModel;
using Microsoft.AspNet.OData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HouseKeepingAccounting.RestApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CountersController : ControllerBase
    {
        private readonly CountersService _service;
        private readonly HouseContext _houseContext;

        public CountersController(CountersService service, HouseContext houseContext)
        {
            _service = service;
            _houseContext = houseContext;
        }

        [HttpGet]
        [EnableQuery]
        public IQueryable<Counter> GetCounter()
        {
            return _houseContext.Counters;
        }

        [HttpPut]
        public async Task<ActionResult<int>> UpdateCounter(CounterViewModel counter)
        {
            var response = await _service.UpdateCounter(counter);
            if (response.Status == ServiceResponseStatus.NotFound)
            {
                return NotFound(response.Result);
            }

            if (response.Status == ServiceResponseStatus.Ok && response.Result is int result)
            {
                return result;
            }

            return BadRequest(response.Result);
        }

        [HttpPost]
        public async Task<ActionResult<CounterViewModel>> AddCounter(CounterAddModel model)
        {
            var response =  await _service.AddCounter(model);
            if (response.Status == ServiceResponseStatus.NotFound)
            {
                return NotFound(response.Result);
            }

            if (response.Status == ServiceResponseStatus.Ok && response.Result is CounterViewModel result)
            {
                return result;
            }

            return BadRequest(response.Result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteCounter(int id)
        {
            var response = await _service.DeleteCounter(id);
            
            if (response.Status == ServiceResponseStatus.NotFound)
            {
                return NotFound(response.Result);
            }

            if (response.Status == ServiceResponseStatus.Ok)
            {
                return true;
            }

            return BadRequest(response.Result);
        }
    }
}
