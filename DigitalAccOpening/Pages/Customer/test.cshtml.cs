using ACCOP.BL;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DigitalAccOpening.Pages.Customer
{
    public class testModel : PageModel
    {
        public CustomerStartingInfo StartingInfo = new CustomerStartingInfo();
        public string errorMessage = "";
        public string successMessage = "";
        public void OnGet()
        {
        }

        public void OnPost()
        {
            StartingInfo.setCnic(Request.Form["cnic"]);
            StartingInfo.setPhoneNumber(Request.Form["phoneNumber"]);
            StartingInfo.setGmail(Request.Form["gmail"]);
            StartingInfo.setPakistaniNational(Request.Form["pakistaniNational"]);
            StartingInfo.setMotherName(Request.Form["motherName"]);
           // StartingInfo.setPurposeOfAccount(Request.Form["purposeOfAccount"]);
            StartingInfo.setTypeOfBanking(Request.Form["typeOfBanking"]);
           // StartingInfo.setTypeOfAccount(Request.Form["typeOfAccount"]);

            //save data into database

            StartingInfo.setCnic("");
            StartingInfo.setPhoneNumber("");
            StartingInfo.setGmail("");
            StartingInfo.setPakistaniNational("");
            StartingInfo.setMotherName("");
           // StartingInfo.setPurposeOfAccount("");
            StartingInfo.setTypeOfBanking("");
            //StartingInfo.setTypeOfAccount("");

            successMessage = "Data entered Successfully";
        }
    }
}
