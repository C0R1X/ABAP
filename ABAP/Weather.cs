using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ABAP
{
    class WeatherData
    {
        public class Weather
        {
            public Dictionary<string, double> Main { get; set; }

            public Dictionary<string, string> Wind { get; set; }

            public Dictionary<string,string> Date { get; set; }

        }
        
        //public string Date { get; set; }
        public int Count { get; set; }

        

        public Weather[] List { get; set; }

        public double Temperature => List.First().Main["temp"];

        public double Humidity => List.First().Main["humidity"];

        public string WindSpeed => List.First().Wind["speed"];

        public DateTime Date => DateTime.Parse(List.First().Date["dt_txt"]);        // хотел прочитать как словарь, но не получилось

        //public override string ToString()
        //{
        //    string ans;
        //    foreach(int i in List)
        //        ans
        //    return ;
        //}
    }
}
