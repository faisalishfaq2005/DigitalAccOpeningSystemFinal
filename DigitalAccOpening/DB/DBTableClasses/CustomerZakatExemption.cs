using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerZakatExemption
    {
        [Key]public int CustomerZakatExemptionID { get; set; }

        public string CustomerMonthlyDebitTurnOver { get; set; }
        public string CustomerMonthlyCreditTurnOver { get; set; }
        public string CustomerExpectedModeOfTransaction { get; set; }

        public string CustomerMonthlyIncome { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

    }
}
