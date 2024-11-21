using System.Net;

namespace ZohoApi.ZohoAPI.Models
{
    public class ZohoApiResponse<T> 
    {
        public T? Data { get; set; }
        public bool Status { get; set; }
        public HttpStatusCode Code { get; internal set; }
        public string? ErrorMessage { get; internal set; }
    }
}
