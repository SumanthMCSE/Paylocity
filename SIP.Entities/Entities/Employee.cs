using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIP.Entities
{
    public class Employee : Person
    {
        public List<Dependent> Dependents { get; set; }
    }
}
