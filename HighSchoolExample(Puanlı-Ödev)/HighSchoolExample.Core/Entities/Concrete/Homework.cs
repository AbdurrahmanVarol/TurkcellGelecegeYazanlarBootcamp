using HighSchoolExample.Core.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Core.Entities.Concrete
{
    public class Homework : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public int StudentId { get; set; }
        public Student Student { get; set; }
    }
}
