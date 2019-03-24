using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AuthService.Models.Requests
{
    public class ChangePasswordRequest
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "Password reqired")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "New password reqired")]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }

        [Required(ErrorMessage = "Confirm new password reqired")]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string ConfirmNewPassword { get; set; }
    }
}
