using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Practice
{
    public class sumModel : PageModel
    {
        public string name="";
        public string classs="";
        public void OnGet()
        {
            TempData.Keep();
            name= TempData["Name"] as string;
            classs= TempData["Class"] as string;
        }
    }
}
