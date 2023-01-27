using BSATroop829.Services.BandApiClasses;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;

namespace BSATroop829.Services
{
    public class BandApi
    {
        public static List<Item> GetPosts()
        {
            HttpClient client = new HttpClient();
            //client.BaseAddress = new Uri("https://openapi.band.us/v2.1/bands/");
            client.BaseAddress = new Uri("https://openapi.band.us/v2/band/posts/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            // Send the request to retrieve posts
            //HttpResponseMessage response = client.GetAsync("?access_token=ZQAAAUI--HAT4ar2TNQVdncePU6kt7_qcd6cTFjakKfZo7rGAD3CZtSau1NHhCfbvVYMlDzGW6UMJTlDTfsEUjZ8NBYKA5JGRF4rWFiecPTgyhCy").Result;
            //client.DefaultRequestHeaders.Add("", "");
            var response = client.GetAsync("?band_key=AADvhG7pafhVFqr6UebSPZHm&access_token=ZQAAAUI--HAT4ar2TNQVdncePU6kt7_qcd6cTFjakKfZo7rGAD3CZtSau1NHhCfbvVYMlDzGW6UMJTlDTfsEUjZ8NBYKA5JGRF4rWFiecPTgyhCy&local=en_US").Result;

            // Read the response and display the posts
            string jsonString = response.Content.ReadAsStringAsync().Result;
            Root JsonClass = JsonConvert.DeserializeObject<Root>(jsonString);
            var posts = JsonClass.result_data.items;
            return posts;
        }
        public static DateTime? GetDateTimeFromInt(long? dateAsLong, bool hasTime = true)
        {
            if (dateAsLong.HasValue && dateAsLong > 0)
            {
                if (hasTime)
                {
                    // sometimes input is 14 digit and sometimes 16
                    var numberOfDigits = (int)Math.Floor(Math.Log10(dateAsLong.Value) + 1);

                    if (numberOfDigits > 14)
                    {
                        dateAsLong /= (int)Math.Pow(10, (numberOfDigits - 14));
                    }
                }

                if (DateTime.TryParseExact(dateAsLong.ToString(), hasTime ? "yyyyMMddHHmmss" : "yyyyMMdd",
                                          CultureInfo.InvariantCulture,
                                          DateTimeStyles.None, out DateTime dt))
                {
                    return dt;
                }
            }

            return null;
        }
    }
}

