using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ContactManagement.Models
{
    public class ContactInformation
    {
        public int ContactID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EMail { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }

    }
}