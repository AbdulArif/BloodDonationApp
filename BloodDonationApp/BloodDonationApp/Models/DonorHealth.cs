using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class DonorHealth
    {
        public string DonorHealthId { get; set; }
        public string DonorId { get; set; }
        public string Disease { get; set; }
        public string AddedBy { get; set; }
        public DateTime AddedDate { get; set; }
        public object UpdatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
