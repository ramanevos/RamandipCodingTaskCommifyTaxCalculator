using RamandipTaxCalculatorBackend.Controllers;
using RamandipTaxCalculatorBackend.Models;
using RamandipTaxCalculatorBackend.Services;
using Microsoft.AspNetCore.Mvc;
using Moq;
using FluentAssertions;

namespace RamandipTaxCalculatorBackend.Tests.Controllers
{
    public class TaxCalculatorControllerTests
    {
        private readonly Mock<ITaxCalculationService> _mockTaxCalculationService;
        private readonly TaxCalculatorController _controller;

        public TaxCalculatorControllerTests()
        {
            _mockTaxCalculationService = new Mock<ITaxCalculationService>();
            _controller = new TaxCalculatorController(_mockTaxCalculationService.Object);
        }
        [Fact]
        public void CalculateTax_ReturnsOkResult_WithTaxCalculationResultDto()
        {
            // Arrange
            var salary = new Salary { GrossSalary = 50000m };
            var taxCalculationResultDto = new TaxCalculationResultDto
            {
                GrossAnnualSalary = 50000m,
                GrossMonthlySalary = 4166.67m,
                NetAnnualSalary = 40000m,
                NetMonthlySalary = 3333.33m,
                AnnualTaxPaid = 10000m,
                MonthlyTaxPaid = 833.33m
            };

            _mockTaxCalculationService
                .Setup(service => service.CalculateTax(salary))
                .Returns(taxCalculationResultDto);

            // Act
            var result = _controller.CalculateTax(salary);

            // Assert
            var okResult = result.Result as OkObjectResult;
            okResult.Should().NotBeNull();  // Ensure the result is not null

            // Only proceed if okResult is not null
            if (okResult != null)
            {
                var actualValue = okResult.Value as TaxCalculationResultDto;
                actualValue.Should().BeEquivalentTo(taxCalculationResultDto);  // Check if the value matches the expected DTO
            }
        }


    }
}
