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
    public class StudentValidator : AbstractValidator<Student>
    {
        private readonly IClassService _classService;
        private readonly IStudentService _studentService;

        public StudentValidator(IClassService classService, IStudentService studentService)
        {
            _classService = classService;
            _studentService = studentService;

            RuleFor(p => p.FirstName).NotEmpty().WithMessage("Öğrenci Adı Boş Geçilemez!");
            RuleFor(p => p.LastName).NotEmpty().WithMessage("Öğrenci Soyadı Boş Geçilemez!");
            RuleFor(p => p.ClassId).NotEqual(default(int)).WithMessage("Sınıf Id Boş Geçileme!");
            RuleFor(p => p.ClassId).Must((p, o) => HasClass(p.ClassId)).WithMessage(p => $"{p.Id} Id li Sınıf Bulunamadı. Sınıf Id si Geçerli olmalıdır.");
            RuleFor(p => p.ClassId).Must((p, o) => HasStudent(p.Id, p.StudentNumber)).WithMessage(p => $"{p.Id} Id li Sınıf Bulunamadı. Sınıf Id si Geçerli olmalıdır.");
        }

        private bool HasStudent(int studentId, int studentNumber)
        {
            var student = _studentService.Get(p => p.Id == studentId);
            if (student != null)
            {
                return true;
            }
            return _studentService.Get(p => p.StudentNumber == studentNumber) == null;
        }

        private bool HasClass(int classId) => _classService.Get(p => p.Id == classId) != null;

    }
}
