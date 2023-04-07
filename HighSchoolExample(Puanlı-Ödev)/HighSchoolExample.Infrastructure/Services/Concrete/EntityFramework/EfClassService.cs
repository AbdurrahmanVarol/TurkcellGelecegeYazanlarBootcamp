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
    public class EfClassService : EfRepositoryBase<Class>, IClassService
    {
        private readonly ITeacherService _teacherService;
        public EfClassService(InMemoryContext context, ITeacherService teacherService) : base(context)
        {
            _teacherService = teacherService;
        }
        public override void Add(Class entity)
        {
            var validator = new ClassValidator(_teacherService);
            ValidationTool.FluentValidate(validator, entity);
            base.Add(entity);
        }
        public override void Update(Class entity)
        {
            var validator = new ClassValidator(_teacherService);
            ValidationTool.FluentValidate(validator, entity);
            base.Update(entity);
        }
    }
}
