using FluentValidation;
using HighSchoolExample.Infrastructure.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HighSchoolExample.Infrastructure
{
    public static class ExceptionHandler
    {
        public static ExceptionDto Handle(Action action)
        {
            try
            {
                action.Invoke();
                return new ExceptionDto
                {
                    IsSuccess = true
                };
            }
            catch (ValidationException validationException)
            {
                Console.WriteLine(validationException.Message);
                return new ExceptionDto
                {
                    IsSuccess = true,
                    Message = validationException.Message
                };
            }
            catch (Exception)
            {
                return new ExceptionDto
                {
                    IsSuccess = true,
                    Message = "Beklenmeyen Bir Hata Oluştu!"
                };
            }
        }
    }
}
