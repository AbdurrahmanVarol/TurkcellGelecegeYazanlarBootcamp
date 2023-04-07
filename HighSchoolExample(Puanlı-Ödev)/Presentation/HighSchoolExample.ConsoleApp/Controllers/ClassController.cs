using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure;
using HighSchoolExample.Infrastructure.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace HighSchoolExample.ConsoleApp.Controllers
{
    public class ClassController : IController
    {
        private readonly ITeacherService _teacherService;
        private readonly IClassService _classesService;
        private readonly IStudentService _studentService;

        public ClassController(ITeacherService teacherService, IClassService classesService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _classesService = classesService;
            _studentService = studentService;
        }
        public void AddClass()
        {
            var teachers = _teacherService.GetAll();

            if (!teachers.Any())
            {
                WriteLine("Şu Anda Kayıtlı Hiç Bir Öğretmen Bulunamadı. Lütfen Bir Öğretmen Ekledikten Sonra Tekrar Deneyiniz.");
                return;
            }

            WriteLine("Lütfen Eklemek İstediğiniz Sınıfın İsmini Giriniz:");
            var className = ReadLine();

            int teacherId;

            WriteLine("Öğretmen Id sini Giriniz:");
            while (!int.TryParse(ReadLine(), out teacherId))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
            }

            var teacher = _teacherService.Get(p => p.Id == teacherId);

            var newClass = new Class
            {
                ClassName = className,
                TeacherId = teacherId,
                Teacher = teacher,
            };

            var result = ExceptionHandler.Handle(() =>
            {
                _classesService.Add(newClass);
            });
            if (result.IsSuccess)
            {
                WriteLine("Sınıf Eklendi.");
            }
            else
            {
                WriteLine(result.Message);
            }
        }
        public void ShowAllClassess()
        {
            var classes = _classesService.GetAll();
            if (!classes.Any())
            {
                WriteLine("Şu Anda Hiç Kayıtlı Sınıf Olmadığı İçin Listeleme İşlemi Yapılamıyor. Lütfen Sınıf Ekledikten Sonra Tekrar Deneyiniz.");
                return;
            }
            WriteLine("Sınıf Listesi: ");
            for (int i = 0; i < classes.Count; i++)
            {
                WriteLine($"\t{i + 1} - {classes[i]}");
            }
        }
        public void ShowClassDetails()
        {
            int classId;
            WriteLine("Sınıf Id sini Giriniz:");
            while (!int.TryParse(ReadLine(), out classId))
            {
                WriteLine("Lütfen geçerli bir sayı giriniz");
            }

            var @class = _classesService.Get(p => p.Id == classId);
            if (@class is null)
            {
                WriteLine($"{classId} Id li Sınıf Bulunamadı!\n Lütfen Geçerli Bir Id Giriniz.");
                return;
            }

            @class.Students = _studentService.GetAll(p => p.ClassId == @class.Id);
            @class.Teacher = _teacherService.Get(p => p.Id == @class.TeacherId);

            WriteLine($"\t{@class}");
            if (@class.Teacher != null)
            {
                WriteLine($"\t Öğretmen:\n\t {@class.Teacher.FullName}");
            }
            if (@class.Students != null || @class.Students.Any())
            {
                WriteLine("\tÖğrenci Listesi:");
                for (int i = 0; i < @class.Students.Count; i++)
                {
                    WriteLine($"\t{i + 1} - Öğrenci Numarası: {@class.Students[i].StudentNumber} Öğrenci Adı: {@class.Students[i].FullName}");
                }
            }
        }
        public void ShowTeacherByClassId()
        {
            int classId;
            WriteLine("Sınıf Id sini Giriniz:");
            while (!int.TryParse(ReadLine(), out classId))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz");

            }
            var @class = _classesService.Get(p => p.Id == classId);
            if (@class is null)
            {
                WriteLine($"{classId} Id li Sınıf Bulunamadı.");
            }

            var teacher = _teacherService.Get(p => p.Id == @class.TeacherId);
            if (teacher is null)
            {
                WriteLine($"{classId} Id li Sınıfa Henüz Bir Öğretmen Atanmamış.");
            }
            else
            {
                WriteLine(teacher);
            }

        }
        public void ShowStudentsByClassId()
        {
            int classId;
            WriteLine("Sınıf Id sini Giriniz:");
            while (!int.TryParse(ReadLine(), out classId))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
            }

            var students = _studentService.GetAll(p => p.ClassId == classId);
            if (!students.Any())
            {
                WriteLine($"{classId} Id li Sınıfa Kayıtlı Öğrenci Bulunamadı.");
            }
            else
            {
                WriteLine("Öğrenci Listesi:");
                //foreach (var student in students.Select((x,i) => new { data= x, index= i}))
                //{
                //    Console.WriteLine($"\t{student.index + 1} - Öğrenci Numarası: {student.data.StudentNumber} Öğrenci Adı: {students[i].FullName}");
                //}
                for (int i = 0; i < students.Count; i++)
                {
                    WriteLine($"\t{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName}");
                }
            }
        }
    }
}
