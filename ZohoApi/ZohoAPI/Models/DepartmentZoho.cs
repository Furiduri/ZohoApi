using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZohoApi.ZohoAPI.Models
{
    public class ListDepartmentZoho
    {
        public List<DepartmentZoho>? Data { get; set; }
    }

    public class DepartmentZoho
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTimeOffset? CreatedTime { get; set; }
        public string CreatorId { get; set; }
        public string NameInCustomerPortal { get; set; }
        public string? ChatStatus { get; set; }
        public string SanitizedName { get; set; }
        public bool? IsVisibleInCustomerPortal { get; set; }
        public bool? HasLogo { get; set; }
        public bool? IsAssignToTeamEnabled { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsDefault { get; set; }
    }
}
