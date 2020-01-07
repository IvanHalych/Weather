using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Web.Script.Serialization;

namespace Weather
{
    class Call
    { 
        public static JObject Calling(string city)
        {
            string APIKey = "91c2e61f65a88db06111bbda7a389807";
            WebClient client = new WebClient();
            string path= "https://api.openweathermap.org/data/2.5/weather?" + city + "&appid=" + APIKey;
            string result=client.DownloadString(path);
            JObject weather=JObject.Parse(result);
            return weather;
        }
    }
}
