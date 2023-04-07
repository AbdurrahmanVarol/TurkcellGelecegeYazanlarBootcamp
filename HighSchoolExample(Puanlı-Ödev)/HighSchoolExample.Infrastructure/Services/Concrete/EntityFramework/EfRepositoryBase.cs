using HighSchoolExample.Core.Entities.Abstract;
using HighSchoolExample.Infrastructure.Services.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework
{
    public class EfRepositoryBase<TEmtity> : IServiceRepository<TEmtity> where TEmtity : class, IEntity, new()
    {
        private readonly InMemoryContext _context;

        public EfRepositoryBase(InMemoryContext context)
        {
            _context = context;
        }

        public virtual void Add(TEmtity entity)
        {
            var addedEntity = _context.Entry(entity);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public void Delete(TEmtity entity)
        {
            var deletedEntity = _context.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public TEmtity Get(Func<TEmtity, bool> filter) => _context.Set<TEmtity>().FirstOrDefault(filter);

        public List<TEmtity> GetAll(Func<TEmtity, bool> filter = null) => filter == null ? _context.Set<TEmtity>().ToList() : _context.Set<TEmtity>().Where(filter).ToList();

        public virtual void Update(TEmtity entity)
        {
            var updatedEntity = _context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
