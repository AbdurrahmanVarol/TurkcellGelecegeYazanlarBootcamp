using HighSchoolExample.Core.Entities.Abstract;
using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Validation.FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework
{
    public class EfHomewotkService : IHomeworkService
    {
        private readonly InMemoryContext _context;
        private IStudentService _studentService;

        public EfHomewotkService(InMemoryContext context, IStudentService studentService)
        {
            _context = context;
            _studentService = studentService;
        }

        public void Add(Homework homework)
        {
            var validator = new HomeworkValidator(_studentService);
            ValidationTool.FluentValidate(validator, homework);
            var addedEntity = _context.Entry(homework);
            addedEntity.State = EntityState.Added;
            _context.SaveChanges();
        }

        public Homework Get(Func<Homework, bool> filter) => _context.Homeworks.FirstOrDefault(filter);

        public List<Homework> GetAll(Func<Homework, bool> filter = null) => filter == null ? _context.Homeworks.ToList() : _context.Homeworks.Where(filter).ToList();
    }
}
