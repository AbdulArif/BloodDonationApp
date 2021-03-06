﻿using System;
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
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string BloodGroup { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PIN { get; set; }
        public string NearByHospitals { get; set; }
        public DateTime DateOfRegistration { get; set; }
        public string BirthYear { get; set; }
        public string ChronicDisease { get; set; }
        public string Age { get; set; }
        public DateTime AddedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string AddedBy { get; set; }
        public string UpdatedBy { get; set; }

        public string FullName => FirstName + " " + LastName;
    }
}
