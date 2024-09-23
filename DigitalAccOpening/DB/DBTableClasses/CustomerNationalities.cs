using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerNationalities
    {
        [Key] public int CustomerNationalitiesID { get; set; }
        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
        public int NationalityID { get; set; }
        [ForeignKey("NationalityID")]
        public ICollection<DB.ParameterizedDBTableClasses.Nationality>? Nationality { get; set; }

    }
}
