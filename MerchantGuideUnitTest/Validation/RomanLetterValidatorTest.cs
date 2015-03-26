using MerchantGuideToGalaxy;
using MerchantGuideToGalaxy.Exceptions;
using MerchantGuideToGalaxy.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace MerchantGuideUnitTest.Validation
{
    [TestClass]
    public class RomanLetterValidatorTest
    {
        private RomanLetterValidator romanLetterValidator;

        [TestInitialize]
        public void SetUp()
        {
            romanLetterValidator = ObjectFactory.GetInstance<RomanLetterValidator>();
        }

        [ExpectedException(typeof(InvalidRomanNumeralException), RomanMap.NoIdeaMessage)]
        [TestMethod]
        public void ShouldValidateInvalidRomanNumeral()
        {
            romanLetterValidator.Validate("hi");
        }

        [ExpectedException(typeof(InvalidRomanNumeralException), "Roman numerals is repeated more than 3 times")]
        [TestMethod]
        public void ShouldValidateRepeatedRomanNumeral()
        {
            romanLetterValidator.Validate("glob glob glob glob");
        }

        [ExpectedException(typeof(InvalidRomanNumeralException), "'D' , 'PROK' , 'TEGJ' can never be repeated")]
        [TestMethod]
        public void ShouldValidateNonRepeatedRomanNumeral()
        {
            romanLetterValidator.Validate("prok prok");
        }

        [ExpectedException(typeof(InvalidRomanNumeralException), "PROK and PISH cannot be subtracted from GLOB")]
        [TestMethod]
        public void ShouldValidateInvalidSubtractionRomanNumeral()
        {
            romanLetterValidator.Validate("prok glob");
        }
    }
}
