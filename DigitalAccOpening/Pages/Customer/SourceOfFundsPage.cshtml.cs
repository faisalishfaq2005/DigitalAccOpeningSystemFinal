using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class SourceOfFundsPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;

        public SourceOfFundsPageModel(DB.ApplicationDbContext dbcontext)
        {
            _dbContext = dbcontext;
        } 
        
        
        [BindProperty]
        public List<string> SelectedSources { get; set; }= new List<string>();

        public List<DB.ParameterizedDBTableClasses.SourceOfFunds> SourceOfFunds { get; set; }

        public async void OnGetAsync()
        {
            SourceOfFunds=await _dbContext.DefinedSourcesOfFunds.ToListAsync(); 
        }

        public IActionResult OnPost()
        {
            // Handle the post request and process the selected checkbox values
            if (SelectedSources != null && SelectedSources.Count > 0)
            {
                // Process the selected sources
                // Example: You can iterate over the selected sources and save them to the database
                foreach (var source in SelectedSources)
                {
                    // Save or process each selected source
                    // For example: Save to database or use in further logic
                }

            }
            return RedirectToPage("/FurtherInfo/RequiredDocumentsPage");
        }
    }
}
