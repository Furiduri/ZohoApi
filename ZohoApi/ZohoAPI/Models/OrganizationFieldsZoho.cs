using System;

namespace ZohoApi.ZohoAPI.Models
{
    public class ListOrganizationFieldsZoho {
        public List<OrganizationFieldsZoho> data { get; set; }
    }
    public class OrganizationFieldsZoho
    {
        /// <summary>
        /// Gets or sets AllowedValues to Fields whit Options.
        /// </summary>
        public List<AllowedValuesZoho>? AllowedValues { get; set; }

        /// <summary>
        /// Gets or sets Unique readonly name of the custom field that can be used to update value of record in api.
        /// </summary>
        public string ApiName { get; set; }

        /// <summary>
        /// gets or sets Number of decimal places the value in a field can take. Applicable for Decimal and Currency fields.
        /// </summary>
        public int? DecimalPlaces { get; set; }

        /// <summary>
        /// Default value set for a field. Applicable for Checkbox fields.
        /// </summary>
        public string? DefaultValue { get; set; }

        /// <summary>
        /// Name of the field on the UI.
        /// </summary>
        public string DisplayLabel { get; set; }

        /// <summary>
        /// Id to Field.
        /// </summary>
        public long? Id { get; set; }

        /// <summary>
        /// Key that returns if the value in the field is encrypted or not.
        /// The field types are Text, Number, Percent, Decimal, Email, Phone, URL which supports encryption.
        /// </summary>
        public bool? isEncryptedField { get; set; }

        /// <summary>
        /// Is Mandatory Field.
        /// </summary>
        public bool? IsMandatory { get; set; }

        /// <summary>
        /// Maximum permissible length of the value in the field. 
        /// Applicable for Text, Number, Decimal, and Currency fields
        /// </summary>
        public int? MaxLength { get; set; }

        /// <summary>
        /// Precision of the value in the field.
        /// Precision refers to the total number of digits in a decimal number. 
        /// For example, the precision of 30.12 is 4. Applicable for Currency fields.
        /// </summary>
        public string? RoundingOption { get; set; }

        /// <summary>
        /// The tool tip of the field.
        /// </summary>
        public string? ToolTip { get; set; }

        /// <summary>
        /// The tool tip of the field.
        /// </summary>
        public string? ToolTipType { get; set; }

        /// <summary>
        /// Data type of the field. 
        /// Values allowed are Text, Number, Percent, Decimal, Currency, Date, Date Time, 
        /// Email, Phone, PickList, Website, Textarea, Checkbox, Multiselect, Boolean and LargeText.
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// AllowedValues Options.
        /// </summary>
        public class AllowedValuesZoho {
            public string? StatusType { get; set; }
            public string? Value { get; set; }
        }
    }

}