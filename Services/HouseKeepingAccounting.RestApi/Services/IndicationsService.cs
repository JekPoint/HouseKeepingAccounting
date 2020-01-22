using HouseKeepingAccounting.DAL;
using HouseKeepingAccounting.DAL.Models;
using HouseKeepingAccounting.RestApi.Base;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.RestApi.Services
{
    public class IndicationsService : BaseService<Indication>
    {
        public IndicationsService(HouseContext context, ILogger<CountersService> logger) 
            : base(context, logger, context.Indications, nameof(IndicationsService))
        {
        }
    }
}
