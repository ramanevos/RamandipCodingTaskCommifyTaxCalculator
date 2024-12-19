using RamandipTaxCalculatorBackend.Models;

namespace RamandipTaxCalculatorBackend.Repositories
{
    public interface ITaxBandRepository
    {
        List<TaxBand> GetAllTaxBands();
    }
}
