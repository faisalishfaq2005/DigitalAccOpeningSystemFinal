using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerPreferences
    {
        [Key]public int CustomerPreferencesID { get; set; }

        public string CustomerPreferedCity { get; set; }
        public string CustomerPreferedBranch { get; set; }

        public string? CustomerReferalCode { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
