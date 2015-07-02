using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Server.Models
{
    [Serializable]
    public class BranchModel
    {
        public int BranchId { get; set; }
        public string BranchName{ get; set; }
        public List<StudentModel> StudentsList { get; set; }

        internal  List<StudentModel> GetUpdateStundetsInfo(DateTime LastSyncTime)
        {
            List<StudentModel> temp=StudentsList.Where(s => s.LastUpdateTime>LastSyncTime).ToList();
            return temp;
        }
    }
}