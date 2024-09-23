using System.ComponentModel.DataAnnotations;

namespace DigitalAccOpening.DB.BackOfficeDB
{
    public class BackOfficeLoginDetails
    {
        [Key]public int BackOfficeLoginDetailsID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }
}
