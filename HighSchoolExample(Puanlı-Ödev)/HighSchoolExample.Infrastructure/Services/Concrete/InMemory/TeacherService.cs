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
    public class TeacherService : ITeacherService
    {
        private List<Teacher> _teachers = new List<Teacher>();

        public void Add(Teacher entity)
        {
            entity.Id = GetNextId();

            ValidationTool.FluentValidate(new TeacherValidator(), entity);
            _teachers.Add(entity);
        }

        public void Delete(Teacher entity)
        {
            _teachers.Remove(entity);
        }

        public Teacher Get(Func<Teacher, bool> filter) => _teachers.FirstOrDefault(filter);

        public List<Teacher> GetAll(Func<Teacher, bool> filter = null) => filter is null ? _teachers : _teachers.Where(filter).ToList();

        public void Update(Teacher entity)
        {
            ValidationTool.FluentValidate(new TeacherValidator(), entity);

            var updatedTeacher = _teachers.FirstOrDefault(p => p.Id == entity.Id);
            if (updatedTeacher is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            updatedTeacher.FirstName = entity.FirstName;
            updatedTeacher.LastName = entity.LastName;
        }
        private int GetNextId() => _teachers.Select(p => p.Id).DefaultIfEmpty(1).Max();
    }
}
