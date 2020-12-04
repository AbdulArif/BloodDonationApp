using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class Login
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string grant_type { get; set; }
    }
}
