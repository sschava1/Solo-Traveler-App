using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SoloTravelerApp.Entity
{
    public class StaffMember
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Id { get; set; }
        public string Pwd { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Role { get; set; }
    }
}