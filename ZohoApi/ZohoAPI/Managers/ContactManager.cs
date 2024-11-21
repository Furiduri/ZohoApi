using ZohoApi.ZohoAPI.Models;

namespace ZohoApi.ZohoAPI.Managers
{
    public class ContactManager : ZohoApi.ZohoApi
    {
        private readonly string MethodApi = "/api/v1/contacts";
        public ContactManager(ZohoConfig setting) : base(setting)
        {            
        }

        /// <summary>
        /// This API lists a particular number of contacts, based on the limit specified.
        /// </summary>
        /// <returns>lists a particular number of contacts</returns>
        /// <exception cref="HttpRequestException"></exception>
        public List<ContactZoho>? Get()
        {
            ZohoApiResponse<ListContactZoho?> res = this.RunDeskGet<ListContactZoho>(this.MethodApi);
            if (res.Status)
            {
                return res.Data?.data;
            }
            else
            {
                throw new HttpRequestException($"Code: {res.Code}, Msg: {res.ErrorMessage}");
            }
        }

        /// <summary>
        /// This API fetches a single contact from your help desk portal.
        /// </summary>
        /// <returns>Single contact</returns>
        /// <exception cref="HttpRequestException"></exception>
        public ContactZoho? Get(long contact_id)
        {
            ZohoApiResponse<ContactZoho?> res = this.RunDeskGet<ContactZoho>(this.MethodApi, new Dictionary<string, string>
            {
                {"contact_id", contact_id.ToString() }
            });

            if (res.Status)
            {
                return res.Data;
            }
            else
            {
                throw new HttpRequestException($"Code: {res.Code}, Msg: {res.ErrorMessage}");
            }
        }
    }
}
