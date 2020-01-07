using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;


namespace Weather
{
    public partial class Form1 : Form
    {
        string lastcity;
        ListCitys listCitys;
        public Form1()
        {
            FirstStart(out lastcity, out listCitys);
            InitializeComponent();
            this.City.Text = lastcity;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            JObject now = Call.Calling(Reg.Perevi(City.Text));
            Show(now);
            Save();
        }
        static void FirstStart(out string lastcity, out ListCitys listCitys)
        {
            lastcity = (string)Serialization.Load("LastCity");
            listCitys = (ListCitys)Serialization.Load("ListCitys");
            if ((listCitys == null) || (listCitys.Time.Day != DateTime.Now.Day))
                listCitys = new ListCitys(DateTime.Now);
        }
        void Show(JObject obj)
        {

            string description = GetValue(obj, "weather", "description");
            label4.Text = description;
            label5.Text = (Double.Parse(GetValue(obj, "main", "temp_min")) - 273.15).ToString();
            label6.Text = (Double.Parse(GetValue(obj, "main", "temp_max")) - 273.15).ToString();
            Picture.Image = Image.FromFile(GetValue(obj, "weather", "icon") + ".png");
            lastcity = obj.GetValue("name").ToString();
            if (description.ToString().Equals("Rain"))
                if (listCitys.Add(lastcity))
                    MessageBox.Show("It will rain");
        }
        void Save()
        {
            Serialization.Save(lastcity, "LastCity");
            Serialization.Save(listCitys, "ListCitys");
        }
        string GetValue(JObject obj, string masiv, string nameValue)
        {
            if (masiv== "weather")
                return JObject.Parse(obj.GetValue(masiv).ToString().Replace('[', ' ').Replace(']', ' ')).GetValue(nameValue).ToString();
            return JObject.Parse(obj.GetValue(masiv).ToString()).GetValue(nameValue).ToString();
        }
    }
}
