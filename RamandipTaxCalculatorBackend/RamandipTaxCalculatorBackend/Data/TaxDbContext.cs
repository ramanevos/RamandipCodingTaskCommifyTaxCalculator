using RamandipTaxCalculatorBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace RamandipTaxCalculatorBackend.Data
{
    public class TaxDbContext(DbContextOptions<TaxDbContext> options) : DbContext(options)
    {
        public DbSet<TaxBand> TaxBands { get; set; }
    }

}
