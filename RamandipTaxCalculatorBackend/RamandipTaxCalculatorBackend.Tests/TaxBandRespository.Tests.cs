using RamandipTaxCalculatorBackend.Models;
using RamandipTaxCalculatorBackend.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;
using RamandipTaxCalculatorBackend.Data;

namespace RamandipTaxCalculatorBackend.Tests
{
    public class TaxBandRepositoryTests
    {
        private readonly TaxDbContext _context;
        private readonly TaxBandRepository _repository;

        public TaxBandRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<TaxDbContext>()
                .UseInMemoryDatabase(databaseName: "TaxDb")
                .Options;

            _context = new TaxDbContext(options);

            _repository = new TaxBandRepository(_context);
        }

        [Fact]
        public void GetAllTaxBands_ShouldReturnOrderedTaxBands()
        {
            // Arrange
            var taxBands = new List<TaxBand>
            {
                new TaxBand { Id = 1, LowerLimit = 10000, UpperLimit = 20000, TaxRate = 20 },
                new TaxBand { Id = 2, LowerLimit = 0, UpperLimit = 5000, TaxRate = 0 },
                new TaxBand { Id = 3, LowerLimit = 20000, UpperLimit = 50000, TaxRate = 40 }
            };

            _context.TaxBands.AddRange(taxBands);
            _context.SaveChanges();

            // Act
            var result = _repository.GetAllTaxBands();

            // Assert
            result.Should().HaveCount(3);
            result.First().TaxRate.Should().Be(0); // Lower limit is 0
            result.Last().TaxRate.Should().Be(40); // Upper limit is 20000
        }
    }
}
