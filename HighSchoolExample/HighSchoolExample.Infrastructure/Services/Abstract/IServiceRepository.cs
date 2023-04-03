using HighSchoolExample.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Abstract
{
    public interface IServiceRepository<TEntity> where TEntity : class,IEntity,new()
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        TEntity Get(Func<TEntity, bool> filter);
        List<TEntity> GetAll(Func<TEntity,bool> filter = null);

    }
}
