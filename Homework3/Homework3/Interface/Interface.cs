using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework3.Interface
{
    public class Interface
    {
    }

    public interface IWorkable
    {
        void Work();
    }
    public interface IEatable
    {
        void Eat();
    }

    public class Employee
    {

    }

    public class Worker : Employee, IWorkable, IEatable
    {
        public void Eat()
        {
            throw new NotImplementedException();
        }

        public void Work()
        {
            throw new NotImplementedException();
        }
    }
    public class Robot : Employee, IWorkable
    {
        public void Work()
        {
            throw new NotImplementedException();
        }
    }
}
