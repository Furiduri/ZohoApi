using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZohoApi.ZohoAPI.Models;

namespace ZohoApi.ZohoAPI.Managers
{
    public class DepartmentManager : ZohoApi.ZohoApi
    {
        private readonly string MethodApi = "/api/v1/departments";
        public DepartmentManager(ZohoConfig setting) : base(setting)
        {
        }

        public object? Get()
        {
            Dictionary<string, string> queryParams = new Dictionary<string, string>();
            queryParams.Add("isEnabled", "true");
            ZohoApiResponse<ListDepartmentZoho?> res = this.RunDeskGet<ListDepartmentZoho>(this.MethodApi, queryParams);
            if (res.Status)
            {
                return res.Data?.Data;
            }
            else
            {
                throw new HttpRequestException($"Code: {res.Code}, Msg: {res.ErrorMessage}");
            }
        }
    }
}
