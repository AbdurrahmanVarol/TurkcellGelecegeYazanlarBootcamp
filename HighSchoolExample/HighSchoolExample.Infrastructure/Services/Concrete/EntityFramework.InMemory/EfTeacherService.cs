using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Validation.FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework.InMemory
{
    public class EfTeacherService : EfRepositoryBase<Teacher>, ITeacherService
    {
        public EfTeacherService(InMemoryContext context) : base(context)
        {
        }
        public override void Add(Teacher entity)
        {
            var validator = new TeacherValidator();
            ValidationTool.FluentValidate(validator, entity);
            base.Add(entity);
        }
        public override void Update(Teacher entity)
        {
            var validator = new TeacherValidator();
            ValidationTool.FluentValidate(validator, entity);
            base.Update(entity);
        }
    }
}
