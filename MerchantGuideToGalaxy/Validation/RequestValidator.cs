using System;
using MerchantGuideToGalaxy.Exceptions;

namespace MerchantGuideToGalaxy.Validation
{
    public class RequestValidator : IValidator
    {
        public void Validate(string request)
        {
            if (string.IsNullOrEmpty(request))
                throw new InvalidRequestException("Request cannot be empty.");
        }
    }
}