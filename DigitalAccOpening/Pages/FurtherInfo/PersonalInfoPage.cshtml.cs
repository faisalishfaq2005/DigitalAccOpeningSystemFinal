using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.FurtherInfo
{
    public class PersonalInfoPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public PersonalInfoPageModel(DB.ApplicationDbContext dbContext )
        {
            _dbContext = dbContext;
        }


        [BindProperty]
        public string name { get; set; }

        [BindProperty]
        public string fatherName { get; set; }

        [BindProperty]
        public string dob { get; set; }

        [BindProperty]
        public string placeOfBirth { get; set; }

        [BindProperty]
        public string cnicIssuenceDate { get; set; }

        [BindProperty]
        public string cnicExpiryDate { get; set; }

        [BindProperty]
        public string gender { get; set; }

        [BindProperty]
        public string maritalStatus { get; set; }

        [BindProperty]
        public string religion { get; set; }
        public void OnGet()
        {
            ViewData["ActivePage"] = "PersonalInformation";
                
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");

            DB.DBTableClasses.CustomerPersonalInfo customerPersonalInfo = new DB.DBTableClasses.CustomerPersonalInfo();
            customerPersonalInfo.CustomerName = name;
            customerPersonalInfo.CustomerFatherName = fatherName;
            customerPersonalInfo.CustomerDOB = dob;
            customerPersonalInfo.CustomerPlaceOfBirth = placeOfBirth;
            customerPersonalInfo.CustomerCnicIssuenceDate = cnicIssuenceDate;
            customerPersonalInfo.CustomerCnicExpiryDate = cnicExpiryDate;
            customerPersonalInfo.CustomerGender = gender;
            customerPersonalInfo.CustomerMaritalStatus = maritalStatus;
            customerPersonalInfo.CustomerRelegion = religion;
            customerPersonalInfo.CustomerID = CustomerID.Value;

            _dbContext.CustomerPersonalInfo.Add(customerPersonalInfo);
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("NextOfKinInfoPage");

        }
    }
}
