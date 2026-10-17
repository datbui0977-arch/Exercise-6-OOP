
namespace LabW06.Models
{
    public class ProjectorRemote : TeachingDevice
    {
        public ProjectorRemote(
            string deviceId,
            string name,
            int yearIntroduced,
            decimal purchasePrice)
            : base(deviceId, name, yearIntroduced,
                   purchasePrice, 2, 12000m)
        {
        }

        public override decimal CalculateAnnualMaintenanceCost()
        {
            return PurchasePrice * 0.06m;
        }
    }
}
