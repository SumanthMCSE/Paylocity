using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIP.Business.Services;
using SIP.Entities;
using SIP.Entities.Enums;

namespace SIP.Business.Tests
{
    [TestClass]
    public class ApplyDiscountsTests
    {
        private ApplyDiscounts _applyDiscounts;

        [TestInitialize]
        public void Initialize()
        {
            _applyDiscounts = new ApplyDiscounts();
        }

        [TestMethod]
        public void ApplyApplicableDiscounts()
        {
            // Arrange
            var employee = new Employee();
            employee.FirstName = "TestFirst Name";
            employee.LastName = "TestLast Name";
            employee.Type = EntityTypes.Employee;

            var expectedValue = Constants.Constants.COST_OF_EMP_BENEFITS_YEARLY;

            // Act
            var actualValue = _applyDiscounts.ApplyApplicableDiscounts(employee, Constants.Constants.COST_OF_EMP_BENEFITS_YEARLY);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void ApplyApplicableDiscountsWithA()
        {
            // Arrange
            var dependent = new Dependent();
            dependent.FirstName = "Aron Name";
            dependent.LastName = "TestLast Name";
            dependent.Type = EntityTypes.Spouse;

            var expectedValue = Constants.Constants.COST_OF_EMP_BENEFITS_YEARLY - (Constants.Constants.COST_OF_EMP_BENEFITS_YEARLY * Constants.Constants.DISCOUNT_NAME_A);

            // Act
            var actualValue = _applyDiscounts.ApplyApplicableDiscounts(dependent, Constants.Constants.COST_OF_EMP_BENEFITS_YEARLY);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

    }
}
