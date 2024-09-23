using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using static System.Net.Mime.MediaTypeNames;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class CaptureImagePageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public CaptureImagePageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public string ImageData { get; set; }


        public void OnGet()
        {
            ViewData["ActivePage"] = "CaptureImage";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            var customer = await _dbContext.Customer.FindAsync(CustomerID.Value);
            customer.IsApplicationCompleted = true;
            customer.IsForwarded = false;
            var base64Data = ImageData.Substring(ImageData.IndexOf(',') + 1);
            byte[] imageBytes = Convert.FromBase64String(base64Data);

            DB.DBTableClasses.CustomerImage customerImage = new DB.DBTableClasses.CustomerImage();
            customerImage.CustomerImageData = imageBytes;
            customerImage.CustomerID = CustomerID.Value;
            
            _dbContext.CustomerImage.Add(customerImage);
            await _dbContext.SaveChangesAsync();

            return RedirectToPage("VerifyEnteredDataPage");

        }
    }
}
