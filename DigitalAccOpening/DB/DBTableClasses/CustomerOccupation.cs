using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerOccupation
    {
        [Key] public int CustomerOccupationID { get; set; }

        public int CustomerID { get; set; }

        public int OccupationID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

        [ForeignKey("OccupationID")]
        public DB.ParameterizedDBTableClasses.Occupation? Occupation { get; set; }
    }
}
