using System;

namespace MerchantGuideToGalaxy.Exceptions
{
    public class InvalidRomanNumeralException : Exception
    {
        public InvalidRomanNumeralException(string message)
            : base(message)
        {
        }
    }
}