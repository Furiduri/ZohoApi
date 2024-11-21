namespace ZohoApi.ZohoAPI.Models
{
    public class ZohoConfig
    {
        public string OrgId { get; set; }
        public string ClientSecret { get; set; }
        public string ClientId { get; set; }
        public string RefreshToken { get; set; }
        public string InicalCodeToken { get; set; }
        public List<string> ScopeList { get; set; }
    }
}
