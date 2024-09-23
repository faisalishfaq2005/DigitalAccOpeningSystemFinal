using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerPersonalInfo
    {
        [Key]public int CustomerPersonalInfoID { get; set; }

        public string CustomerName { get; set; }
        public string CustomerFatherName { get; set; }
        public string CustomerDOB { get; set; }
        public string CustomerPlaceOfBirth { get; set; }
        public string CustomerCnicIssuenceDate { get; set; }

        public string CustomerCnicExpiryDate { get; set; }

        public string CustomerGender { get; set; }
        public string CustomerMaritalStatus { get; set; }

        public string CustomerRelegion { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

    }
}
