using SIP.Entities;
using SIP.Entities.Enums;

namespace SIP.Business.Services
{
    public class GetDeductionRates : IGetDeductionRates
    { 

        public decimal GetDeductionRate(EntityTypes entityType)
        {
            if(entityType == EntityTypes.Employee)
            {
                return Constants.Constants.COST_OF_EMP_BENEFITS_YEARLY;
            }
            else if(entityType == EntityTypes.Spouse || entityType == EntityTypes.Child)
            {
                return Constants.Constants.COST_OF_DEP_BENEFITS_YEARLY;
            }
            else
            {
                return 0m;
            }
        }
    }
}
