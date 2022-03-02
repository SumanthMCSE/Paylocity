using SIP.Entities.Enums;

namespace SIP.Business.Services
{
    public interface IGetDeductionRates
    {
        /// <summary>
        /// Get rates based on the type of entity
        /// </summary>
        /// <param name="entityType"></param>
        /// <returns>Cost of the benefits for the type</returns>
        decimal GetDeductionRate(EntityTypes entityType);
    }
}
