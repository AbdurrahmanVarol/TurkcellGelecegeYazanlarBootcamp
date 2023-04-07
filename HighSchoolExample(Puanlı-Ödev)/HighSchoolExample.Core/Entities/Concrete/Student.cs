using HighSchoolExample.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Core.Entities.Concrete
{
    public class Student : PersonBase, IEntity
    {
      
        public int StudentNumber { get; set; }

        public int ClassId { get; set; }
        public Class Class { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Ad: {FirstName} Soyad: {LastName} Öğrenci Numarası: {StudentNumber} ";
        }
    }
}
