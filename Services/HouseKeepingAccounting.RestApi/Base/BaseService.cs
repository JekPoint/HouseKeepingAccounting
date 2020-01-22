using System.Threading.Tasks;
using HouseKeepingAccounting.BaseApi.Services;
using HouseKeepingAccounting.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HouseKeepingAccounting.BaseApi.Base
{
    public abstract class BaseService<T>
        where T : class
    {
        private readonly HouseContext _context;
        private readonly ILogger<CountersService> _logger;
        private readonly DbSet<T> _dbSet;
        private readonly string _serviceName;

        protected BaseService(HouseContext context, 
            ILogger<CountersService> logger, 
            DbSet<T> dbSet,
            string serviceName)
        {
            _context = context;
            _logger = logger;
            _dbSet = dbSet;
            _serviceName = serviceName;
        }

        public DbSet<T> GetModelDbSet()
        {
            _logger.LogInformation(@$"{_serviceName} Get Counters");
            return _dbSet;
        }

        public virtual async Task<int> UpdateModel(T model)
        {
            _logger.LogInformation(@$"{_serviceName} Update {nameof(T)}", model);
            _context.Entry(model).State = EntityState.Modified;
            _logger.LogInformation(@$"{_serviceName} Update {nameof(T)} complete", model);
            return await _context.SaveChangesAsync();
        }

        public virtual async Task<T> AddModel(T model)
        {
            _logger.LogInformation(@$"{_serviceName} Add {nameof(T)}", model);
            _dbSet.Add(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation(@$"{_serviceName} Add {nameof(T)} complete", model);
            return model;
        }

        public virtual async Task<DbSet<T>> DeleteModel(int id)
        {
            _logger.LogInformation(@$"{_serviceName} Delete {nameof(T)} id {id}");

            var model = await _dbSet.FindAsync(id);
            if (model == null)
            {
                _logger.LogInformation(@$"{_serviceName} Delete {nameof(T)} id {id} not found");

                return _dbSet;
            }

            _dbSet.Remove(model);
            await _context.SaveChangesAsync();
            _logger.LogInformation(@$"{_serviceName} Delete {nameof(T)} id {id} complete", model);

            return _dbSet;
        }
    }
}
