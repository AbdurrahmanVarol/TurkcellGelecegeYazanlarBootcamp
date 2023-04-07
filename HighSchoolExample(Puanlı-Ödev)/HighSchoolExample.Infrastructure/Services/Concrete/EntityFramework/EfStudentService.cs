using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework
{
    public class EfStudentService : EfRepositoryBase<Student>, IStudentService
    {
        private readonly IClassService _classService;
        public EfStudentService(InMemoryContext context, IClassService classService) : base(context)
        {
            _classService = classService;
        }
        public override void Add(Student entity)
        {
            var validator = new StudentValidator(_classService, this);
            ValidationTool.FluentValidate(validator, entity);
            base.Add(entity);
        }
        public override void Update(Student entity)
        {
            var validator = new StudentValidator(_classService, this);
            ValidationTool.FluentValidate(validator, entity);
            base.Update(entity);
        }
    }
}
