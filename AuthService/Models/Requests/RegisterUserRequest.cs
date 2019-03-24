using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models.Requests
{
    public class RegisterUserRequest
    {
        [Required(ErrorMessage = "Login reqired")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password reqired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm password reqired")]
        [DataType(DataType.Password)]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
