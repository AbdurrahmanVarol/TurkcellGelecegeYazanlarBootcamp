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
    public class StudentController : IController
    {
        private readonly IClassService _classesService;
        private readonly IStudentService _studentService;
        private readonly IHomeworkService _homeworkService;

        public StudentController(IClassService classesService, IStudentService studentService, IHomeworkService homeworkService)
        {
            _classesService = classesService;
            _studentService = studentService;
            _homeworkService = homeworkService;
        }


        public void AddStudent()
        {
            WriteLine("Öğrenci Adını Giriniz: ");
            var firstName = ReadLine();

            WriteLine("Öğrenci Soyadını Giriniz: ");
            var lastName = ReadLine();

            WriteLine("Öğrenci Numarasını Giriniz:");
            int studentNumber;
            WriteLine("Öğrenci Numarasını Giriniz:");
            while (!int.TryParse(ReadLine(), out studentNumber))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
            }

            int classId;
            WriteLine("Sınıf Id sini Giriniz: ");
            while (!int.TryParse(ReadLine(), out classId))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
            }

            var @class = _classesService.Get(p => p.Id == classId);

            var student = new Student
            {
                FirstName = firstName,
                LastName = lastName,
                StudentNumber = studentNumber,
                ClassId = classId,
                Class = @class
            };

            var result = ExceptionHandler.Handle(() => _studentService.Add(student));
            if (result.IsSuccess)
            {
                WriteLine("Öğrenci Eklendi.");
            }
            else
            {
                WriteLine(result.Message);
            }

        }
        public void ShowAllStudent()
        {
            var students = _studentService.GetAll();
            if (!students.Any())
            {
                WriteLine("Şu Anda Hiç Kayıtlı Öğrenci Olmadığı İçin Listeleme İşlemi Yapılamıyor. Lütfen Sınıf Ekledikten Sonra Tekrar Deneyiniz.");
                return;
            }
            WriteLine("Öğrenci Listesi:");
            for (int i = 0; i < students.Count; i++)
            {
                WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName} Sınıfı: {students[i].Class.ClassName}");
            }
        }
        public void ShowStudentByNumber()
        {
            int studentNumber;
            WriteLine("Öğrenci Numarasını Giriniz:");
            while (!int.TryParse(ReadLine(), out studentNumber))
            {
                WriteLine("Lütfen Geçerli Bir Öğrenci Numarası Giriniz:");
            }

            var student = _studentService.Get(p => p.StudentNumber == studentNumber);

            if (student is null)
            {
                WriteLine($"{studentNumber} Numaralı Öğrenci Bulunamadı.");
            }
            else
            {
                WriteLine(student);
            }
        }
        public void ShowStudentByName()
        {
            var firstName = string.Empty;
            while (string.IsNullOrEmpty(firstName))
            {
                WriteLine("Aramak İstediğiniz Öğrencinin Adını Giriniz:");
                firstName = ReadLine();
            }
            var students = _studentService.GetAll(p => p.FirstName.Equals(firstName));

            if (!students.Any())
            {
                WriteLine($"{firstName} Adında Öğrenci Bulunamadı.");
                return;
            }
            WriteLine($"{firstName} İsimli Öğrenci Listesi:");
            for (int i = 0; i < students.Count; i++)
            {
                WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName} Sınıfı: {students[i].Class.ClassName}");
            }
        }
        public void ShowStudentByLastName()
        {
            var lastName = string.Empty;
            while (string.IsNullOrEmpty(lastName))
            {
                WriteLine("Aramak İstediğiniz Öğrencinin Adını Giriniz:");
                lastName = ReadLine();
            }

            var students = _studentService.GetAll(p => p.LastName.Equals(lastName));
            if (!students.Any())
            {
                WriteLine($"{lastName} Soyadında Öğrenci Bulunamadı.");
                return;
            }

            WriteLine($"{lastName} Soyadlı Öğrenci Listesi:");
            for (int i = 0; i < students.Count; i++)
            {
                WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName} Sınıfı: {students[i].Class.ClassName}");
            }
        }
        public void SendHomework()
        {
            int studentNumber;
            WriteLine("Öğrenci Numarasını Giriniz:");
            while (!int.TryParse(ReadLine(), out studentNumber))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz.");
            }

            var student = _studentService.Get(p => p.StudentNumber == studentNumber);

            WriteLine("Ödevin Başlığını Giriniz:");
            var title = ReadLine();

            WriteLine("Ödevin İçeriğini Giriniz:");
            var text = ReadLine();

            var homework = new Homework
            {
                Text = text,
                Title = title,
                StudentId = (int)(student?.Id),
                Student = student
            };
            var result = ExceptionHandler.Handle(() => { _homeworkService.Add(homework); });
            if (result.IsSuccess)
            {
                WriteLine("Öden Gönderildi.");
            }
            else
            {
                WriteLine(result.Message);
            }

        }
    }
}
