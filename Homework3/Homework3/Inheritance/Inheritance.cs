using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Inheritance
{
    public class Inheritance
    {
        //inheritance bir class ın üst bir class ın özelliklerini ya da metotlarını miras almasıdır
        public Inheritance()
        {
            var worker = new Worker();
            worker.Work();
            var manager = new Manager();
            manager.Work();
            manager.RiseSalary();
        }

    }
    public class Employee
    {
        public void Work()
        {

        }
    }
    public class Manager : Employee
    {
        public void RiseSalary()
        {

        }
    }
    public class Worker : Employee
    {
    }
}
