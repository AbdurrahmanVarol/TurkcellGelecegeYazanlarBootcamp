using HighSchoolExample.Core.Entities.Concrete;
using HighSchoolExample.Infrastructure;
using HighSchoolExample.Infrastructure.Services.Abstract;
using HighSchoolExample.Infrastructure.Services.Concrete;
using HighSchoolExample.Infrastructure.Services.Concrete.EntityFramework.InMemory;
using HighSchoolExample.Infrastructure.Services.Concrete.InMemory;

namespace HighSchoolExample.ConsoleApp
{
    internal class Program
    {
        static InMemoryContext _context = new InMemoryContext();
        static ITeacherService _teacherService = new TeacherService();
        static IClassService _classesService = new EfClassService(_context,_teacherService);
        static IStudentService _studentService = new StudentService(_classesService);
        static IHomeworkService _homeworkService = new HomeworkService(_studentService);

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
            "\t(6) Öğrenci Ekle",
            "\t(7) Öğrencileri Listele",
            "\t(8) Öğrenci Numarasına Göre Öğrenciyi Göster",
            "\t(9) Öğrenci Adına Göre Ara",
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

                if (!int.TryParse(Console.ReadLine(), out choice))
                {
                    Console.WriteLine("Lütfen geçerli bir sayı giriniz");
                    continue;
                }

                switch (choice)
                {
                    case -1:
                        break;
                    case 1:
                        AddClass();
                        break;
                    case 2:
                        ShowAllClassess();
                        break;
                    case 3:
                        ShowClassDetails();
                        break;
                    case 4:
                        ShowStudentsByClassId();
                        break;
                    case 5:
                        ShowTeacherByClassId();
                        break;
                    case 6:
                        AddStudent();
                        break;
                    case 7:
                        ShowAllStudent();
                        break;
                    case 8:
                        ShowStudentByNumber();
                        break;
                    case 9:
                        ShowStudentByName();
                        break;
                    case 10:
                        ShowStudentByLastName();
                        break;
                    case 11:
                        SendHomework();
                        break;
                    case 12:
                        AddTeacher();
                        break;
                    case 13:
                        ShowAllTeacher();
                        break;
                    case 14:
                        ShowAllHomeworks();
                        break;
                    default:
                        Console.WriteLine("Lütfen Geçerli Bir İşlem Seçiniz");
                        break;
                }
                Console.WriteLine("\n-----------------------------------------------------------\n");
            }
        }

        private static void ShowMenu()
        {
            foreach (var item in menu)
            {
                Console.WriteLine(item);
            }
        }

        //------------ Class Methods ---------
        private static void AddClass()
        {
            var teachers = _teacherService.GetAll();

            if (teachers is null || !teachers.Any())
            {
                Console.WriteLine("Şu Anda Kayıtlı Hiç Bir Öğretmen Bulunamadı. Lütfen Bir Öğretmen Ekledikten Sonra Tekrar Deneyiniz.");
                return;
            }

            Console.WriteLine("Lütfen Eklemek İstediğiniz Sınıfın İsmini Giriniz:");
            var className = Console.ReadLine();

            int teacherId;

            Console.WriteLine("Öğretmen Id sini Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out teacherId))
            {
                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
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
                Console.WriteLine("Sınıf Eklendi.");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ShowAllClassess()
        {
            var classes = _classesService.GetAll();
            if (!classes.Any())
            {
                Console.WriteLine("Şu Anda Hiç Kayıtlı Sınıf Olmadığı İçin Listeleme İşlemi Yapılamıyor. Lütfen Sınıf Ekledikten Sonra Tekrar Deneyiniz.");
                return;
            }
            Console.WriteLine("Sınıf Listesi: ");
            for (int i = 0; i < classes.Count; i++)
            {
                Console.WriteLine($"\t{i + 1} - Id: {classes[i].Id} SInıf İsmi: {classes[i].ClassName}");
            }
        }
        private static void ShowClassDetails()
        {
            int classId;
            Console.WriteLine("Sınıf Id sini Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out classId))
            {
                Console.WriteLine("Lütfen geçerli bir sayı giriniz");
            }
            var @class = _classesService.Get(p => p.Id == classId);
            if (@class is null)
            {
                Console.WriteLine($"{classId} Id li Sınıf Bulunamadı!\n Lütfen Geçerli Bir Id Giriniz.");
                return;
            }
            @class.Students = _studentService.GetAll(p => p.ClassId == @class.Id);
            @class.Teacher = _teacherService.Get(p => p.Id == @class.TeacherId);

            Console.WriteLine($"\t{@class}");
            if (@class.Teacher != null)
            {
                Console.WriteLine($"\t Öğretmen:\n\t {@class.Teacher.FullName}");
            }
            if (@class.Students != null || @class.Students.Any())
            {
                Console.WriteLine("Öğrenci Listesi:");
                for (int i = 0; i < @class.Students.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - Öğrenci Numarası: {@class.Students[i].StudentNumber} Öğrenci Adı: {@class.Students[i].FullName}");
                }
            }
        }
        private static void ShowTeacherByClassId()
        {
            int classId;
            Console.WriteLine("Sınıf Id sini Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out classId))
            {
                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz");

            }
            var @class = _classesService.Get(p => p.Id == classId);
            if (@class is null)
            {
                Console.WriteLine($"{classId} Id li Sınıf Bulunamadı.");
            }

            var teacher = _teacherService.Get(p => p.Id == @class.TeacherId);
            if (teacher is null)
            {
                Console.WriteLine($"{classId} Id li Sınıfa Henüz Bir Öğretmen Atanmamış.");
            }
            else
            {
                Console.WriteLine(teacher);
            }

        }
        private static void ShowStudentsByClassId()
        {
            int classId;
            Console.WriteLine("Sınıf Id sini Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out classId))
            {
                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
            }

            var students = _studentService.GetAll(p => p.ClassId == classId);
            if (students is null || !students.Any())
            {
                Console.WriteLine($"{classId} Id li Sınıfa Kayıtlı Öğrenci Bulunamadı.");
            }
            else
            {
                Console.WriteLine("Öğrenci Listesi:");
                for (int i = 0; i < students.Count; i++)
                {
                    Console.WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName}");
                }
            }
        }

        //------------ Student Methods ---------

        private static void AddStudent()
        {
            Console.WriteLine("Öğrenci Adını Giriniz: ");
            var firstName = Console.ReadLine();

            Console.WriteLine("Öğrenci Soyadını Giriniz: ");
            var lastName = Console.ReadLine();

            Console.WriteLine("Öğrenci Numarasını Giriniz:");
            int studentNumber;
            Console.WriteLine("Öğrenci Numarasını Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out studentNumber))
            {
                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
            }

            int classId;
            Console.WriteLine("Sınıf Id sini Giriniz: ");
            while (!int.TryParse(Console.ReadLine(), out classId))
            {
                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz");
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

            var result = ExceptionHandler.Handle(() => { _studentService.Add(student); });
            if (result.IsSuccess)
            {
                Console.WriteLine("Öğrenci Eklendi.");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }
        private static void ShowAllStudent()
        {
            var students = _studentService.GetAll();
            if (students is null || !students.Any())
            {
                Console.WriteLine("Şu Anda Hiç Kayıtlı Öğrenci Olmadığı İçin Listeleme İşlemi Yapılamıyor. Lütfen Sınıf Ekledikten Sonra Tekrar Deneyiniz.");
                return;
            }
            Console.WriteLine("Öğrenci Listesi:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName} Sınıfı: {students[i].Class.ClassName}");
            }
        }
        private static void ShowStudentByNumber()
        {
            int studentNumber;
            Console.WriteLine("Öğrenci Numarasını Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out studentNumber))
            {
                Console.WriteLine("Lütfen Geçerli Bir Öğrenci Numarası Giriniz:");
            }

            var student = _studentService.Get(p => p.StudentNumber == studentNumber);

            if (student is null)
            {
                Console.WriteLine($"{studentNumber} Numaralı Öğrenci Bulunamadı.");
            }
            else
            {
                Console.WriteLine(student);
            }
        }
        private static void ShowStudentByName()
        {
            var firstName = string.Empty;
            while (string.IsNullOrEmpty(firstName))
            {
                Console.WriteLine("Aramak İstediğiniz Öğrencinin Adını Giriniz:");
                firstName = Console.ReadLine();
            }
            var students = _studentService.GetAll(p => p.FirstName.Equals(firstName));

            if (!students.Any())
            {
                Console.WriteLine($"{firstName} Adında Öğrenci Bulunamadı.");
            }
            Console.WriteLine($"{firstName} İsimli Öğrenci Listesi:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName} Sınıfı: {students[i].Class.ClassName}");
            }
        }
        private static void ShowStudentByLastName()
        {
            var lastName = string.Empty;
            while (string.IsNullOrEmpty(lastName))
            {
                Console.WriteLine("Aramak İstediğiniz Öğrencinin Adını Giriniz:");
                lastName = Console.ReadLine();
            }

            var students = _studentService.GetAll(p => p.LastName.Equals(lastName));

            Console.WriteLine($"{lastName} Soyadlı Öğrenci Listesi:");
            for (int i = 0; i < students.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Öğrenci Numarası: {students[i].StudentNumber} Öğrenci Adı: {students[i].FullName} Sınıfı: {students[i].Class.ClassName}");
            }
        }
        private static void SendHomework()
        {
            int studentNumber;
            Console.WriteLine("Öğrenci Numarasını Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out studentNumber))
            {

                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz.");

            }

            var student = _studentService.Get(p => p.StudentNumber == studentNumber);

            Console.WriteLine("Ödevin Başlığını Giriniz:");
            var title = Console.ReadLine();
            Console.WriteLine("Ödevin İçeriğini Giriniz:");
            var text = Console.ReadLine();
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
                Console.WriteLine("Öden Gönderildi.");
            }
            else
            {
                Console.WriteLine(result.Message);
            }

        }

        //------------ Teacher Methods ---------

        private static void AddTeacher()
        {
            Console.WriteLine("Lütfen Eklemek İstediğiniz Öğretmeini Bilgilerini Giriniz Giriniz:");
            Console.WriteLine("Öğretmen Adı:");
            var firstName = Console.ReadLine();

            Console.WriteLine("Öğretmen Soyadı:");
            var lastName = Console.ReadLine();

            var teacher = new Teacher
            {
                FirstName = firstName,
                LastName = lastName
            };
            var result = ExceptionHandler.Handle(() => { _teacherService.Add(teacher); });
            if (result.IsSuccess)
            {
                Console.WriteLine("Öğretmen Eklendi.");
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        private static void ShowAllTeacher()
        {
            var teachers = _teacherService.GetAll();
            if (teachers is null || !teachers.Any())
            {
                Console.WriteLine("Listelenecek Öğretmen Bulunamadı.");
                return;
            }
            for (int i = 0; i < teachers.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Öğretmen Adı: {teachers[i].FullName}");
            }
        }
        private static void ShowAllHomeworks()
        {
            int teacherId;
            Console.WriteLine("Öğretmen Id sini Giriniz:");
            while (!int.TryParse(Console.ReadLine(), out teacherId))
            {
                Console.WriteLine("Lütfen Geçerli Bir Sayı Giriniz.");
            }
            var @class = _classesService.Get(p => p.TeacherId == teacherId);
            if (@class is null)
            {
                Console.WriteLine($"{teacherId} Id li Öğretmen Bulunamadı!");
                return;
            }

            var homeworks = _homeworkService.GetAll(p => p.Student.ClassId == @class.Id);
            if (homeworks is null || !homeworks.Any())
            {
                Console.WriteLine("Kayıtlı Bir Ödev Bulunamadı.");
                return;
            }
            Console.WriteLine("Ödev Listesi: ");

            for (int i = 0; i < homeworks.Count; i++)
            {
                Console.WriteLine($"{i + 1} - Öğrenci Numarası: {homeworks[i].Student.StudentNumber} Öğrenci Adı: {homeworks[i].Student.FullName} Ödev Başlığı: {homeworks[i].Title}");
            }
        }
    }
}