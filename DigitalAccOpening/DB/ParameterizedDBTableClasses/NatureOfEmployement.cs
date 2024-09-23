using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class NatureOfEmployement
    {
        [Key]public int NatureOfEmployementID { get; set; }
        public string? NatureOfEmployementName { get; set; }

        public  ICollection<DB.DBTableClasses.CustomerNatureOfEmployement>? CustomerNatureOfEmployement { get; set; }
    }
}
