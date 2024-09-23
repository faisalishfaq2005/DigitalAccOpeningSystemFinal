using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class Nationality
    {
        [Key] public int NationalityID { get; set; }
        public string NationalityName { get; set; }

        public ICollection<DB.DBTableClasses.CustomerNationalities>? CustomerNationalities { get; set; }
    }
}
