using eShopBelleza.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eShopBelleza.Services
{
    public  class OrdenService : IOrdenService
    {
        public async Task SaveOrden(Orden orden)
        {

            HttpClient client = PreparedClient();

            HttpResponseMessage response = new HttpResponseMessage();

            var jsonContent = JsonConvert.SerializeObject(orden);


            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            response = await client.PostAsync("https://192.168.0.14:45455/api/Orden", contentString);

            if (response.IsSuccessStatusCode)
            {
                await response.Content.ReadAsStringAsync();

            }
        }

        #region private method
        private HttpClient PreparedClient()
        {
            HttpClientHandler handler = new HttpClientHandler();

            //not sure about this one, but I think it should work to allow all certificates:
            handler.ServerCertificateCustomValidationCallback += (sender, cert, chaun, ssPolicyError) =>
            {
                return true;
            };


            HttpClient client = new HttpClient(handler);

            return client;
        }
        #endregion

    }
}
