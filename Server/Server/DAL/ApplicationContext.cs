using Server.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.DAL
{
    public class ApplicationContext
    {
        public static ApplicationContext Instnace
        {
            get
            {
                if (_instnace == null)
                    _instnace = new ApplicationContext();
                return _instnace;
            }
        }

        private static ApplicationContext _instnace;
        public pickmepleasedbEntities contextInstance;
        public ApplicationContext()
        {
            contextInstance = new pickmepleasedbEntities();
        }

    }
}