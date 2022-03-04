using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SIP.Business.Services;
using SIP.Entities;
using SIP.Entities.Enums;

namespace SIP.Business.Tests
{
    [TestClass]
    public class GetCalculationsTests
    {
        private GetCalculations _getCalculations;

        [TestInitialize]
        public void Initialize()
        {
            var getDeductionRates = new GetDeductionRates();
            var getD = new ApplyDiscounts();
            _getCalculations = new GetCalculations(getDeductionRates, getD);
        }


        [TestMethod]
        public void TestGetEmployeePayCheckDeductionsWithOutDiscount()
        {
            // Arrange
            var employee = new Employee();
            employee.FirstName = "TestFirst Name";
            employee.LastName = "TestLast Name";
            employee.Type = EntityTypes.Employee;
            var expectedValue = Decimal.Round(Constants.COST_OF_EMP_BENEFITS_YEARLY / Constants.NUMBER_OF_PAYCHECKS, 2);

            // Act
            var actualValue = _getCalculations.GetEmployeePayCheckDeductions(employee);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void TestGetEmployeePayCheckDeductionsWithDiscount()
        {
            // Arrange
            var employee = new Employee();
            employee.FirstName = "TestFirst Name";
            employee.LastName = "ATestLast Name";
            employee.Type = EntityTypes.Employee;
            var expectedValue = Decimal.Round((Constants.COST_OF_EMP_BENEFITS_YEARLY - (Constants.COST_OF_EMP_BENEFITS_YEARLY * Constants.DISCOUNT_NAME_A)) / Constants.NUMBER_OF_PAYCHECKS, 2);

            // Act
            var actualValue = _getCalculations.GetEmployeePayCheckDeductions(employee);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void TestGetEmployeeYearlyDeductions()
        {
            // Arrange
            var employee = new Employee();
            employee.FirstName = "TestFirst Name";
            employee.LastName = "TestLast Name";
            employee.Type = EntityTypes.Employee;
            var expectedValue = Constants.COST_OF_EMP_BENEFITS_YEARLY;

            // Act
            var actualValue = _getCalculations.GetEmployeeYearlyDeductions(employee);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }


        [TestMethod]
        public void TestGetDependentPayCheckDeductions()
        {
            // Arrange
            var dependent = new Dependent();
            dependent.FirstName = "TestFirst Name";
            dependent.LastName = "TestLast Name";
            dependent.Type = EntityTypes.Spouse;
            var dependents = new List<Dependent> { dependent };
            var expectedValue = Decimal.Round(Constants.COST_OF_DEP_BENEFITS_YEARLY / Constants.NUMBER_OF_PAYCHECKS, 2);

            // Act
            var actualValue = _getCalculations.GetDependentPayCheckDeductions(dependents);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void TestGetDependentYearlyPayCheckDeductions()
        {
            // Arrange
            var dependent = new Dependent();
            dependent.FirstName = "TestFirst Name";
            dependent.LastName = "TestLast Name";
            dependent.Type = EntityTypes.Spouse;
            var dependents = new List<Dependent> { dependent };

            var expectedValue = Constants.COST_OF_DEP_BENEFITS_YEARLY;

            // Act
            var actualValue = _getCalculations.GetDependentYearlyPayCheckDeductions(dependents);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void TestGetYearlyDeductions()
        {
            // Arrange
            var employee = new Employee();
            employee.FirstName = "TestFirst Name";
            employee.LastName = "TestLast Name";
            employee.Type = EntityTypes.Employee; 

            var expectedValue = Constants.COST_OF_EMP_BENEFITS_YEARLY;

            // Act
            var actualValue = _getCalculations.GetYearlyDeductions(employee);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }

        [TestMethod]
        public void TestGetPaycheckAfterDeductions()
        {
            // Arrange
            var expectedValue = Constants.EMPLOYEE_SALARY - Constants.COST_OF_EMP_BENEFITS_YEARLY;

            // Act
            var actualValue = _getCalculations.GetPaycheckAfterDeductions(Constants.COST_OF_EMP_BENEFITS_YEARLY);

            // Assert
            Assert.IsTrue(expectedValue == actualValue);
        }
    }
}
