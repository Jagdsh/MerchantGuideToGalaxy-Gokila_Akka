using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MerchantGuideToGalaxy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MerchantGuideUnitTest
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void UnitOperatorTest()
        {
            var unit1 = new Unit { Value = 2 };
            var unit2 = new Unit { Value = 2 };
            Assert.AreEqual(4, unit1.Value * unit2.Value);
        }
    }
}
