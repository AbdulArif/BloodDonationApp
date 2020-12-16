using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace BloodDonationApp.Models
{
    public class Token
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public string Id { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        [JsonProperty(".issued")]
        public string Issued { get; set; }
        [JsonProperty(".expires")]
        public string Expires { get; set; }
    }
}
