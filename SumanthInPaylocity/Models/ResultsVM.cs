using System.ComponentModel.DataAnnotations;

namespace SumanthInPaylocity.Models
{
    public class ResultsVM
    {
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Totals")]
        public decimal TotalPayCheckDeductions { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalFinalPayCheckDeductions { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal TotalYearlyDeductions { get; set; }



        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Employee")]
        public decimal EmployeePayCheckDeductions { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal EmployeeFinalPayCheckDeductions { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal EmployeeYearlyDeductions { get; set; }



        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal DependentsYearlyDeductions { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Dependents")]
        public decimal DependentsPayCheckDeductions { get; set; }
        [DisplayFormat(DataFormatString = "{0:C2}")]
        public decimal DependentsFinalPayCheckDeductions { get; set; }



        [DisplayFormat(DataFormatString = "{0:C2}")]
        [Display(Name = "Pay Check After Deductions")]
        public decimal DeductedPayCheck { get; set; } 

        [DisplayFormat(DataFormatString = "{0:C2}")]

        [Display(Name = "Final Pay Check After Deductions")]
        public decimal DeductedFinalPayCheck { get; set; } 

        [DisplayFormat(DataFormatString = "{0:C2}")]

        [Display(Name = "Yearly Pay After Deductions")]
        public decimal DeductedYearlyPayCheck { get; set; }

    }
}