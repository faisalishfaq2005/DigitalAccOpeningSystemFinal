using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class Occupation
    {
        [Key] public int OccupationID { get; set; }
        public string OccupationName { get; set; }
        public ICollection<DB.DBTableClasses.CustomerOccupation>? CustomerOccupation { get; set; }

    }
}
