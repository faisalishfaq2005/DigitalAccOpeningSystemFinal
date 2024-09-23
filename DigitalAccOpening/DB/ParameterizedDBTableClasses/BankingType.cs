using DigitalAccOpening.DB.DBTableClasses;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class BankingType
    {
        [Key] public int BankingTypeID { get; set; }
        public string BankingTypeName { get; set; }
        
        public ICollection<AccountType> AccountTypes { get; set; }

        public CustomerFurtherInfo? CustomerFurtherInfo { get; set; }


    }
}
