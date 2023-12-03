using System.Net.Http.Headers;
using System.Text.Json;

namespace ETS.UI
{
    public class WebRequest
    {
        public static HttpResponseMessage WebApiPostRequest(string webApiDomainAddress, string apiRequestAddress, Models.PersonelViewModel entity)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(webApiDomainAddress);
            HttpResponseMessage result = client.PostAsJsonAsync(apiRequestAddress, entity).Result;
            return result;
        }

        public static HttpResponseMessage WebApiGetRequest(string webApiDomainAddress, string apiRequestAddress)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(webApiDomainAddress);
            HttpResponseMessage result = client.GetAsync(apiRequestAddress).Result;
            return result;
        }

        public static HttpResponseMessage WebApiDeleteRequest(string webApiDomainAddress, string apiRequestAddress)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };

            HttpClient client = new HttpClient(clientHandler);
            client.BaseAddress = new Uri(webApiDomainAddress);
            HttpResponseMessage result = client.DeleteAsync(apiRequestAddress).Result;
            return result;
        }

        public static HttpResponseMessage WebApiPutRequest(string webApiDomainAddress, string apiRequestAddress, Models.PersonelViewModel entity)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };                       
            HttpClient client = new HttpClient(clientHandler);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(webApiDomainAddress);
            HttpResponseMessage result = client.PutAsJsonAsync(apiRequestAddress, entity).Result;
            return result;
        }
    }
}
