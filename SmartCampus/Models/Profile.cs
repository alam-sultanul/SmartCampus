using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartCampus.Models
{
    public class Profile
    {
        public int ProfileId { get; set; }
        public string ProfileName { get; set; }
        public string OriginType { get; set; }
        public string EmailAddress { get; set; }
        public double ContactNumber { get; set; }
        public string Nationality { get; set; }
        public string LeadScoring { get; set; }
        public bool LeadStatus { get; set; }
        public string ProfileType { get; set; }
        public DateTime RegistrationDate { get; set; }

    }
}