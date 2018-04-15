using System.Net.Http;

namespace Smartpos.Api.Extensions
{
    public static class RequestExtension
    {
        public static string GetConnectionId(this HttpRequestMessage request)
        {
            return request.Headers.Authorization?.Scheme;
        }
    }
}