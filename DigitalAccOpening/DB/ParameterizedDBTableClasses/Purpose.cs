using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class Purpose
    {
        [Key] public int PurposeID { get; set; }
        public string PurposeName { get; set; }

        public ICollection<DB.DBTableClasses.CustomerPurpose>? CustomerPurpose { get; set; }
    }
}
