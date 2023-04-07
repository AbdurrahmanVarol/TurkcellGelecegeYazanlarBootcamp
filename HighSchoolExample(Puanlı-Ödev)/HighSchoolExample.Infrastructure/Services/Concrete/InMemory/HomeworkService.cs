using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.InMemory
{
    public class HomeworkService : IHomeworkService
    {
        private List<Homework> _homeworks = new List<Homework>();

        private IStudentService _studentService;

        public HomeworkService(IStudentService studentService)
        {
            _studentService = studentService;
        }

        public void Add(Homework homework)
        {
            homework.Id = GetNextId();

            ValidationTool.FluentValidate(new HomeworkValidator(_studentService), homework);
            _homeworks.Add(homework);
        }

        public Homework Get(Func<Homework, bool> filter) => _homeworks.FirstOrDefault(filter);

        public List<Homework> GetAll(Func<Homework, bool> filter = null) => filter == null ? _homeworks : _homeworks.Where(filter).ToList();
        private int GetNextId() => _homeworks.Select(p => p.Id).DefaultIfEmpty(1).Max();
    }
}
