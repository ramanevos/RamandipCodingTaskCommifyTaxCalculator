using RamandipTaxCalculatorBackend.Data;
using RamandipTaxCalculatorBackend.Models;

namespace RamandipTaxCalculatorBackend.Repositories
{
    public class TaxBandRepository(TaxDbContext context) : ITaxBandRepository
    {
        private readonly TaxDbContext _context = context;

        public List<TaxBand> GetAllTaxBands()
        {
            return _context.TaxBands.OrderBy(b => b.LowerLimit).ToList();
        }
    }
}
