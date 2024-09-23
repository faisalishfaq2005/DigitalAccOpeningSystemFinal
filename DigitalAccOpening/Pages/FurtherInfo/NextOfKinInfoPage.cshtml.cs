using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MimeKit.Tnef;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class NextOfKinInfoPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        
        public NextOfKinInfoPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
          
        }
        [BindProperty]
        public string kinName { get; set; }

        [BindProperty]
        public string kinCnic { get; set; }

        [BindProperty]
        public string kinMobile { get; set; }

        [BindProperty]
        public string kinRelation { get; set; }
        public void OnGet()
        {
            ViewData["ActivePage"] = "NextOfKin";
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            DB.DBTableClasses.CustomerNextOfKinInfo customerNextOfKinInfo = new DB.DBTableClasses.CustomerNextOfKinInfo();
            customerNextOfKinInfo.CustomerKinName = kinName;
            customerNextOfKinInfo.CustomerKinCnic = kinCnic;
            customerNextOfKinInfo.CustomerKinMobile = kinMobile;
            customerNextOfKinInfo.CustomerKinRelation = kinRelation;
            customerNextOfKinInfo.CustomerID = CustomerID.Value;

            
            

            _dbContext.CustomerNextOfKinInfo.Add(customerNextOfKinInfo);
            await _dbContext.SaveChangesAsync();


            return RedirectToPage("PreferencesPage1");
        }

    }
}
