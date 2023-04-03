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
    public class HomeworkValidator : AbstractValidator<Homework>
    {
        private readonly IStudentService _studentService;
        public HomeworkValidator(IStudentService studentService)
        {

            _studentService = studentService;
            RuleFor(p => p.Title).NotEmpty().WithMessage("Ödev Başlığı Boş Geçilemez!");
            RuleFor(p => p.Text).NotEmpty().WithMessage("Ödev İçeriği Boş Geçilemez!");
            RuleFor(p => p.StudentId).NotEqual(default(int)).WithMessage("Öğrenci Id si Boş Geçilemez!");
            RuleFor(p => p.StudentId).Must((p, obj) => HasStudent(p.StudentId));
        }

        private bool HasStudent(int studentId) => _studentService.Get(p => p.Id == studentId) != null;
    }
}
