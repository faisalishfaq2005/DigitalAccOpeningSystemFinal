using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.ParameterizedDBTableClasses
{
    public class PensionerType
    {
        [Key] public int PensionerTypeID { get; set; }
        public string PensionerTypeName { get; set; }
    }
}
