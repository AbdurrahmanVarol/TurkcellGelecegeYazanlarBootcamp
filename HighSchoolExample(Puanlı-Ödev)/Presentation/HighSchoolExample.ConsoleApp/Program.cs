using HighSchoolExample.ConsoleApp.Controllers;
using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Services.Concrete;
using HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework;
using HighSchoolExample.Infrastructure.Services.Concrete.InMemory;
using static System.Console;

namespace HighSchoolExample.ConsoleApp
{
    internal class Program
    {
        private static InMemoryContext _context = new InMemoryContext();
        private static ITeacherService _teacherService = new TeacherService();
        private static IClassService _classesService = new EfClassService(_context, _teacherService);
        private static IStudentService _studentService = new StudentService(_classesService);
        private static IHomeworkService _homeworkService = new HomeworkService(_studentService);

        private static ClassController _classController = new ClassController(_teacherService, _classesService, _studentService);
        private static StudentController _studentController = new StudentController(_classesService, _studentService, _homeworkService);
        private static TeacherController _teacherController = new TeacherController(_classesService, _homeworkService, _teacherService);

        // command pattern?
        static string[] menu =
        {
            "İşleminizi Seçiniz: ",
            "\t(-1) Çıkış",
            "Sınıf İşlemleri: ",
            "\t(1) Sınıf Ekle",
            "\t(2) Sınıfları Listele",
            "\t(3) Sınıf Detaylarını Göster",
            "\t(4) Sınıftaki Öğrencileri Listele",
            "\t(5) Sınıftaki Öğretmeni Göster",
            "Öğrenci İşlemleri: ",
            "\t(6)  Öğrenci Ekle",
            "\t(7)  Öğrencileri Listele",
            "\t(8)  Öğrenci Numarasına Göre Öğrenciyi Göster",
            "\t(9)  Öğrenci Adına Göre Ara",
            "\t(10) Öğrenci Soyadına Göre Ara",
            "\t(11) Ödevi Gönder",
            "Öğretmen İşlemleri: ",
            "\t(12) Öğretmen Ekle",
            "\t(13) Öğretmenleri Listele",
            "\t(14) Ödevleri Göster",
        };
        static void Main(string[] args)
        {
            while (true)
            {
                ShowMenu();

                int choice;

                if (!int.TryParse(ReadLine(), out choice))
                {
                    WriteLine("Lütfen geçerli bir sayı giriniz");
                    continue;
                }

                switch (choice)
                {
                    case -1:
                        break;
                    case 1:
                        _classController.AddClass();
                        break;
                    case 2:
                        _classController.ShowAllClassess();
                        break;
                    case 3:
                        _classController.ShowClassDetails();
                        break;
                    case 4:
                        _classController.ShowStudentsByClassId();
                        break;
                    case 5:
                        _classController.ShowTeacherByClassId();
                        break;
                    case 6:
                        _studentController.AddStudent();
                        break;
                    case 7:
                        _studentController.ShowAllStudent();
                        break;
                    case 8:
                        _studentController.ShowStudentByNumber();
                        break;
                    case 9:
                        _studentController.ShowStudentByName();
                        break;
                    case 10:
                        _studentController.ShowStudentByLastName();
                        break;
                    case 11:
                        _studentController.SendHomework();
                        break;
                    case 12:
                        _teacherController.AddTeacher();
                        break;
                    case 13:
                        _teacherController.ShowAllTeacher();
                        break;
                    case 14:
                        _teacherController.ShowAllHomeworks();
                        break;
                    default:
                        WriteLine("Lütfen Geçerli Bir İşlem Seçiniz");
                        break;
                }
                WriteLine("\n-----------------------------------------------------------\n");
            }
        }

        private static void ShowMenu()
        {
            foreach (var item in menu)
            {
                WriteLine(item);
            }
        }
    }
}