using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    public abstract class BaseResponse
    {
        public  string ErrorMsg;
        public  int Status;

    }
}