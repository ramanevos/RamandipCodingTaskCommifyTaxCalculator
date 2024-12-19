using RamandipTaxCalculatorBackend.Models;
using RamandipTaxCalculatorBackend.Repositories;

namespace RamandipTaxCalculatorBackend.Services
{
    public class TaxCalculationService(ITaxBandRepository taxBandRepository) : ITaxCalculationService
    {
        private readonly ITaxBandRepository _taxBandRepository = taxBandRepository;

        public TaxCalculationResultDto CalculateTax(Salary salary)
        {
            var bands = _taxBandRepository.GetAllTaxBands();
            decimal totalTax = 0;

            // Calculate the total tax based on the salary and tax bands
            foreach (var band in bands)
            {
                if (salary.GrossSalary <= band.LowerLimit)
                    break;

                var taxableAmount = Math.Min(salary.GrossSalary, band.UpperLimit) - band.LowerLimit;
                totalTax += taxableAmount * band.TaxRate / 100;
            }

            // Calculate net salary by subtracting total tax from gross salary
            decimal netSalary = salary.GrossSalary - totalTax;

            // Calculate the monthly values
            decimal grossMonthlySalary = salary.GrossSalary / 12;
            decimal netMonthlySalary = netSalary / 12;
            decimal monthlyTaxPaid = totalTax / 12;

            // Return the tax calculation results with all values
            return new TaxCalculationResultDto
            {
                GrossAnnualSalary = salary.GrossSalary,
                GrossMonthlySalary = grossMonthlySalary,
                NetAnnualSalary = netSalary,
                NetMonthlySalary = netMonthlySalary,
                AnnualTaxPaid = totalTax,
                MonthlyTaxPaid = monthlyTaxPaid
            };
        }
    }
}
