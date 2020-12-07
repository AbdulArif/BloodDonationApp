using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class Donor
    {
        //public ApplicationUser ApplicationUser { get; set; }
        public string DonorId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public object PhoneNumber { get; set; }
        public string Email { get; set; }
        public object BloodGroup { get; set; }
        public object District { get; set; }
        public object City { get; set; }
        public object State { get; set; }
        public object PIN { get; set; }
        public object NearByHospitals { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public object BirthYear { get; set; }
        public object ChronicDisease { get; set; }
        public object Age { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string AddedBy { get; set; }
        public object UpdatedBy { get; set; }
    }
}
