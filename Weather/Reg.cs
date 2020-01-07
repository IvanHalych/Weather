using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Weather
{
    class Reg
    {
        public static string Perevi(string city)
        {
             Regex regex = new Regex(@"^[A-Z]{1}[a-z]+");
            if (regex.IsMatch(city))
                return "q=" + city;
            regex = new Regex(@"^\d{7}$");
            if (regex.IsMatch(city))
                return "id=" + city;
            regex = new Regex(@"^\d{5}$");
            if (regex.IsMatch(city))
                return "zip=" + city;
            regex = new Regex(@"^\d{1-3}\s\d{1-3}$");
            if (regex.IsMatch(city))
            {
                string[] words = city.Split(new char[] { ' ' });
                return "lon=" + words[0]+"&lat="+words[1];
            }
            return null;
        }
    }
}
