using AutoMapper;
using HouseKeepingAccounting.DAL.Models;
using HouseKeepingAccounting.RestApi.ViewModel;

namespace HouseKeepingAccounting.RestApi.Services
{
    public class MapperService
    {
        public MapperService()
        {
            var config = new MapperConfiguration(cfg => 
            {
                cfg.CreateMap<CounterAddModel, Counter>();
                cfg.CreateMap<Counter, CounterViewModel>();
            });

            Mapper = config.CreateMapper();
        }

        public IMapper Mapper { get; set; }
    }
}
