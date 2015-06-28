using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace Utils
{
    public class JsonUtils
    {
        public static string ConvertObjectToJson<T>(T obj)
        {
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                string jsonString = javaScriptSerializer.Serialize(obj);
                return jsonString;
            }
            catch (Exception e)
            {
                
            }
            return null;
        }
    }
}
