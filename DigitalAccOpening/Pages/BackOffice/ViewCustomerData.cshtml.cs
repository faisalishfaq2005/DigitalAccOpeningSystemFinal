using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.Pages.BackOffice
{
    public class ViewCustomerDataModel : PageModel
    {
        private readonly DB.ApplicationDbContext _dbContext;
        public ViewCustomerDataModel(DB.ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;

        }

        public string decryptedCnic { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public string TaxResidentAnotherCountry { get; set; }
        public string OtherNationalities { get; set; }
        public string MotherName { get; set; }
        public string PlaceOfBirth { get; set; }
        public string IsUSAResident { get; set; }

        public string IsUSACitizen { get; set; }

        public string IsUSALinks { get; set; }
        public string IsUSAMandate { get; set; }
        public string BankingType { get; set; }
        public string AccountType { get; set; }
        public string CustomerPurpose { get; set; }

        public string name { get; set; }

        public string fatherName { get; set; }

        public string dob { get; set; }

        public string cityOfBirth { get; set; }

        public string cnicIssuenceDate { get; set; }

        public string cnicExpiryDate { get; set; }

        public string gender { get; set; }

        public string maritalStatus { get; set; }

        public string religion { get; set; }
        public string CustomerOccupation { get; set; }

        public string kinName { get; set; }

        public string kinCnic { get; set; }

        public string kinMobile { get; set; }

        public string kinRelation { get; set; }

        public string preferedCity { get; set; }

        public string preferedBranch { get; set; }

        public string? referalCode { get; set; }

        public string MonthlyDebitTurnover { get; set; }

        public string MonthlyCreditTurnover { get; set; }

        public string ExpectedModeOfTransaction { get; set; }

        public string MonthlyIncome { get; set; }

        public string PresentCountry { get; set; }

        public string PresentAddress { get; set; }

        public string CNICFront { get; set; }

        public string CNICBack { get; set; }

        public string PaySlip { get; set; }

        public string ImageData { get; set; }
        public async Task OnGetAsync()
        {

            ViewData["ActivePage"] = "VerifyEnteredData";
            var CustomerID = HttpContext.Session.GetInt32("SelectedCustomerID");
            var customer = await _dbContext.Customer.FindAsync(CustomerID.Value);
            decryptedCnic = CommonFunctions.EncryptionHelper.Decrypt(customer.Cnic);
            PhoneNumber = customer.PhoneNumber;
            Email = customer.Email;
            var customerFurtherInfo = await _dbContext.CustomerFurtherInfo.Where(cf => cf.CustomerID == CustomerID).FirstOrDefaultAsync();
            if (customerFurtherInfo.TaxResidentAnotherCountry == true)
                TaxResidentAnotherCountry = "Yes";
            else TaxResidentAnotherCountry = "NO";
            if (customerFurtherInfo.OtherNationalities == true)
                OtherNationalities = "Yes";
            else OtherNationalities = "NO";
            //if(customerFurtherInfo.OtherNationalities==true)
            //add the nationalities and show them in razor page



            MotherName = customerFurtherInfo.MotherName;
            PlaceOfBirth = customerFurtherInfo.PlaceOfBirth;
            if (customerFurtherInfo.IsUSAResident == true)
                IsUSAResident = "Yes";
            else IsUSAResident = "NO";
            if (customerFurtherInfo.IsUSACitizen == true)
                IsUSACitizen = "Yes";
            else IsUSACitizen = "NO";
            if (customerFurtherInfo.IsUSALinks == true)
                IsUSALinks = "Yes";
            else IsUSALinks = "NO";
            if (customerFurtherInfo.IsUSAMandate == true)
                IsUSAMandate = "Yes";
            else IsUSAMandate = "NO";
            int? bankingtypeid = customerFurtherInfo.BankingTypeID;
            BankingType = await _dbContext.DefinedBankingType.Where(bt => bt.BankingTypeID == bankingtypeid).Select(bt => bt.BankingTypeName).FirstOrDefaultAsync();

            int? accounttypeid = customerFurtherInfo.AccountTypeID;
            AccountType = await _dbContext.DefinedAccountType.Where(at => at.AccountTypeID == accounttypeid).Select(at => at.AccountTypeName).FirstOrDefaultAsync();

            var customerpurpose = await _dbContext.CustomerPurpose.Where(cp => cp.CustomerID == CustomerID).FirstOrDefaultAsync();
            int customerpurposeid = customerpurpose.PurposeID;
            CustomerPurpose = await _dbContext.DefinedPurpose.Where(dp => dp.PurposeID == customerpurposeid).Select(cp => cp.PurposeName).FirstOrDefaultAsync();

            var customerOccupation = await _dbContext.CustomerOccupation.Where(co => co.CustomerID == CustomerID).FirstOrDefaultAsync();
            int customerOccupationId = customerOccupation.OccupationID;
            CustomerOccupation = await _dbContext.DefinedOccupation.Where(d => d.OccupationID == customerOccupationId).Select(c => c.OccupationName).FirstOrDefaultAsync();

            var customerPersonalInfo = await _dbContext.CustomerPersonalInfo.Where(p => p.CustomerID == CustomerID).FirstOrDefaultAsync();
            name = customerPersonalInfo.CustomerName;
            fatherName = customerPersonalInfo.CustomerFatherName;
            dob = customerPersonalInfo.CustomerDOB;
            cityOfBirth = customerPersonalInfo.CustomerPlaceOfBirth;
            cnicIssuenceDate = customerPersonalInfo.CustomerCnicIssuenceDate;
            cnicExpiryDate = customerPersonalInfo.CustomerCnicExpiryDate;
            gender = customerPersonalInfo.CustomerGender;
            maritalStatus = customerPersonalInfo.CustomerMaritalStatus;
            religion = customerPersonalInfo.CustomerRelegion;

            var customerNextOfKinInfo = await _dbContext.CustomerNextOfKinInfo.Where(c => c.CustomerID == CustomerID).FirstOrDefaultAsync();
            kinName = customerNextOfKinInfo.CustomerKinName;
            kinCnic = customerNextOfKinInfo.CustomerKinCnic;
            kinMobile = customerNextOfKinInfo.CustomerKinMobile;
            kinRelation = customerNextOfKinInfo.CustomerKinRelation;

            var customerPreferences = await _dbContext.CustomerPreferences.Where(c => c.CustomerID == CustomerID).FirstOrDefaultAsync();
            preferedCity = customerPreferences.CustomerPreferedCity;
            preferedBranch = customerPreferences.CustomerPreferedBranch;
            referalCode = customerPreferences.CustomerReferalCode;

            var customerZakatExemption = await _dbContext.CustomerZakatExemption.Where(c => c.CustomerID == CustomerID).FirstOrDefaultAsync();
            MonthlyDebitTurnover = customerZakatExemption.CustomerMonthlyDebitTurnOver;
            MonthlyCreditTurnover = customerZakatExemption.CustomerMonthlyCreditTurnOver;
            ExpectedModeOfTransaction = customerZakatExemption.CustomerExpectedModeOfTransaction;
            MonthlyIncome = customerZakatExemption.CustomerMonthlyIncome;

            var customerMailingAddress = await _dbContext.CustomerMailingAddress.Where(c => c.CustomerID == CustomerID).FirstOrDefaultAsync();
            PresentCountry = customerMailingAddress.CustomerPresentCountry;
            PresentAddress = customerMailingAddress.CustomerPresentAddress;

            var customerDocuments = await _dbContext.CustomerUploadDocuments.Where(c => c.CustomerID == CustomerID).FirstOrDefaultAsync();
            CNICFront = Convert.ToBase64String(customerDocuments.CustomerCNICFront);
            CNICBack = Convert.ToBase64String(customerDocuments.CustomerCNICBack);
            PaySlip = Convert.ToBase64String(customerDocuments.CustomerPaySlip);

            var customerPhoto = await _dbContext.CustomerImage.Where(c => c.CustomerID == CustomerID).FirstOrDefaultAsync();
            ImageData = Convert.ToBase64String(customerPhoto.CustomerImageData);


        }

        public async Task<IActionResult> OnPostAsync()
        {
            var CustomerID = HttpContext.Session.GetInt32("SelectedCustomerID");
            var customer = await _dbContext.Customer.FindAsync(CustomerID.Value);
            customer.IsForwarded = true;
            await _dbContext.SaveChangesAsync();
            return RedirectToPage("ViewCustomersList");
        }
        
    }
}
