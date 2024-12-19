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

            // Calculate the monthly values and round to two decimal places
            decimal grossMonthlySalary = Math.Round(salary.GrossSalary / 12, 2);
            decimal netMonthlySalary = Math.Round(netSalary / 12, 2);
            decimal monthlyTaxPaid = Math.Round(totalTax / 12, 2);

            // Round the annual values to two decimal places
            decimal roundedGrossSalary = Math.Round(salary.GrossSalary, 2);
            decimal roundedNetSalary = Math.Round(netSalary, 2);
            decimal roundedTotalTax = Math.Round(totalTax, 2);

            // Return the tax calculation results with all values rounded to two decimal places
            return new TaxCalculationResultDto
            {
                GrossAnnualSalary = roundedGrossSalary,
                GrossMonthlySalary = grossMonthlySalary,
                NetAnnualSalary = roundedNetSalary,
                NetMonthlySalary = netMonthlySalary,
                AnnualTaxPaid = roundedTotalTax,
                MonthlyTaxPaid = monthlyTaxPaid
            };
        }
    }
}
