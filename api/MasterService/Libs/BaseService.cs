using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MasterService.Libs
{
    public interface IService<TEntity>
       where TEntity : class
    {
        Task<int> CountAll();
    }
    public abstract class BaseService<TEntity, TContext> : IService<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;

        public DbSet<TEntity> _entity { get; }

        public BaseService(TContext context)
        {
            this._context = context;
            this._entity = context.Set<TEntity>();
        }

        public async Task<int> CountAll()
        {
            return await _entity.CountAsync();
        }
    }
}
