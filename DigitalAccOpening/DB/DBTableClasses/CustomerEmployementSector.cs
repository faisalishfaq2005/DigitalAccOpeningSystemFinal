using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerEmployementSector
    {
        [Key]public int CustomerEmployementSectorID { get; set; }

        public int CustomerID { get; set; }

        public int EmployementSectorID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("EmployementSectorID")]
        public DB.ParameterizedDBTableClasses.EmployementSector? EmployementSector { get; set; }
    }
}
