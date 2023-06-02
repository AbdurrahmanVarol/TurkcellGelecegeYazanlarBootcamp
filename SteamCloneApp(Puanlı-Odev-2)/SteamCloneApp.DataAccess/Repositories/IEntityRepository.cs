using SteamCloneApp.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.DataAccess.Repositories
{
    public interface IEntityRepository<TEntity> where TEntity : class, IEntity
    {
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter);
        Task<ICollection<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null);
    }
}
