using eShopBelleza.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace eShopBelleza.Services
{
    public class ProductService : IProductService
    {
            

        public ProductService() {}

        
        public async Task<ObservableCollection<Product>> GetProducts()
        {

            HttpClient client = PreparedClient();

            HttpResponseMessage response = new HttpResponseMessage();

            response = await client.GetAsync("https://192.168.0.14:45455/api/Product");

            if (response.IsSuccessStatusCode)
            {
                string result = await response.Content.ReadAsStringAsync();

                var products = JsonConvert.DeserializeObject<ObservableCollection<Product>>(result);

                return products;
            }

            return null;
 
        }


        public async Task UpdateProductStockBy(int id, int stock)
        {
            UpdateProducById updateProducById = new UpdateProducById{ Id = id, Stock= stock};

            HttpClient client = PreparedClient();

            HttpResponseMessage response = new HttpResponseMessage();

            var jsonContent = JsonConvert.SerializeObject(updateProducById);


            var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");

            response = await client.PutAsync("https://192.168.0.14:45455/api/Product", contentString);

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

        public class UpdateProducById
        {
            public int Id { get; set; }

            public int Stock { get; set; }
        }

        #endregion+
    }
}
