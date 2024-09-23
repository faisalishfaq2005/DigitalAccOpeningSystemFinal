using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerNextOfKinInfo
    {
        [Key] public int CustomerNextOfKinInfoID { get; set; }

        public string CustomerKinName { get; set; }
        public string CustomerKinCnic { get; set; }
        public string CustomerKinMobile { get; set; }

        public string CustomerKinRelation { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }
    }
}
