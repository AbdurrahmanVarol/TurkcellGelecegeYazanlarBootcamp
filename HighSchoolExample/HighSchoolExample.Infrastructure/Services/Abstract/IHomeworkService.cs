using HighSchoolExample.Core.Entities.Abstract;
using HighSchoolExample.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Abstract
{
    public interface IHomeworkService
    {
        void Add(Homework homework);
        Homework Get(Func<Homework, bool> filter);
        List<Homework> GetAll(Func<Homework, bool> filter = null);
    }
}
