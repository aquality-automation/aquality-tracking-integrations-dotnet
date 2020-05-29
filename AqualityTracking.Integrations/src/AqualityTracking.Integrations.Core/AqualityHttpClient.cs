using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AqualityTracking.Integrations.Core
{
    public class AqualityHttpClient : IHttpClient
    {
        private readonly Configuration configuration;
        private readonly HttpClient client;        

        public AqualityHttpClient(Configuration configuration)
        {
            this.configuration = configuration;
            client = new HttpClient();
            client.DefaultRequestHeaders.Authorization = GetAuthorizationHeader();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeConstants.ApplicationJson));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MediaTypeConstants.Wildcard));
        }

        private AuthenticationHeaderValue GetAuthorizationHeader()
        {
            var authString = $"project:{configuration.ProjectId}:{configuration.Token}";
            var encodedAuthString = Convert.ToBase64String(Encoding.UTF8.GetBytes(authString));
            return new AuthenticationHeaderValue("Basic", encodedAuthString);
        }

        public TResponse SendGET<TResponse>(Uri requestUri)
        {
            return ExecureRequest<TResponse>(requestUri, uri => client.GetAsync(uri));
        }

        public TModel SendPOST<TModel>(Uri requestUri, TModel body)
        {
            var jsonBody = JsonConvert.SerializeObject(body);
            return SendPOST<TModel>(requestUri, new StringContent(jsonBody, Encoding.UTF8, MediaTypeConstants.ApplicationJson));
        }

        public TResponse SendPOST<TResponse>(Uri requestUri, HttpContent content)
        {         
            return ExecureRequest<TResponse>(requestUri, uri => client.PostAsync(uri, content));
        }

        private TResponse ExecureRequest<TResponse>(Uri uri, Func<Uri, Task<HttpResponseMessage>> getResponse)
        {
            var response = getResponse(uri).Result;
            var content = response.Content.ReadAsStringAsync().Result;

            if (!response.IsSuccessStatusCode)
            {
                var statusCode = response.StatusCode;
                throw new AqualityException($"Status code: {(int) statusCode} {statusCode}. Reason: {content}. Request uri: {uri}");
            }

            return JsonConvert.DeserializeObject<TResponse>(content);
        }
    }
}
