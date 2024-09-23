using DigitalAccOpening.DB.ParameterizedDBTableClasses;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class Customer
    {
        [Key] public int CustomerID { get; set; }
        public string? Cnic  { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public bool? IsApplicationCompleted { get; set; }

        public bool? IsForwarded { get; set; }

        public CustomerFurtherInfo? CustomerFurtherInfo { get; set; }

        public ICollection<CustomerNationalities>? CustomerNationalities { get; set; }

        public CustomerPurpose? CustomerPurpose { get; set; }

        public CustomerNatureOfEmployement? CustomerNatureOfEmployement { get; set; }

        public CustomerEmployementSector? CustomerEmployementSector { get; set; }

        public CustomerPersonalInfo? CustomerPersonalInfo { get; set; }

        public CustomerNextOfKinInfo? CustomerNextOfKinInfo { get; set; }

        public CustomerPreferences? CustomerPreferences { get; set; }
        public CustomerZakatExemption? CustomerZakatExemption { get; set; }

        public CustomerMailingAddress? CustomerMailingAddress { get; set; }

        public CustomerUploadDocuments? CustomerUploadDocuments { get; set; }

        public CustomerImage? CustomerImage { get; set; }

        public CustomerOccupation? CustomerOccupation { get; set; }
    }
}
