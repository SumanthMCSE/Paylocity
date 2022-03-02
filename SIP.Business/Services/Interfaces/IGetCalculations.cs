using SIP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIP.Business.Services
{
    public interface IGetCalculations
    {
        /// <summary>
        /// Returns Deductions for an employee per pay check
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Benefits amount for each paycheck</returns>
        decimal GetEmployeePayCheckDeductions(Employee person);
        /// <summary>
        /// Returns Deductions for an employee for entire year
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Benefits amount for entire year</returns>
        decimal GetEmployeeYearlyDeductions(Employee person);
        /// <summary>
        /// Returns Deductions for a dependent per pay check
        /// </summary>
        /// <param name="dependents"></param>
        /// <returns>Benefits amount for the dependent for each paycheck</returns>
        decimal GetDependentPayCheckDeductions(List<Dependent> dependents);
        /// <summary>
        /// Returns Deductions for a dependent for entire year
        /// </summary>
        /// <param name="dependents"></param>
        /// <returns>Benefits amount for the dependent for entire year</returns>
        decimal GetDependentYearlyPayCheckDeductions(List<Dependent> dependents);
        /// <summary>
        /// Returns yearly Deductions for the person
        /// </summary>
        /// <param name="person"></param>
        /// <returns>Benefits amount after discounts based on the person type</returns>
        decimal GetYearlyDeductions(Person person);
        /// <summary>
        /// Returns Deductions for a final paycheck if exists and different from the rest of the paychecks 
        /// </summary>
        /// <param name="perPayCheckDeduction"></param>
        /// <param name="perYearDeductions"></param>
        /// <returns>Final paycheck amount if exists and is different than the regular amount</returns>
        decimal GetFinalPayCheckDeductions(decimal perPayCheckDeduction, decimal perYearDeductions);
        /// <summary>
        /// Returns a paycheck amount after all deductions 
        /// </summary>
        /// <param name="deductions"></param>
        /// <returns>Paycheck amount after deductions for all types</returns>
        decimal GetPaycheckAfterDeductions(decimal deductions);
        /// <summary>
        /// Returns a paycheck amount after all deductions for entire year
        /// </summary>
        /// <param name="deductions"></param>
        /// <returns>Paycheck amount after deductions for all types for entire year</returns>
        decimal GetYearlyPaycheckAfterDeductions(decimal deductions);
    }
}
