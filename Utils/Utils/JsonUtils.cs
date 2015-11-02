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

        public static T ConvertJsonToObject<T>(string json)
        {
            try
            {
                JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
                T obj= javaScriptSerializer.Deserialize<T>(json);
                return obj;
            }
            catch (Exception e)
            {

            }
            return default(T);
        }
    }
}
