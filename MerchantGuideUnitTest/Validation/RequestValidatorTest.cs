using MerchantGuideToGalaxy.Exceptions;
using MerchantGuideToGalaxy.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StructureMap;

namespace MerchantGuideUnitTest.Validation
{
    [TestClass]
    public class RequestValidatorTest
    {
        private RequestValidator validator;

        [TestInitialize]
        public void SetUp()
        {
            validator = ObjectFactory.GetInstance<RequestValidator>();
        }

        [ExpectedException(typeof(InvalidRequestException))]
        [TestMethod]
        public void ShouldValidateInvalidRequest()
        {

            validator.Validate(string.Empty);
        }

    }
}
