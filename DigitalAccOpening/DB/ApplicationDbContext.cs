using Microsoft.EntityFrameworkCore;

namespace DigitalAccOpening.DB
{
    public class ApplicationDbContext:DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<DB.ParameterizedDBTableClasses.Nationality> DefinedNationalities { get; set; }
        public DbSet<DB.ParameterizedDBTableClasses.Purpose> DefinedPurpose { get; set; }
        public DbSet<DBTableClasses.Customer> Customer { get; set; }
        public DbSet<DBTableClasses.CustomerFurtherInfo> CustomerFurtherInfo { get; set; }
        public DbSet<DBTableClasses.CustomerNationalities> CustomerNationalities { get; set; }
        public DbSet<DBTableClasses.CustomerPurpose> CustomerPurpose { get; set; }

        public DbSet<DBTableClasses.CustomerNatureOfEmployement> CustomerNatureOfEmployement { get; set; }
        public DbSet<DBTableClasses.CustomerEmployementSector> CustomerEmployementSector { get; set; }
        public DbSet<DBTableClasses.CustomerPersonalInfo> CustomerPersonalInfo { get; set; }

        public DbSet<DBTableClasses.CustomerNextOfKinInfo> CustomerNextOfKinInfo { get; set; }

        public DbSet<DBTableClasses.CustomerPreferences> CustomerPreferences { get; set; }
        public DbSet<DBTableClasses.CustomerZakatExemption> CustomerZakatExemption { get; set; }
        public DbSet<DBTableClasses.CustomerMailingAddress> CustomerMailingAddress { get; set; }
        public DbSet<DBTableClasses.CustomerUploadDocuments> CustomerUploadDocuments { get; set; }
        public DbSet<DBTableClasses.CustomerImage> CustomerImage { get; set; }
        public DbSet<DB.ParameterizedDBTableClasses.SourceOfFunds> DefinedSourcesOfFunds { get; set; }
        
        public DbSet<DB.ParameterizedDBTableClasses.NatureOfEmployement> DefinedNatureOFEmployement { get; set; }   
        public DbSet<DB.ParameterizedDBTableClasses.EmployementSector> DefinedEmployementSector { get; set; }
        public DbSet<DB.ParameterizedDBTableClasses.PensionerType> DefinedPensionerType { get; set; }   
        public DbSet<DB.ParameterizedDBTableClasses.StudentSourceOfFunds> DefinedStudentSourceOfFunds { get; set; }
        public DbSet<DB.ParameterizedDBTableClasses.Occupation> DefinedOccupation { get; set; }

        public DbSet<DB.ParameterizedDBTableClasses.BankingType> DefinedBankingType { get; set; }
        public DbSet<DB.ParameterizedDBTableClasses.AccountType> DefinedAccountType { get; set; }
        public DbSet<DB.DBTableClasses.CustomerOccupation> CustomerOccupation { get; set; }

        public DbSet<DB.BackOfficeDB.BackOfficeLoginDetails> BackOfficeLoginDetails { get; set; }
    }
}
