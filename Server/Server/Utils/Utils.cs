using Server.DAL;
using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Utils
{
    public class Utils
    {
        //internal static Models.contacts GetContactByUserName(string userName)
        //{
        //    //var loginUser = ApplicationContext.Instnace.LoggedUsers.Where(u => u.UserName.ToLower().Equals(userName.ToLower())).FirstOrDefault();
        //    var loginUser = ApplicationContext.Instnace.Counslers.Where(c => c.usernmae.ToLower().Equals(userName.ToLower())).FirstOrDefault();
        //    if (loginUser == null)
        //    {
        //        Logger.WriteToLog(LogLevel.error, "GetContactByUserName failed for:" + userName);
        //        return null;
        //    }
        //    ApplicationContext.Instnace.Counslers.Join
        //}

        internal static Models.contacts GetContactByUserName(string userName)
        {
            var counsler = pickmepleasedbEntities.Instnace.counslers.Where(c => c.usernmae.ToLower().Equals(userName.ToLower())).FirstOrDefault();
            if (string.IsNullOrEmpty(userName) || counsler == null)
            {
                Logger.WriteToLog(LogLevel.warning, "GetContactByUserName IsNullOrEmpty or no counsler exists for user:" +userName);
                return null;
            }
            return pickmepleasedbEntities.Instnace.contacts.Where(contact => contact.id == counsler.counsler_concacts_id).FirstOrDefault();
        }

        internal static contacts GetContactByContactId(int? contactId)
        {
            var temp = pickmepleasedbEntities.Instnace.contacts.Where(c => c.id == contactId).FirstOrDefault();
            if (temp == null)
            {
                Logger.WriteToLog(LogLevel.warning, "GetContactByContactId IsNullOrEmpty or no contact exists for contactId:" + contactId);
            }
            return temp;
        }
    }
}