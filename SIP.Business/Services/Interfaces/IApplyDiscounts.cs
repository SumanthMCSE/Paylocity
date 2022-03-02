using SIP.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIP.Business.Services
{
    public interface IApplyDiscounts
    {
        /// <summary>
        /// Apply the discounts based on the person and costs 
        /// </summary>
        /// <param name="person"></param>
        /// <param name="costs"></param>
        /// <returns>Cost after applying costs</returns>
        decimal ApplyApplicableDiscounts(Person person, decimal costs);
    }
}
