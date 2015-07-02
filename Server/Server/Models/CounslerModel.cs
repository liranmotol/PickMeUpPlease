using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class CounslerModel
    {
        public string  UserName { get; set; }
        public int CounslerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CheckedIn { get; set; }
        public DateTime CheckedOut { get; set; }
        public List<int> AllowedBranchedIds { get; set; }
        public string  Token { get; set; }
    }
}