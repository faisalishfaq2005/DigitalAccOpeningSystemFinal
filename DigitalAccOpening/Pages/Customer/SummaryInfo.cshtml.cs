using ACCOP.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class SummaryModel : PageModel
    {
        /*public CustomerStartingInfo CS=new CustomerStartingInfo();

        public void OnGet()
        {
            CS.setGmail(TempData["Gmail"] as string);
            CS.setCnic(TempData["Cnic"] as string);
            CS.setPhoneNumber(TempData["PhoneNumber"] as string);
            CS.setMotherName(TempData["MotherName"] as string);
            CS.setPakistaniNational(TempData["PakistaniNational"] as string);
            CS.setTypeOfBanking(TempData["TypeOfBanking"] as string);
        }*/

        public string Gmail { get; set; }
        public string Cnic { get; set; }
        public string PhoneNumber { get; set; }
        public string MotherName { get; set; }
        public string PakistaniNational { get; set; }

        public string TypeOfBanking { get; set; }

        public void OnGet()
        {
            Gmail = TempData["Gmail"] as string;
            Cnic = TempData["CnicInfo"] as string;
            PhoneNumber = TempData["PhoneNumber"] as string;
            MotherName = TempData["MotherName"] as string;
            PakistaniNational = TempData["PakistaniNational"] as string;
            TypeOfBanking = TempData["TypeOfBanking"] as string;

            TempData.Keep();
        }
    }
}
