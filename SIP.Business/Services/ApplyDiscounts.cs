using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIP.Entities;

namespace SIP.Business.Services
{
    public class ApplyDiscounts : IApplyDiscounts
    {
        public decimal ApplyApplicableDiscounts(Person person, decimal costs)
        {
            if ((person?.FirstName?.ToLower()?.StartsWith("a") ?? false) || (person?.LastName?.ToLower()?.StartsWith("a") ?? false))
            {
                costs -= (costs * Constants.DISCOUNT_NAME_A);
            }

            return costs;
        }

    }
}
