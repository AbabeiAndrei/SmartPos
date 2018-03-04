using System.Threading.Tasks;
using RestSharp;

namespace SmartPos.Desktop.Communication
{
    public interface IApiClient
    {
        Task<T> ExecuteAsync<T>(string resource, Method method, object queryStringParameters, object body = null);
    }
}