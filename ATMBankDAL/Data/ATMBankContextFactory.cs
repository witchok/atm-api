using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace ATMBankDAL.Data
{
    public class ATMBankCotextFactory : IDesignTimeDbContextFactory<ATMBankContext>
    {
        public static readonly string CONNECTION_STRING = @"Data Source=EXTENSA\SQLEXPRESS;Initial Catalog=BankDB;" +
                "Integrated Security = True; App = EntityFramework;";

        public ATMBankContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ATMBankContext>();
            optionsBuilder.UseSqlServer(
            CONNECTION_STRING, options => options.EnableRetryOnFailure())
            .ConfigureWarnings(warnings => warnings.Throw(RelationalEventId.
           QueryClientEvaluationWarning));
            return new ATMBankContext(optionsBuilder.Options);
        }
    }
}
