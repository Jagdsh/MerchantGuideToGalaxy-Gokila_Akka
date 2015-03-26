using System.Collections.Generic;

namespace MerchantGuideToGalaxy.Validation
{
    public class RequestValidationProviders
    {
        public List<IValidator> GetVadlidationRules()
        {
            return new List<IValidator>
            {
                new RomanLetterValidator(),
                };
        }
    }
}