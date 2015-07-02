using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public class RequestLoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}