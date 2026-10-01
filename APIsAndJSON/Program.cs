using System.Net.Http;
using System.Runtime.InteropServices.JavaScript;
using Newtonsoft.Json.Linq;

namespace APIsAndJSON
{
    public class Program
    {
        static void Main(string[] args)
        {
            RonVSKanyeAPI.KanyeQuote();

            RonVSKanyeAPI.RonQuote();

            var client = new HttpClient();
            var key = "507093d373c2fe07be4671eae7eeb547";

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Please Enter City Name");
                var city = Console.ReadLine();
                Console.WriteLine("");

                var weatherURL = "https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=imperial";
                var response = client.GetStringAsync(weatherURL).Result;

                var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
                var temp = JObject.Parse(formattedResponse).GetValue("temp");
                Console.WriteLine($"The current temperature is {temp} degrees Fahrenheit");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("Would you like to exit?");
                var userInput = Console.ReadLine();
                Console.WriteLine("");
                Console.WriteLine("");

                if (userInput.ToLower().Trim() == "yes")
                {
                    break;
                }
            }
        }
    }
}
