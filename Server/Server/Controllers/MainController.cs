using Server.DAL;
using Server.Hndlers;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Server.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MainController : ApiController
    {

        [HttpGet, HttpPost]
        [Route("Main/testMethod")]
        public List<string> testMethod()
        {
            var s = InMemoryHandler.Students.First();
            return s.HealthIssues;
        }

        [HttpGet, HttpPost]
        [Route("Main/testMethod2")]
        public string testMethod2()
        {
            //var s = ApplicationContext.Instnace.Students.First();
            //var m = ApplicationContext.Instnace.Branches.First();

            var s1 = ApplicationContext.Instnace.contextInstance.students.First();
            var m2 = ApplicationContext.Instnace.contextInstance.branches.First();
            InMemoryHandler.GetAllCounslers();
            return null;
        }



    }


}
