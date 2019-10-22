using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyReceiptWebApp.ViewModels
{
    public class LoginViewModel
    {
        public LoginViewModel()
        {
            IsInvalid = false;
        }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public bool IsInvalid { get; set; }

        public string RegisterUrl { get; set; }
    }
}
