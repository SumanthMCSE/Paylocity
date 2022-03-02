using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SumanthInPaylocity.Models
{
    public class EmployeeVM : PersonVM
    {
        public EmployeeVM()
        {
            Dependents = new List<DependentVM>();
        }
        public List<DependentVM> Dependents { get; set; }
    }
}