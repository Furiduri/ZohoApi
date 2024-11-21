namespace ZohoApi.ZohoAPI.Models
{
    public class ListContactZoho
    {
        public List<ContactZoho> data { get; set; }
    }
    public class ContactZoho
    {
        public string? id { get; set; }
        public string? firstName { get; set; }
        public string? lastName { get; set; }
        public string? accountCount { get; set; }
        public string? email { get; set; }
        public string? secondaryEmail { get; set; }
        public string? mobile { get; set; }
        public string? phone { get; set; }
        public object? type { get; set; }
        public DateTime? createdTime { get; set; }
        public string? ownerId { get; set; }
        public string? accountId { get; set; }
        public ZohoCRMContact? zohoCRMContact { get; set; }
        public bool? isSpam { get; set; }
        public bool? isAnonymous { get; set; }
        public bool? isEndUser { get; set; }
        public string? photoURL { get; set; }
        public CustomerHappiness? customerHappiness { get; set; }
        public string? webUrl { get; set; }

        public class CustomerHappiness
        {
            public string badPercentage { get; set; }
            public string okPercentage { get; set; }
            public string goodPercentage { get; set; }
        }

        public class ZohoCRMContact
        {
            public string id { get; set; }
            public string type { get; set; }
        }

    }
}