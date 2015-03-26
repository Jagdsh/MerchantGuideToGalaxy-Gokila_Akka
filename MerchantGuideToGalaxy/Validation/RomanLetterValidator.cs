using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using MerchantGuideToGalaxy.Exceptions;

namespace MerchantGuideToGalaxy.Validation
{
    public class RomanLetterValidator : IValidator
    {
        private const string repeatedRomansPattern = @"([A-Z])\1\1\1\1*";
        private const string noRepeatPattern = @"([D]{2,})|([V]{2,})|([L]{2,})";
        private const string subtractionPatternForVandX = @"(?<=V)(I)|(?<=X)(I)";
        private const string subtractionPatternForLandC = @"(?<=L)(X)|(?<=C)(X)";
        private const string subtractionPatternForDandM = @"(?<=D)(C)|(?<=M)(C)";

        public void Validate(string romanNumerals)
        {
            var romanValues = GetRomanValues(romanNumerals.Split(' '));

            if (Regex.IsMatch(romanValues, repeatedRomansPattern))
                throw new InvalidRomanNumeralException("Roman numerals is repeated more than 3 times");

            if (Regex.IsMatch(romanValues, noRepeatPattern))
                throw new InvalidRomanNumeralException(string.Format("{0} , {1} , {2} can never be repeated", 'D', RomanMap.RomanWordMap['V'], RomanMap.RomanWordMap['L']));

            if (Regex.IsMatch(romanValues, subtractionPatternForVandX))
                throw new InvalidRomanNumeralException(string.Format("{0} and {1} cannot be subtracted from {2}", RomanMap.RomanWordMap['V'], RomanMap.RomanWordMap['X'], RomanMap.RomanWordMap['I']));

            if (Regex.IsMatch(romanValues, subtractionPatternForLandC))
                throw new InvalidRomanNumeralException(string.Format("{0} and {1} cannot be subtracted from {2}", RomanMap.RomanWordMap['L'], 'C', RomanMap.RomanWordMap['X']));

            if (Regex.IsMatch(romanValues, subtractionPatternForDandM))
                throw new InvalidRomanNumeralException(string.Format("{0} and {1} cannot be subtracted from {2}", 'D', 'M', 'C'));
        }

        private string GetRomanValues(IEnumerable<string> romanNumerals)
        {
            var wordRomanMap = RomanMap.WordRomanMap;
            var result = string.Empty;
            foreach (var romanNumeral in romanNumerals)
            {
                if (!wordRomanMap.ContainsKey(romanNumeral))
                    throw new InvalidRomanNumeralException(RomanMap.NoIdeaMessage);

                result += wordRomanMap[romanNumeral];
            }
            return result;
        }
    }
}