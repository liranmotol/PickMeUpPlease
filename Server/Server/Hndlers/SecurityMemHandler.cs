using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Hndlers
{
    public class SecurityMemHandler
    {
        private static object lockerCounslersToken = new object();
        private static Dictionary<string, int> CounslersToken;
        static SecurityMemHandler()
        { 
         if (CounslersToken==null)   
             CounslersToken=new Dictionary<string,int>();
        }
        internal static void UpdateCounslerToken(string token, Models.CounslerModel counsler)
        {
            int temp;
            lock (lockerCounslersToken)
            {
                if (CounslersToken.TryGetValue(token, out temp))
                    CounslersToken[token] = counsler.CounslerID;
                else
                    CounslersToken.Add(token, counsler.CounslerID);
            }
        }

        internal static int IsTokenValid(string token)
        {
            int counslerId=0;
            lock (lockerCounslersToken)
            {
                int tempCounslerId = 0;
                if (CounslersToken.TryGetValue(token, out tempCounslerId))
                    counslerId = tempCounslerId;
            }
            return counslerId;
        }

        public static bool IsUserAuthenticated(RequestLoginModel requestLogin)
        {

            return
                (requestLogin.Password == "liran" && requestLogin.UserName == "liran")
                ||(requestLogin.Password == "lily" && requestLogin.UserName == "lily")
                || (requestLogin.Password == "1" && requestLogin.UserName == "1");
        }
    }
}