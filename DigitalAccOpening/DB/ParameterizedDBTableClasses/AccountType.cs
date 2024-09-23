using DigitalAccOpening.DB.DBTableClasses;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class AccountType
    {
        [Key] public int AccountTypeID { get; set; }
        public string AccountTypeName { get; set; }

        public int BankingTypeID { get; set; }

        [ForeignKey("BankingTypeID")]
        public BankingType BankingType { get; set; }

        public CustomerFurtherInfo? CustomerFurtherInfo { get; set; }
    }
}
