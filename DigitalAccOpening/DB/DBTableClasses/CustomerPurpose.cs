using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerPurpose
    {
        [Key]public int CustomerPurposeID { get; set; }

        public int CustomerID { get; set; }

        public int PurposeID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("PurposeID")]
        public DB.ParameterizedDBTableClasses.Purpose? Purpose { get; set; }
    }
}
