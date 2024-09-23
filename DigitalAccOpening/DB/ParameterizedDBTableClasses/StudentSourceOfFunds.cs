using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class StudentSourceOfFunds
    {
        [Key] public int StudentSourceOfFundsID { get; set; }
        public string StudentSourceOfFundsName { get; set; }
    }
}
