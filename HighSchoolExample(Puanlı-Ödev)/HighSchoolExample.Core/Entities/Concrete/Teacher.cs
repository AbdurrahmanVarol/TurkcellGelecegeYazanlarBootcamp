using HighSchoolExample.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Core.Entities.Concrete
{
    public class Teacher :PersonBase, IEntity
    {     
        public Class Class { get; set; }

        public override string ToString()
        {
            return $"Id: {Id} Ad: {FirstName} Soyad: {LastName}";
        }
    }
}
