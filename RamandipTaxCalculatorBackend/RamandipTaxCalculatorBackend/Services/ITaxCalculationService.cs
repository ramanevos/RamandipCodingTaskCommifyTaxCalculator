using RamandipTaxCalculatorBackend.Models;

namespace RamandipTaxCalculatorBackend.Services
{
    public interface ITaxCalculationService
    {
        TaxCalculationResultDto CalculateTax(Salary grossSalary);
    }
}
