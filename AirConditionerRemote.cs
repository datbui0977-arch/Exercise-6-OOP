
namespace LabW06.Models
{
    public class AirConditionerRemote : TeachingDevice
    {
        public AirConditionerRemote(
            string deviceId,
            string name,
            int yearIntroduced,
            decimal purchasePrice)
            : base(deviceId, name, yearIntroduced,
                   purchasePrice, 1, 10000m)
        {
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.05m;
        }
    }
}
