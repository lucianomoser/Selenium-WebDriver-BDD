using System.Threading.Tasks;

namespace System.Net.Http
{
    public static class PostExtensions
    {
        public static HttpResponseMessage Post(this HttpClient client, string requestUri, HttpContent content)
        {
            var response = client.PostAsync(requestUri, content);
            response.Wait();
            return response.Result;
        }

        public static string ReadAsString(this HttpContent content)
        {
            var result = content.ReadAsStringAsync();
            result.Wait();
            return result.Result;
        }

        public static HttpResponseMessage GetResult(this Task<HttpResponseMessage> response)
        {
            response.Wait();
            return response.Result;
        }

        public static string GetResult(this Task<string> x)
        {
            x.Wait();
            return x.Result;
        }
    }
}
