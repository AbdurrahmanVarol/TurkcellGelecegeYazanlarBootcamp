using HighSchoolExample.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Core.Entities.Concrete
{
    public class Class : IEntity
    {
        public int Id { get; set; }
        public string ClassName { get; set; }

        public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();

        public override string ToString()
        {
            return $"Id: {Id} Sınıf İsmi: {ClassName}";
        }
    }
}
