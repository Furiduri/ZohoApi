using System.Runtime.Serialization;
using ZohoApi.ZohoAPI.Extender;

namespace ZohoApi.ZohoApi.Models
{
    public class AccessRefreshToken
    {
        public string RefreshToken { get; set; }
        public string GrantType = "refresh_token";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public List<string> ScopeList { get; set; }
        public string ScopeString
        {
            get
            {
                return string.Join(",",ScopeList);
            }
        }
        public string RedirectUri { get; set; }
    }
}