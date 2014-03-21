using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace VinOpenID.Repository
{
    public class AccountService
    {
        private ILoggingService _loggingService = new LoggingService();
        private ConfigurationService _configService = new ConfigurationService();

        public T GetData<T>(string getRoute)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configService.OpenIDServiceUri);

            // Add an Accept header for JSON format.
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(getRoute).Result;//getRoute = "api/User"

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<T>().Result;
            }
            else
            {
                _loggingService.WriteLog("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
            }
            return default(T);
        }

        public string PostData<T>(T postObject, string postRoute)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(_configService.OpenIDServiceUri);

            client.DefaultRequestHeaders.Accept.Add(
               new MediaTypeWithQualityHeaderValue("application/json"));

            var response = client.PostAsJsonAsync(postRoute, postObject).Result; //postRoute = "api/User"

            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<string>().Result;
            }
            else
            {
                _loggingService.WriteLog("Error Code" +
                response.StatusCode + " : Message - " + response.ReasonPhrase);
                return "sttcode:" + response.StatusCode;
            }
        }
    }
}