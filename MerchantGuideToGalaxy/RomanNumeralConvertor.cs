using System;
using System.Collections.Generic;
using MerchantGuideToGalaxy.Exceptions;

namespace MerchantGuideToGalaxy
{
    public class RomanNumeralConvertor
    {
        private const char Separator = ' ';

        public Unit Convert(RomanNumeral romanNumeral)
        {
            var numerals = romanNumeral.Value.Split(Separator);
            var total = 0;
            var lastRomanValue = 0;
            foreach (var numeral in numerals)
            {
                if (!RomanMap.WordRomanMap.ContainsKey(numeral))
                    throw new InvalidRomanNumeralException(RomanMap.NoIdeaMessage);

                var roman = RomanMap.WordRomanMap[numeral];
                var romanValue = RomanMap.RomanNumeralMap[roman];
                total = (romanValue > lastRomanValue) ? romanValue - total : romanValue + total;

                lastRomanValue = romanValue;
            }
            return new Unit { Value = total };
        }
    }
}