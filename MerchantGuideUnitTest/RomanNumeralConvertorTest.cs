using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantGuideToGalaxy;
using MerchantGuideToGalaxy.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace MerchantGuideUnitTest
{
    [TestClass]
    public class RomanNumeralConvertorTest
    {
        private RomanNumeralConvertor convertor;

        [TestInitialize]
        public void SetUp()
        {
            convertor = ObjectFactory.GetInstance<RomanNumeralConvertor>();
        }

        [TestMethod]
        public void ShouldConvertRomanNumeralTest()
        {
            var convert = convertor.Convert(new RomanNumeral { Value = "GLOB GLOB" });
            Assert.AreEqual(2, convert.Value);
        }

        [ExpectedException(typeof(InvalidRomanNumeralException), "Invalid Roman Numeral")]
        [TestMethod]
        public void ShouldCheckInvalidRomanNumeralTest()
        {
            convertor.Convert(new RomanNumeral { Value = "PROO" });
        }
    }
}
