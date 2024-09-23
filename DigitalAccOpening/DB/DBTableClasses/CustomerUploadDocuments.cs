using System.ComponentModel.DataAnnotations.Schema;

namespace DigitalAccOpening.DB.DBTableClasses
{
    public class CustomerUploadDocuments
    {
        public int CustomerUploadDocumentsID { get; set; }

        public byte[] CustomerCNICFront { get; set; }

        public byte[] CustomerCNICBack { get; set; }

        public byte[] CustomerPaySlip { get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }

    }
}
