using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.InMemory
{
    public class ClassService : IClassService
    {
        private List<Class> _classes = new List<Class>();

        private readonly ITeacherService _teacherService;

        public ClassService(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        public void Add(Class entity)
        {
            entity.Id = GetNextId();
            var validator = new ClassValidator(_teacherService);
            ValidationTool.FluentValidate(validator, entity);
            _classes.Add(entity);
        }

        public void Delete(Class entity)
        {
            _classes.Remove(entity);
        }

        public Class Get(Func<Class, bool> filter) => _classes.FirstOrDefault(filter);

        public List<Class> GetAll(Func<Class, bool> filter = null) => filter is null ? _classes : _classes.Where(filter).ToList();

        public void Update(Class entity)
        {
            var validator = new ClassValidator(_teacherService);
            ValidationTool.FluentValidate(validator, entity);

            var updatedClass = _classes.FirstOrDefault(p => p.Id == entity.Id);
            if (updatedClass is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            updatedClass.TeacherId = entity.TeacherId;
            updatedClass.Teacher = entity.Teacher;
            updatedClass.ClassName = entity.ClassName;
        }
        private int GetNextId()
        {
            if (!_classes.Any())
            {
                return 1;
            }
            return _classes.Max(p => p.Id) + 1;
        }
    }
}
