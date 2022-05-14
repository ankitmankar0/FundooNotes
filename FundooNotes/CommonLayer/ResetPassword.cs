using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class ResetPassword
    {
        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{3,}[@][0-9]{1,}$", ErrorMessage = "Please Enter Valid Password")]
        public string NewPassword { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{3,}[@][0-9]{1,}$", ErrorMessage = "Please Enter Valid Password")]
        public string ConfirmPassword { get; set; }
    }
}
