using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework.InMemory;
using HighSchoolExample.Infrastructure.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.InMemory
{
    public class StudentService : IStudentService
    {
        private List<Student> _students = new List<Student>();

        private readonly IClassService _classService;

        public StudentService(IClassService classService)
        {
            _classService = classService;
        }

        public void Add(Student entity)
        {
            var validator = new StudentValidator(_classService, this);
            ValidationTool.FluentValidate(validator, entity);
            _students.Add(entity);
        }

        public void Delete(Student entity)
        {
            _students.Remove(entity);
        }

        public Student Get(Func<Student, bool> filter) => _students.FirstOrDefault(filter);

        public List<Student> GetAll(Func<Student, bool> filter = null) => filter is null ? _students : _students.Where(filter).ToList();

        public void Update(Student entity)
        {
            var validator = new StudentValidator(_classService, this);
            ValidationTool.FluentValidate(validator, entity);

            var updatedStudent = _students.FirstOrDefault(p => p.Id == entity.Id);
            if (updatedStudent is null)
            {
                throw new ArgumentNullException(nameof(entity));
            }
            updatedStudent.StudentNumber = entity.StudentNumber;
            updatedStudent.FirstName = entity.FirstName;
            updatedStudent.LastName = entity.LastName;
            updatedStudent.ClassId = entity.ClassId;
            updatedStudent.Class = entity.Class;
        }
        private int GetNextId()
        {
            if (!_students.Any())
            {
                return 1;
            }
            return _students.Max(p => p.Id) + 1;
        }
    }
}
