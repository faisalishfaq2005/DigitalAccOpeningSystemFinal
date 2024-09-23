using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerMailingAddress
    {
        [Key]public int CustomerMailingAddressID { get; set; }
        public string CustomerPresentCountry { get; set; }
        public string CustomerPresentAddress { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }


    }
}
