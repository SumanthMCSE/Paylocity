using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIP.Business.Services;
using SIP.Entities;
using SIP.Entities.Enums;

namespace SIP.Business.Tests
{
    [TestClass]
    public class GetDeductionRatesTests
    {
        private GetDeductionRates _getDeductionRates;

        [TestInitialize]
        public void Initialize()
        {
            _getDeductionRates = new GetDeductionRates();
        }

        [TestMethod]
        public void TestGetDeductionRateEmployee()
        {
            // Arrange
            var expectedValue = Constants.COST_OF_EMP_BENEFITS_YEARLY;

            // Act
            var actualValue = _getDeductionRates.GetDeductionRate(EntityTypes.Employee);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void TestGetDeductionRateDependent()
        {
            // Arrange
            var expectedValue = Constants.COST_OF_DEP_BENEFITS_YEARLY;

            // Act
            var actualValue = _getDeductionRates.GetDeductionRate(EntityTypes.Spouse);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }
    }
}
