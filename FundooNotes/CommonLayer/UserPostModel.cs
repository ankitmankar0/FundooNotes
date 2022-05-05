using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLayer
{
    public class UserPostModel
    {
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string email { get; set; }
        public DateTime registeredDate { get; set; }
        public string password { get; set; }
        public string address { get; set; }
    }
}
