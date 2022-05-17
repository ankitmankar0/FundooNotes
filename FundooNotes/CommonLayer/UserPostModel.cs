using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CommonLayer
{
    public class UserPostModel
    {
        //User Registration Entity ,,,, to taking input from user


        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{4,}$", ErrorMessage = "name starts with Cap and has minimum 4 characters")]
        public string firstName { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{4,}$", ErrorMessage = "name starts with Cap and has minimum 4 characters")]
        public string lastName { get; set; }

        [Required]
        //[RegularExpression("^[a-z]{3,}[1-9]{1,4}[@][a-z]{4,}[.][a-z]{3,}$", ErrorMessage = "Please Enter Valid Email")]
        public string email { get; set; }
        public DateTime registeredDate { get; set; }

        [Required]
        [RegularExpression("^[A-Z]{1}[a-z]{3,}[@][0-9]{1,}$", ErrorMessage = "Please Enter Valid Password")]
        public string password { get; set; }
        public string address { get; set; }
    }
}
