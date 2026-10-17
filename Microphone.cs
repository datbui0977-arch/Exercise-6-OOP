
namespace LabW06.Models
{
    public class Microphone : TeachingDevice
    {
        public Microphone(
            string deviceId,
            string name,
            int yearIntroduced,
            decimal purchasePrice)
            : base(deviceId, name, yearIntroduced,
                   purchasePrice, 1, 15000m)
        {
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.08m;
        }
    }
}
