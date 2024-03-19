using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App1.Rest
{
    public class RestService : IRestService
    {
        private HttpClient client;


        private const string BaseUrL = "http://192.168.1.37:81/apirest";

        public RestService()
        {
            client = new HttpClient
            {
                BaseAddress = new Uri(BaseUrL),
                MaxResponseContentBufferSize = 256000
            };
        }

        public async Task<string> Get(string uri)
        {
            var response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            return response.Content.ReadAsStringAsync().Result;

        }

        public async Task<string> Post(string uri, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync(uri, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Put(string uri, string json)
        {
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PutAsync(uri, content);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(string uri)
        {
            var response = await client.DeleteAsync(uri);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

    }

    public interface IRestService
    {
        Task<string> Get(string uri);
        Task<string> Post(string uri, string json);
        Task<string> Put(string uri, string json);
        Task<string> Delete(string uri);
    }
}