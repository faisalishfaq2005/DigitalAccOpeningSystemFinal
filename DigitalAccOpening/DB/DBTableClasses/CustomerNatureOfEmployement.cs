using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerNatureOfEmployement
    {
        [Key]public int CustomerNatureOfEmployementID { get; set; }

        public int CustomerID { get; set; }

        public int NatureOfEmployementID { get; set; }

        [ForeignKey("CustomerID")]

        public Customer Customer { get; set; }

        [ForeignKey("NatureOfEmployementID")]

        public DB.ParameterizedDBTableClasses.NatureOfEmployement? NatureOfEmployement { get; set; }

    }
}
