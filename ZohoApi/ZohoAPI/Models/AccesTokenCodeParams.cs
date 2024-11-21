namespace ZohoApi.ZohoApi.Models
{
    public class AccesTokenCodeParams
    {
        public string AuthorizationCode { get; set; }
        public string GrantType = "authorization_code";
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string RedirectUri { get; set; }
    }
}