using FluentValidation;
using HighSchoolExample.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Validation.FluentValidation
{
    public class TeacherValidator : AbstractValidator<Teacher>
    {
        public TeacherValidator()
        {
            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Öğrenci Adı Boş Geçilemez!");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Öğrenci Soyadı Boş Geçilemez!");
        }
    }
}
