using FluentValidation;
using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Validation.FluentValidation
{
    public class ClassValidator : AbstractValidator<Class>
    {
        private readonly ITeacherService _teacherService;

        public ClassValidator(ITeacherService teacherService)
        {
            _teacherService = teacherService;
            RuleFor(p => p.ClassName).NotEmpty().WithMessage("Sınıf Adı Boş Geçilemez.");
            RuleFor(p => p.TeacherId).NotEqual(default(int)).WithMessage("Öğretmen Id si Boş Geçilemez.");
            RuleFor(p => p.TeacherId).Must((obj, p) => HasTeacher(obj.TeacherId)).WithMessage("Öğretmen Id Si Geçersiz.");
        }

        private bool HasTeacher(int teacherId) => _teacherService.Get(p => p.Id == teacherId) != null;
    }
}
