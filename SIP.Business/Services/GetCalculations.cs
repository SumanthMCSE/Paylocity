using SIP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SIP.Business.Services
{
    public class GetCalculations : IGetCalculations
    {
        private readonly IGetDeductionRates _getDeductionRates;
        private readonly IApplyDiscounts _applyDiscounts;


        public GetCalculations(
            IGetDeductionRates getDeductionRates,
            IApplyDiscounts applyDiscounts
            )
        {
            _getDeductionRates = getDeductionRates;
            _applyDiscounts = applyDiscounts;
        }
        public decimal GetEmployeePayCheckDeductions(Employee person)
        {
            return decimal.Round(Decimal.Divide(GetEmployeeYearlyDeductions(person), Constants.Constants.NUMBER_OF_PAYCHECKS), 2);
        }

        public decimal GetEmployeeYearlyDeductions(Employee person)
        {
            return GetYearlyDeductions(person);
        }

        public decimal GetDependentPayCheckDeductions(List<Dependent> dependents)
        {
            return decimal.Round(Decimal.Divide(GetDependentYearlyPayCheckDeductions(dependents), Constants.Constants.NUMBER_OF_PAYCHECKS), 2);
        }

        public decimal GetDependentYearlyPayCheckDeductions(List<Dependent> dependents)
        {
            return dependents.Sum(x => GetYearlyDeductions(x));
        }

        public decimal GetYearlyDeductions(Person person)
        {
            return _applyDiscounts.ApplyApplicableDiscounts(person, _getDeductionRates.GetDeductionRate(person.Type));
        }

        public decimal GetFinalPayCheckDeductions(decimal perPayCheckDeduction, decimal perYearDeductions)
        {
            var calculatedTotalDeduction = perPayCheckDeduction * Constants.Constants.NUMBER_OF_PAYCHECKS;
            decimal result = default(decimal);

            if (calculatedTotalDeduction < perYearDeductions)
            {
                result = perPayCheckDeduction + (perYearDeductions - calculatedTotalDeduction);
            }
            else if (calculatedTotalDeduction > perYearDeductions)
            {
                result = perPayCheckDeduction - (calculatedTotalDeduction - perYearDeductions);
            }

            return result;
        }

        public decimal GetPaycheckAfterDeductions(decimal deductions)
        {
           return  Constants.Constants.EMPLOYEE_SALARY - deductions;
        }

        public decimal GetYearlyPaycheckAfterDeductions(decimal deductions)
        {
            return (Constants.Constants.EMPLOYEE_SALARY * Constants.Constants.NUMBER_OF_PAYCHECKS) - deductions;
        }
    }
}
