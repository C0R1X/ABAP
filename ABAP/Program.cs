using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ABAP
{
    class Program
    {
        
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            
            string choice;
            var client = new OpenWeatherMap.OpenWeatherMapClient(cnfg.Api_token);

            Console.WriteLine("City or coords?");
            choice = Console.ReadLine();

            double[] tmp_arr = new double[3];
            int ii;
            WeatherData response;

            switch (choice)
            {
                case "0":
                    response = cnfg.GetResponse("?q=" + Console.ReadLine());
                    
                    break;
                case "1":
                    response = cnfg.GetResponse("?lat=" + cnfg.Shir + "&lon=" + cnfg.Dolg);                   
                    
                    break;
                default:
                    response = cnfg.GetResponse("?lat=" + cnfg.Shir + "&lon=" + cnfg.Dolg);

                    for(int i = 3; i < response.List.Length; i+=8)
                    {
                        ii = 0;
                        for(int j = i; i - j < 2; j--,ii++)
                        {

                            tmp_arr[0] = response.List[j].Main["temp"];
                            tmp_arr[1] = response.List[j-1].Main["temp_min"];
                            tmp_arr[2] = response.List[j-2].Main["temp_max"];
                        }
                        Console.WriteLine(
                            "Max: {0} kelvin\nAvg: {1} kelvin\n\n", tmp_arr.Max(), Math.Round(tmp_arr.Average(),2)
                            ) ;
                    }
                    

                    Console.WriteLine(response.List);
                    break;
            }





            Console.ReadKey();
        }
    }
}
