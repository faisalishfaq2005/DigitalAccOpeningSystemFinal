using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerFurtherInfo
    {
        [Key] public int CustomerFurtherInfoID { get; set; }
        public bool? TaxResidentAnotherCountry { get; set; }

        public bool? OtherNationalities { get; set; }

        public string? MotherName { get; set; }
        public string? PlaceOfBirth { get; set; }
        public bool? IsUSAResident { get; set; }
        public bool? IsUSACitizen { get; set; }
        public bool? IsUSALinks { get; set; }
        public bool? IsUSAMandate { get; set; }

        public int? CustomerID { get; set; }
        public int? BankingTypeID { get; set; }
        public int? AccountTypeID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer? Customer { get; set; }

        [ForeignKey("BankingTypeID")]
        public DB.ParameterizedDBTableClasses.BankingType? BankingType { get; set; }

        [ForeignKey("AccountTypeID")]
        public DB.ParameterizedDBTableClasses.AccountType? AccountType { get; set; }




    }
}
