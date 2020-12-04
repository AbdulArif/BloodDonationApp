using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class Register
    {
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Role { get; set; }
        public string DateOfRegistration { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
