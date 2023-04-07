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
    public class TeacherController : IController
    {
        private readonly IClassService _classesService;
        private readonly IHomeworkService _homeworkService;
        private readonly ITeacherService _teacherService;

        public TeacherController(IClassService classesService, IHomeworkService homeworkService, ITeacherService teacherService)
        {
            _classesService = classesService;
            _homeworkService = homeworkService;
            _teacherService = teacherService;
        }

        public void AddTeacher()
        {
            WriteLine("Lütfen Eklemek İstediğiniz Öğretmeini Bilgilerini Giriniz Giriniz:");
            WriteLine("Öğretmen Adı:");
            var firstName = ReadLine();

            WriteLine("Öğretmen Soyadı:");
            var lastName = ReadLine();

            var teacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName
            };
            var result = ExceptionHandler.Handle(() => { _teacherService.Add(teacher); });
            if (result.IsSuccess)
            {
                WriteLine("Öğretmen Eklendi.");
            }
            else
            {
                WriteLine(result.Message);
            }
        }
        public void ShowAllTeacher()
        {
            var teachers = _teacherService.GetAll();
            if (!teachers.Any())
            {
                WriteLine("Listelenecek Öğretmen Bulunamadı.");
                return;
            }
            for (int i = 0; i < teachers.Count; i++)
            {
                WriteLine($"{i + 1} - Öğretmen Adı: {teachers[i].FullName}");
            }
        }
        public void ShowAllHomeworks()
        {
            int teacherId;
            WriteLine("Öğretmen Id sini Giriniz:");
            while (!int.TryParse(ReadLine(), out teacherId))
            {
                WriteLine("Lütfen Geçerli Bir Sayı Giriniz.");
            }
            var @class = _classesService.Get(p => p.TeacherId == teacherId);
            if (@class is null)
            {
                WriteLine($"{teacherId} Id li Öğretmen Bulunamadı!");
                return;
            }

            var homeworks = _homeworkService.GetAll(p => p.Student.ClassId == @class.Id);
            if (!homeworks.Any())
            {
                WriteLine("Kayıtlı Bir Ödev Bulunamadı.");
                return;
            }
            WriteLine("Ödev Listesi: ");

            for (int i = 0; i < homeworks.Count; i++)
            {
                WriteLine($"{i + 1} - Öğrenci Numarası: {homeworks[i].Student.StudentNumber} Öğrenci Adı: {homeworks[i].Student.FullName} Ödev Başlığı: {homeworks[i].Title}");
            }
        }
    }
}
