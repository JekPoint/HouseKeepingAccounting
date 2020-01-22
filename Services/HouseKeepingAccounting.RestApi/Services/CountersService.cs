using System;
using System.Threading.Tasks;
using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using HouseKeepingAccounting.RestApi.Base;
using HouseKeepingAccounting.RestApi.ViewModel;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.RestApi.Services
{
    public class CountersService
    {
        private readonly HouseContext _context;
        private readonly MapperService _mapperService;
        private readonly ILogger<CountersService> _logger;
        private readonly string _serviceName;

        public CountersService(HouseContext context,
            MapperService mapperService,
            ILogger<CountersService> logger)
        {
            _context = context;
            _mapperService = mapperService;
            _logger = logger;
            _serviceName = nameof(CountersService);
        }

        public async Task<ServiceResponse> UpdateCounter(CounterViewModel model)
        {
            _logger.LogInformation(@$"{_serviceName} Update {nameof(Counter)}", model);
            _context.Entry(model).State = EntityState.Modified;
            _logger.LogInformation(@$"{_serviceName} Update {nameof(Counter)} complete", model);

            var resultUpdate = await _context.SaveChangesAsync();
            if (resultUpdate == 1)
            {
                return new ServiceResponse()
                {
                    Status = ServiceResponseStatus.Ok,
                    Result = resultUpdate
                };
            }

            return new ServiceResponse()
            {
                Status = ServiceResponseStatus.NotFound,
                Result = $"Update {nameof(Counter)} id={model.Id} not found"
            };
        }

        public async Task<ServiceResponse> AddCounter(CounterAddModel model)
        {            
            var home = await _context.Houses.FirstOrDefaultAsync(x => x.Id == model.HouseId);
            if (home == null)
            {
                return new ServiceResponse()
                {
                    Result = $"House id {model.HouseId} not found",
                    Status = ServiceResponseStatus.NotFound
                };
            }

            _logger.LogInformation(@$"{_serviceName} Add {nameof(Counter)}", model);
            var counter = _mapperService.Mapper.Map<CounterAddModel, Counter>(model);
            _context.Counters.Add(counter);

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception exception)
            {
                return HandleException.HandleSqlException(exception);
            }

            _logger.LogInformation(@$"{_serviceName} Add {nameof(Counter)} complete", model);

            return new ServiceResponse()
            {
                Status =  ServiceResponseStatus.Ok,
                Result = _mapperService.Mapper.Map<Counter, CounterViewModel>(counter)
            };
        }

        public async Task<ServiceResponse> DeleteCounter(int id)
        {
            _logger.LogInformation(@$"{_serviceName} Delete {nameof(Counter)} id {id}");

            var model = await _context.Counters.FindAsync(id);
            if (model == null)
            {
                _logger.LogInformation(@$"{_serviceName} Delete {nameof(Counter)} id {id} not found");

                return new ServiceResponse()
                {
                    Status = ServiceResponseStatus.NotFound,
                    Result = $"Delete {nameof(Counter)} id {id} not found"
                };
            }

            _context.Counters.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation(@$"{_serviceName} Delete {nameof(Counter)} id {id} complete", model);

            return new ServiceResponse
            {
                Status = ServiceResponseStatus.Ok,
                Result = _context.Counters
            };
        }
    }
}
