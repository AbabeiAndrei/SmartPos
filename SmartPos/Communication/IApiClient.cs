using System.Threading.Tasks;
using RestSharp;

namespace SmartPos.Desktop.Communication
{
    public interface IApiClient
    {
        bool EnableCache { get; set; }
        Task<T> ExecuteAsync<T>(string resource, Method method, object queryStringParameters, object body = null);
    }
}