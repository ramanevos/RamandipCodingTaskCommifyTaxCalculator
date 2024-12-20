namespace RamandipTaxCalculatorBackend.Models
{
    public class TaxBand
    {
        public int Id { get; set; }
        public decimal LowerLimit { get; set; }
        public decimal UpperLimit { get; set; }
        public int TaxRate { get; set; }  
    }
}
