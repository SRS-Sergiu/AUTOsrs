using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AUTOsrs.Models
{
    public class UserModel
    {
        public int ID_User { get; set; }
        public string Email { get; set; }
        public int Password { get; set; }
        public int Fname { get; set; }
        public int Lname { get; set; }
    }
}