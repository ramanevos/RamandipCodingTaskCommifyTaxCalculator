using Moq;
using RamandipTaxCalculatorBackend.Models;
using RamandipTaxCalculatorBackend.Repositories;
using FluentAssertions;
using RamandipTaxCalculatorBackend.Services;

namespace RamandipTaxCalculatorBackend.Tests.Services
{
    public class TaxCalculationServiceTests
    {
        private readonly Mock<ITaxBandRepository> _mockTaxBandRepository;
        private readonly TaxCalculationService _service;

        public TaxCalculationServiceTests()
        {
            _mockTaxBandRepository = new Mock<ITaxBandRepository>();
            _service = new TaxCalculationService(_mockTaxBandRepository.Object);
        }

        private List<TaxBand> TaxBands => [
                new TaxBand { Id = 1, LowerLimit = 0, UpperLimit = 5000, TaxRate = 0 },
                new TaxBand { Id = 2, LowerLimit = 5000, UpperLimit = 20000, TaxRate = 20 },
                new TaxBand { Id = 3, LowerLimit = 20000, UpperLimit = 50000, TaxRate = 40 }
            ];

        [Theory]
        [InlineData(4000, 0, 4000)]
        [InlineData(5000, 0, 5000)]
        [InlineData(12000, 1400, 10600)]
        [InlineData(20000, 3000, 17000)]
        [InlineData(30000, 7000, 23000)]
        public void CalculateTax_ShouldApplyCorrectTaxRateBasedOnSalary(int grossSalary, decimal expectedAnnualTaxPaid, decimal expectedNetAnnualSalary)
        {
            // Arrange
            var salary = new Salary { GrossSalary = grossSalary };
            _mockTaxBandRepository.Setup(r => r.GetAllTaxBands()).Returns(TaxBands);

            // Act
            var result = _service.CalculateTax(salary);

            // Assert
            result.AnnualTaxPaid.Should().Be(expectedAnnualTaxPaid);
            result.NetAnnualSalary.Should().Be(expectedNetAnnualSalary);
        }
    }
}
