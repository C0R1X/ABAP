using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Text;

namespace ABAP
{
    class cnfg
    {
       

        const string shir = "55.7617262"; 
        const string dolg = "49.233673";
        const string _api_token = "02706ff64b3151ff99487ece2e023cd1";

        public static string API_URL = "http://api.openweathermap.org/data/2.5/forecast";

        public static string Api_token => _api_token;
        public static string Shir => shir;
        public static string Dolg => dolg;



        public static WeatherData GetResponse(String url)
        {
            using (var client = new WebClient())
            {
                Trace.WriteLine("<HTTP - GET - " + url + " >");
                var response = client.DownloadString(string.Format("{0}{1}&appid={2}", API_URL, url, _api_token));
                var weatherDataParsed = JsonConvert.DeserializeObject<WeatherData>(response);
                return weatherDataParsed;
            }
        }
    }
}
