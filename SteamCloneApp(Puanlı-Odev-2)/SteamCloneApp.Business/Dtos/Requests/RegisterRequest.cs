using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SteamCloneApp.Business.Dtos.Requests
{
    public class RegisterRequest
    {
        [Required(ErrorMessage = "Ad boş geçilemez!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Soyad boş geçilemez!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Email boş geçilemez!")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Kullanıcı adı boş geçilemez!")]
        public string NickName { get; set; }
        [Required(ErrorMessage = "Şifre boş geçilemez!")]
        public string Password { get; set; }
        [Compare(otherProperty: "Password", ErrorMessage = "Şifre ve şifre tekrar aynı olmalı!")]
        [Required(ErrorMessage = "Şifre tekrar boş geçilemez!")]
        public string PasswordConfirm { get; set; }
    }
}
