using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class EmployementSector
    {
        [Key] public int EmployementSectorID { get; set; }
        public string EmployementSectorName { get; set; }

        public ICollection<DB.DBTableClasses.CustomerEmployementSector>? CustomerEmployementSector { get; set; }
    }
}
