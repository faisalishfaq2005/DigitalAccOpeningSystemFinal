using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class SourceOfFunds
    {
        [Key] public int SourceOfFundsId { get; set; }
        public string SourceOfFundsName { get; set; }
    }
}
