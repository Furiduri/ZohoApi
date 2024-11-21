using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoApi.ZohoAPI.Models;

namespace ZohoApi.ZohoAPI.Managers
{
    public class OrganizationFieldsManager : ZohoApi.ZohoApi
    {
        private readonly string MethodApi = "/api/v1/organizationFields";
        public OrganizationFieldsManager(ZohoConfig setting) : base(setting)
        {
        }

        /// <summary>
        /// Get OrganizationFields.
        /// </summary>
        /// <param name="module">The module name with in which search to be done. 
        /// Value may be tickets, contacts , accounts ,tasks , calls , events, 
        /// timeEntry,products, contracts, agents.</param>
        /// <param name="apiNames">Key that fetches only the fields whose apiNames are given. 
        /// Multiple values can be passed, with commas for separation.</param>
        /// <param name="departmentId">Key that fetches only the fields for the given departmentId.</param>
        /// <returns>list to Organitaion Fields.</returns>
        /// <exception cref="Exception"></exception>
        public List<OrganizationFieldsZoho>? Get(string module, string? apiNames = null, long? departmentId = null)
        {
            Dictionary<string, string> queryOptions = new Dictionary<string, string>
            {
                {"module", module}
            };
            if (apiNames != null) {
                queryOptions.Add("apiNames", apiNames);
            }
            if (departmentId != null) {
                queryOptions.Add("departmentId", departmentId.ToString());
            }
            ZohoApiResponse<ListOrganizationFieldsZoho?> res = this.RunDeskGet<ListOrganizationFieldsZoho>(this.MethodApi, queryOptions);

            if (res.Status)
            {
                return res.Data?.data;
            }
            else
            {
                throw new HttpRequestException($"Code: {res.Code}, Msg: {res.ErrorMessage}");
            }
        }
    }
}
