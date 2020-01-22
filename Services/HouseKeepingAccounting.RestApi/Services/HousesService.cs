using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using HouseKeepingAccounting.RestApi.Base;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.RestApi.Services
{
    public class HousesService : BaseService<House>
    {
        public HousesService(HouseContext context, ILogger<CountersService> logger) 
            : base(context, logger, context.Houses, nameof(HousesService))
        {
        }
    }
}
