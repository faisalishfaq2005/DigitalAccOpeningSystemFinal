using DigitalAccOpening.DB.ParameterizedDBTableClasses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.Customer
{
    public class SelectNationalityPageModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public SelectNationalityPageModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<DB.ParameterizedDBTableClasses.Nationality> Natoinalities { get; set; }





        [BindProperty]
        public List<string> SelectedSources { get; set; }= new List<string>();
        

        public async Task OnGetAsync()
        {
            Natoinalities = await _dbContext.DefinedNationalities.ToListAsync();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("CustomerID");
            foreach (string item in SelectedSources) 
            {
                int NationalityID = await _dbContext.DefinedNationalities.Where(nt => nt.NationalityName == item).Select(nt => nt.NationalityID).FirstOrDefaultAsync();

                if (NationalityID != null)
                {
                    DB.DBTableClasses.CustomerNationalities customerNationalities = new DB.DBTableClasses.CustomerNationalities();
                    customerNationalities.NationalityID = NationalityID;
                    customerNationalities.CustomerID = CustomerID.Value;
                    _dbContext.CustomerNationalities.Add(customerNationalities);
                    await _dbContext.SaveChangesAsync();    
                    
                }
            }
            return RedirectToPage("MotherNameInfo");
        }
    }

}
