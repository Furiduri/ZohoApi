namespace ZohoApi.ZohoAPI.Models
{
    public class TicketZoho
    {
        /// <summary>
        /// Gets or sets Classification.
        /// </summary>
        public string? Classification { get; set; }

        /// <summary>
        /// Gets or sets Details of the contact who raised the ticket. 
        /// This object is used for automatically creating a contact when a ticket is received. 
        /// If the email ID of the contact already exists in your portal, 
        /// the corresponding contactId is used for creating the ticket. 
        /// Else, a contact is first created and the contactId of the new contact is mapped to the ticket. 
        /// The user’s profile and field permissions are considered in the contact creation process. 
        /// Either the lastName or the email attribute must be present in the object.
        /// </summary>
        public ContactDTO? Contact { get; set; }

        /// <summary>
        /// gets or sets ID of the contact who raised the ticket. 
        /// If a value is not available for this key, make sure to include the Contact JSON object. 
        /// If neither attribute is available, an error message regarding the unavailability of the contactId message is returned.
        /// </summary>
        public string? ContactId { get; set; }

        /// <summary>
        /// Gets or sets ID of the department to which the ticket belongs.
        /// Required.
        /// </summary>
        public long? DepartmentId { get; set; }

        /// <summary>
        /// Gets or sets Description in the ticket.
        /// Optional.
        /// Max chars : 65535
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets ID of the ticket.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Gets or sets Priority.
        /// </summary>
        public string? Priority { get; set; }

        /// <summary>
        /// Gets or sets Subject of the ticket. 
        /// Required.
        /// Max chars : 255
        /// </summary>
        public string? Subject { get; set; }

        /// <summary>
        /// Gets or sets Language preference to set for the ticket.
        /// Optional        
        /// Max chars : 255
        /// </summary>
        public string? Language { get; set; }

        /// <summary>
        /// Gets or sets Status of the ticket. 
        /// Includes the custom statuses configured in your help desk portal.
        /// Optional.
        /// Max chars : 120
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Due date for resolving the ticket.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Channel through which the ticket originated.
        /// </summary>
        public string? Channel { get; set; }

        public CustomField? Cf { get; set; }
        public class ContactDTO
        {
            /// <summary>
            /// Gets or sets Email ID of the contact.
            /// </summary>
            public string Email { get; set; }

            /// <summary>
            /// Gets or sets First name of the contact.
            /// </summary>
            public string FirstName { get; set; }

            /// <summary>
            /// Gets or sets Last name of the contact.
            /// </summary>
            public string LastName { get; set; }
            /// <summary>
            /// Gets or sets Phone number of the contact.
            /// </summary>
            public string? Phone { get; set; }
        }
        public class CustomField
        {
            public string? Cf_modulo_error { get; set; }

            public string? Cf_severidad { get; set; }

            public string? Cf_esfuerzo { get; set; }

            public string? Cf_frecuencia { get; set; }
        }
    }

}
