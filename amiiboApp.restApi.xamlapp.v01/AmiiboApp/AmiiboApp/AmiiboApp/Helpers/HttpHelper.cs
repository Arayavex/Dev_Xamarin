using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AmiiboApp.Helpers
{
    public class HttpHelper<T>
    {
        //Recibe como paramtro la URL del servicio
        public async Task<T> GetRestServiceDataAsync(string serviceAddress)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(serviceAddress);

            var response =
                await client.GetAsync(client.BaseAddress);
            response.EnsureSuccessStatusCode();

            var jsonResult =
                await response.Content.ReadAsStringAsync();

            var result = JsonConvert.DeserializeObject<T>(jsonResult);
            return result;
        }


    }
}
