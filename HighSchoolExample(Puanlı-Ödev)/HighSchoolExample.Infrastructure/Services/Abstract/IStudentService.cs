using HighSchoolExample.Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Services.Abstract
{
    public interface IStudentService : IServiceRepository<Student>
    {
    }
}
