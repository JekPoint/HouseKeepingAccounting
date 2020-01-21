using HouseKeepingAccounting.BaseApi.Base;
using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.BaseApi.Services
{
    public class CountersService : BaseService<Counter>
    {
        public CountersService(HouseContext context, ILogger<CountersService> logger) 
            : base(context, logger, context.Counters, nameof(CountersService))
        {
        }
    }
}
