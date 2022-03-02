using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SIP.Entities;
using SIP.Business.Constants;

namespace SIP.Business.Services
{
    public class ApplyDiscounts : IApplyDiscounts
    {
        public decimal ApplyApplicableDiscounts(Person person, decimal costs)
        {
            if ((person?.FirstName?.ToLower()?.StartsWith("a") ?? false) || (person?.LastName?.ToLower()?.StartsWith("a") ?? false))
            {
                costs -= (costs * Constants.Constants.DISCOUNT_NAME_A);
            }

            return costs;
        }

    }
}
