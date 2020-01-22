using HouseKeepingAccounting.BaseApi.Base;
using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.BaseApi.Services
{
    public class HousesService : BaseService<House>
    {
        public HousesService(HouseContext context, ILogger<CountersService> logger) 
            : base(context, logger, context.Houses, nameof(HousesService))
        {
        }
    }
}
