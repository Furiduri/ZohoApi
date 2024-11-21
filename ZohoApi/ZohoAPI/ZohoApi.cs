using RestSharp;
using System.Text.Json;
using System.Text.Json.Serialization;
using ZohoApi.ZohoApi.Models;
using ZohoApi.ZohoAPI.Models;

namespace ZohoApi.ZohoApi
{
    public class ZohoApi
    {
        protected readonly string API_URL_DESK = "https://desk.zoho.com";
        protected readonly string API_URL_AUTH = "https://accounts.zoho.com/oauth/v2";
        protected string OrgId { get; set; }
        protected AuthTokenZoho? TokenAuth { get; set; }

        /// <summary>
        /// Constructor Zoho Api.
        /// </summary>
        /// <param name="setting">Configuration and credentias.</param>
        /// <exception cref="Exception"></exception>
        public ZohoApi(ZohoConfig setting)
        {
            this.OrgId = setting.OrgId;
            ZohoApiResponse<AuthTokenZoho?> res;
            if (string.IsNullOrEmpty(setting.InicalCodeToken))
            {
                res = RunAuthRefreshPost(new AccessRefreshToken
                {
                    RefreshToken = setting.RefreshToken,
                    ClientId = setting.ClientId,
                    ClientSecret = setting.ClientSecret,
                    ScopeList = setting.ScopeList,
                    RedirectUri = ""
                });
            }
            else
            {
                res = RunAuthPost(new AccesTokenCodeParams
                {
                    AuthorizationCode = setting.InicalCodeToken,
                    ClientSecret = setting.ClientSecret,
                    ClientId = setting.ClientId,
                    RedirectUri = ""
                });
            }

            if (res.Status)
            {
                this.TokenAuth = res.Data;
            }
            else
            {
                throw new Exception($"Code: {res.Code}, Msg: {res.ErrorMessage}");
            }
        }

        /// <summary>
        /// Refresh Token.
        /// </summary>
        public string? RefreshToken { get { return this.TokenAuth?.refresh_token; } }

        /// <summary>
        /// Request GET API Zoho.
        /// </summary>
        /// <typeparam name="T">Object class.</typeparam>
        /// <param name="zohoAPIMethod">Method api.</param>
        /// <param name="queryParams">Query params in URL.</param>
        /// <returns>Response to Request GET.</returns>
        protected ZohoApiResponse<T?> RunDeskGet<T>(string zohoAPIMethod, Dictionary<string, string>? queryParams = null)
        {
            var client = new RestClient(API_URL_DESK);

            var request = new RestRequest(zohoAPIMethod, Method.Get);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("orgId", this.OrgId);
            request.AddHeader("Authorization", "Zoho-oauthtoken " + this.TokenAuth?.access_token);

            if (queryParams != null)
            {
                foreach (string key in queryParams.Keys)
                {
                    request.AddQueryParameter(key, queryParams[key]);
                }
            }

            var response = client.Execute<T>(request);
            return new ZohoApiResponse<T?>
            {
                Data = response.Data,
                Status = response.IsSuccessStatusCode,
                Code = response.StatusCode,
                ErrorMessage = response.ErrorException?.Message
            };
        }

        /// <summary>
        /// Request POST API Zoho.
        /// </summary>
        /// <typeparam name="T">Type class to result object.</typeparam>
        /// <typeparam name="Tinput">Type class to send object.</typeparam>
        /// <param name="dataToSend">Object to Send.</param>
        /// <param name="zohoAPIMethod">Method api.</param>
        /// <returns>Response to Request POST.</returns>
        protected ZohoApiResponse<T?> RunDeskPost<T>(T dataToSend, string zohoAPIMethod)
        {
            var client = new RestClient(API_URL_DESK);

            var postRequest = new RestRequest(zohoAPIMethod, Method.Post);
            postRequest.RequestFormat = DataFormat.Json;
            postRequest.AddHeader("orgId", this.OrgId);
            postRequest.AddHeader("Authorization", "Zoho-oauthtoken " + this.TokenAuth?.access_token);

            postRequest.AddJsonBody(JsonSerializer.Serialize(dataToSend, new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                PropertyNameCaseInsensitive = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
            }));
            RestResponse<T> postResponse = client.Execute<T>(postRequest);
            return new ZohoApiResponse<T?>
            {
                Data = postResponse.Data,
                Status = postResponse.IsSuccessStatusCode,
                Code = postResponse.StatusCode,
                ErrorMessage = postResponse.ErrorException?.Message
            };
        }

        private ZohoApiResponse<AuthTokenZoho?> RunAuthPost(AccesTokenCodeParams tokenParams)
        {
            var client = new RestClient(API_URL_AUTH);

            var postRequest = new RestRequest("/token", Method.Post);
            postRequest.RequestFormat = DataFormat.Json;
            postRequest.AddQueryParameter("code", tokenParams.AuthorizationCode);
            postRequest.AddQueryParameter("grant_type", tokenParams.GrantType);
            postRequest.AddQueryParameter("client_id", tokenParams.ClientId);
            postRequest.AddQueryParameter("client_secret", tokenParams.ClientSecret);
            postRequest.AddQueryParameter("redirect_uri", tokenParams.RedirectUri);

            var postResponse = client.Execute<AuthTokenZoho>(postRequest);

            return new ZohoApiResponse<AuthTokenZoho?>
            {
                Data = postResponse.Data,
                Status = postResponse.IsSuccessStatusCode,
                Code = postResponse.StatusCode,
                ErrorMessage = postResponse.ErrorException?.Message
            };
        }

        private ZohoApiResponse<AuthTokenZoho?> RunAuthRefreshPost(AccessRefreshToken tokenParams)
        {
            var client = new RestClient(API_URL_AUTH);

            var postRequest = new RestRequest("/token", Method.Post);
            postRequest.RequestFormat = DataFormat.Json;
            postRequest.AddQueryParameter("refresh_token", tokenParams.RefreshToken);
            postRequest.AddQueryParameter("grant_type", tokenParams.GrantType);
            postRequest.AddQueryParameter("client_id", tokenParams.ClientId);
            postRequest.AddQueryParameter("client_secret", tokenParams.ClientSecret);
            postRequest.AddQueryParameter("scope", tokenParams.ScopeString);
            postRequest.AddQueryParameter("redirect_uri", tokenParams.RedirectUri);

            var postResponse = client.Execute<AuthTokenZoho>(postRequest);
            if (postResponse.Data != null)
            {
                postResponse.Data.refresh_token = tokenParams.RefreshToken;
            }

            return new ZohoApiResponse<AuthTokenZoho?>
            {
                Data = postResponse.Data,
                Status = postResponse.IsSuccessStatusCode,
                Code = postResponse.StatusCode,
                ErrorMessage = postResponse.ErrorException?.Message
            };
        }
    }
}
