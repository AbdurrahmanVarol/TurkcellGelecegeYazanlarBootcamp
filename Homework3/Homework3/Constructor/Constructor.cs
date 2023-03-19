using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Constructor
{
    public class Constructor
    {
        //constructor bir class new leneceği zaman çalışan, geriye bir değer döndürmeyen fonksiyondur
        // bir class a cunstructor yazılmasa bile gizli bir parametresiz custructor u vardır
        public Constructor()
        {
            var car1 = new Car();
            var car2 = new Car("BMW");
            var car3 = new Car("BMW","Siyah");
        }
    }

    public class Car
    {
        public string Name { get; set; }
        public string Color{ get; set; }

        public Car()
        {
            Name = string.Empty;
            Color = string.Empty;
        }
        public Car(string name)
        {
            Name=name;
        }
        public Car(string name, string color)
        {
            Name=name;
            Color = color;
        }

    }
}
