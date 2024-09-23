using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;

namespace DigitalAccOpening.Pages.BackOffice
{
    public class LoginPageModel : PageModel
    {
        [BindProperty]
         public string enteredemail { get; set; }

        [BindProperty]
        public string enteredpassword { get; set; }

        public void OnGet()
        {
        }
        
        public IActionResult OnPost()
        {
            if(IsValidLoginAsync(enteredemail,enteredpassword)==true)
            {
                return RedirectToPage("ViewCustomersList");
            }
            return Page();
        }

        private  bool IsValidLoginAsync(string email, string password)
        {
            // Replace with your actual connection string
            string connectionString = "Server=MUHAMMAD-FAISAL\\SQLEXPRESS;Database=DigitalAccountOpeningSystem;Trusted_Connection=True;TrustServerCertificate=True;";

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT COUNT(1) FROM BackOfficeLoginDetails WHERE OfficeEmail = @Email AND OfficePassword = @Password";

                using (var command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Password", password);
                    int count = (int)command.ExecuteScalar();

                    return count > 0; // Returns true if a matching record is found
                }
            }
        }
    }
}
