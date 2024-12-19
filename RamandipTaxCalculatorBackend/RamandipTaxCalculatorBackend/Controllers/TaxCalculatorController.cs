using RamandipTaxCalculatorBackend.Services;
using RamandipTaxCalculatorBackend.Models;
using Microsoft.AspNetCore.Mvc;

namespace RamandipTaxCalculatorBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ITaxCalculationService _taxCalculationService;

        // Constructor injection of the service
        public TaxCalculatorController(ITaxCalculationService taxCalculationService) => _taxCalculationService = taxCalculationService;

        [HttpPost("calculate")]
        public ActionResult<TaxCalculationResultDto> CalculateTax([FromBody] Salary salary)
        {
            // The service will handle the calculation, and the controller returns the result
            var result = _taxCalculationService.CalculateTax(salary);

            // Return the DTO containing the tax calculation result
            return Ok(result);
        }
    }
}
