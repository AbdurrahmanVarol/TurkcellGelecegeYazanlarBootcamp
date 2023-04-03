using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure.Validation.FluentValidation
{
    public class ValidationTool
    {
        public static void FluentValidate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);
            if (result.Errors.Any())
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
