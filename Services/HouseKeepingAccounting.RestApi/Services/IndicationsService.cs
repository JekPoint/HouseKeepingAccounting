using HouseKeepingAccounting.BaseApi.Base;
using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.BaseApi.Services
{
    public class IndicationsService : BaseService<Indication>
    {
        public IndicationsService(HouseContext context, ILogger<CountersService> logger) 
            : base(context, logger, context.Indications, nameof(IndicationsService))
        {
        }
    }
}
