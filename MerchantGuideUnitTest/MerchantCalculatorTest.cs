using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantGuideToGalaxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace MerchantGuideUnitTest
{
    [TestClass]
    public class MerchantCalculatorTest
    {
        private MerchantCalculator merchantCalculator;

        [TestInitialize]
        public void SetUp()
        {
            merchantCalculator = ObjectFactory.GetInstance<MerchantCalculator>();
        }

        /*  how much is pish tegj glob glob ?
            how many Credits is glob prok Silver ?
            how many Credits is glob prok Gold ?
            how many Credits is glob prok Iron ?
            how much wood could a woodchuck chuck if a woodchuck could chuck wood ?
                     * 
                     * pish tegj glob glob is 42
            glob prok Silver is 68 Credits
            glob prok Gold is 57800 Credits
            glob prok Iron is 782 Credits
            I have no idea what you are talking about
        */


        [TestMethod]
        public void CalculateRomanNumeralTest()
        {
            var result = merchantCalculator.Calculate("how much is pish tegj glob glob ?");
            Assert.AreEqual(result, "PISH TEGJ GLOB GLOB is 42");
        }

        [TestMethod]
        public void CalculateSilverTest()
        {
            var result = merchantCalculator.Calculate("how many Credits is glob prok Silver ?");
            Assert.AreEqual(result, "GLOB PROK Silver is 68 Credits");
        }

        [TestMethod]
        public void CalculateGoldTest()
        {
            var result = merchantCalculator.Calculate("how many Credits is glob prok Gold ?");
            Assert.AreEqual(result, "GLOB PROK Gold is 57800 Credits");
        }

        [TestMethod]
        public void CalculateIronTest()
        {
            var result = merchantCalculator.Calculate("how many Credits is glob prok Iron ?");
            Assert.AreEqual(result, "GLOB PROK Iron is 782 Credits");
        }

        [TestMethod]
        public void CalculateInvalidDataTest()
        {
            var result = merchantCalculator.Calculate("how much wood could a woodchuck chuck if a woodchuck could chuck wood ?");
            Assert.AreEqual(result, RomanMap.NoIdeaMessage);
        }

    }
}
