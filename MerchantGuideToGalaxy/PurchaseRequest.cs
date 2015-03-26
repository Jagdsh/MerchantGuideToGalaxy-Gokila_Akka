using MerchantGuideToGalaxy.Commodities;

namespace MerchantGuideToGalaxy
{
    public class PurchaseRequest
    {
        public Commodity Commodity { get; set; }
        public RomanNumeral RomanNumeral { get; set; }
        public bool IsValid { get; set; }
        public string ValidationResult { get; set; }
    }
}