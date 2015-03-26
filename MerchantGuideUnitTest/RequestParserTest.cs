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
    public class RequestParserTest
    {
        private RequestParser parser;

        [TestInitialize]
        public void SetUp()
        {
            parser = ObjectFactory.GetInstance<RequestParser>();
        }

        [TestMethod]
        public void ShouldGetValidRequest()
        {
            var purchaseRequest = parser.Parse("HOW MUCH IS GLOB GLOB SILVER ?");
            Assert.AreEqual(true, purchaseRequest.IsValid);
        }

        [ExpectedException(typeof(InvalidRomanNumeralException))]
        [TestMethod]
        public void ShouldGetInValidRequest()
        {
            var purchaseRequest = parser.Parse("hello");
            Assert.AreEqual(false, purchaseRequest.IsValid);
        }
    }
}
