using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    public class ClassPickUpModel
    {
        public static Dictionary<string, string> PickUpDic;

        private static ClassPickUpModel _instance = null;
        internal static ClassPickUpModel GetInstance()
        {
            if (_instance == null)
                _instance = new ClassPickUpModel();
            return _instance;
        }

        public ClassPickUpModel()
        {
            PickUpDic = new Dictionary<string, string>();
            //PickUpDic .Add("Class", "Where" );
        }
    }
}