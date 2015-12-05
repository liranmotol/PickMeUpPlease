using MobileApplication.Hndlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MobileApplication.Models
{
    public class ClassPickUpModel
    {
        //public static Dictionary<string, string> PickUpDic;

        //private static ClassPickUpModel _instance = null;
        //internal static ClassPickUpModel GetInstance()
        //{
        //    if (_instance == null)
        //        _instance = new ClassPickUpModel();
        //    return _instance;
        //}

        //public ClassPickUpModel()
        //{
        //    PickUpDic = new Dictionary<string, string>();
        //    //PickUpDic .Add("Class", "Where" );
        //}

        public string EngName { get; set; }
        public string HebName { get; set; }
        public string Where { get; set; }
        public int GroupId { get; set; }
        public int Id { get; set; }


        public static Dictionary<int, CounslerModel> ClassPickUpDic;

        public ClassPickUpModel()
        {
            if (ClassPickUpDic == null)
            {
                ClassPickUpDic = new Dictionary<int, CounslerModel>();

                //esti
                ClassPickUpDic.Add(1, InMemoryHandler.GetCounslerById(11));
                //nicki
                ClassPickUpDic.Add(2, InMemoryHandler.GetCounslerById(12));
                //jacklyn
                ClassPickUpDic.Add(3, InMemoryHandler.GetCounslerById(13));
            }
        }

        public static void UpdateCounslerGroup(int groupId, CounslerModel counsler)
        {
            CounslerModel t = null;
            if (counsler != null &&
               ClassPickUpDic.TryGetValue(groupId, out t))
            {
                ClassPickUpDic[groupId] = counsler;
            }
        }
        public string GetGroupsCounslerDetails()
        {
            CounslerModel counsler = null;
            ClassPickUpDic.TryGetValue(GroupId, out counsler);
            if (counsler !=null)
                return counsler.FirstName+ " " +counsler.LastName +":"+counsler.PhoneNumber;
            return "";
        }
        public int GetGroupsCounslerId()
        {
            CounslerModel counsler = null;
            ClassPickUpDic.TryGetValue(GroupId, out counsler);
            if (counsler != null)
                return counsler.ID;
            return 0;
        }

        internal void UpdateInDB()
        {
            DAL.DataAccess.UpdateWhereFord(this.Id, this.Where);
        }
    }
}