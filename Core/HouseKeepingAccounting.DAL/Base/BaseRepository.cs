using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace HouseKeepingAccounting.DAL.Base
{
    public class BaseRepository : IDisposable
    {
        private IDbContextTransaction _transaction;

        public BaseRepository(HouseContext context)
        {
            Context = context;
        }

        public HouseContext Context { get; set; }
        public void CommitTransaction()
        {
            this.SaveChanges();
            this._transaction.Commit();
            this._transaction.Dispose();
            this._transaction = null;
        }

        /// <summary> Rollback Transaction </summary>
        public void RollbackTransaction()
        {
            this._transaction.Rollback();
            this._transaction.Dispose();
            this._transaction = null;
        }


        public void Dispose()
        {
            Context?.Dispose();
        }

        public void SaveChanges()
        {
            this.Context.SaveChanges();
        }

        public void BeginTransaction()
        {
            this._transaction = this.Context.Database.BeginTransaction();
        }

        /// <summary> Commit Transaction async </summary>
        public async ValueTask CommitTransactionAsync()
        {
            await this.SaveChangesAsync();
            this._transaction.Commit();
            this._transaction = null;
        }

        /// <summary> Save changes </summary>
        public async ValueTask SaveChangesAsync()
        {
            await this.Context.SaveChangesAsync();
        }

        /// <summary> Executes the given SQL against the database and returns the number of rows affected </summary>
        public async ValueTask<int> ExecuteSqlCommand(string sql, params object[] parameters)
        {
#pragma warning disable 618
            if (Context.Database != null)
            {
                return await Context.Database.ExecuteSqlCommandAsync(sql, parameters);
            }

            return 0;
#pragma warning restore 618
        }
    }
}
