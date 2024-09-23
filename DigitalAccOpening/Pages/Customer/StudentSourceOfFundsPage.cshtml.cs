using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class StudentSourceOfFundsPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public StudentSourceOfFundsPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [BindProperty]
        public string sourceoffunds { get; set; }=string.Empty;
        public List<DB.ParameterizedDBTableClasses.StudentSourceOfFunds> studentSourceOfFunds { get; set; } 
        public async Task OnGetAsync()
        {
            studentSourceOfFunds=await _dbContext.DefinedStudentSourceOfFunds.ToListAsync();    
        }
        public IActionResult OnPost()
        {
            if(!string.IsNullOrEmpty(sourceoffunds))
            {
                if(sourceoffunds == "SupportFromFamilyMember")
                {
                    return RedirectToPage("FundProviderInfo");
                        

                }
                else if(sourceoffunds == "School/College/UniversityScholarship")
                {
                    return RedirectToPage("StudentStudyPlaceNamePage");
                }
            }
            return Page();
        }
    }
}
