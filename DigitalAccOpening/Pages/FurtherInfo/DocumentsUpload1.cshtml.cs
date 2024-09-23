using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class DocumentsUpload1Model : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public DocumentsUpload1Model(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [BindProperty]
        public IFormFile CNICFront { get; set; }

        [BindProperty]
        public IFormFile CNICBack { get; set; }
        [BindProperty]
        public IFormFile PaySlip { get; set; }


        public void OnGet()
        {
            ViewData["ActivePage"] = "UploadDocuments";
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            var cnicFrontBytes = await ConvertToByteArrayAsync(CNICFront);
            var cnicBackBytes = await ConvertToByteArrayAsync(CNICBack);
            var PaySlipBytes = await ConvertToByteArrayAsync(PaySlip);
            DB.DBTableClasses.CustomerUploadDocuments customerUploadDocuments = new DB.DBTableClasses.CustomerUploadDocuments();
            customerUploadDocuments.CustomerCNICFront = cnicFrontBytes;
            customerUploadDocuments.CustomerCNICBack = cnicBackBytes;
            customerUploadDocuments.CustomerPaySlip = PaySlipBytes;
            customerUploadDocuments.CustomerID = CustomerID.Value;
            _dbContext.CustomerUploadDocuments.Add(customerUploadDocuments);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("CaptureImagePage");
        }

        public async Task<byte[]> ConvertToByteArrayAsync(IFormFile formFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                await formFile.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }

        }

        
    }
}
