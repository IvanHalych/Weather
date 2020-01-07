using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather
{
    [Serializable]
    class ListCitys
    { 
        List<string> citys = new List<string>();
        public DateTime Time { private set; get; }
        public ListCitys(DateTime time)
        {
           Time = time;
        }
        public bool Add(string city)
        {
            foreach (string str in citys)
                if (str.Equals(city))
                    return false;
            citys.Add(city);
            return true;
        }
    }
}
