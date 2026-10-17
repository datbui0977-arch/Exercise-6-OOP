
using System;

namespace LabW06.Models
{
    public abstract class Device
    {
        public string DeviceId { get; }
        public string Name { get; set; }
        public int YearIntroduced { get; }
        public decimal PurchasePrice { get; }
        public DeviceStatus Status { get; private set; }

        protected Device(
            string deviceId,
            string name,
            int yearIntroduced,
            decimal purchasePrice)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException("Ma thiet bi khong duoc rong.");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Ten thiet bi khong duoc rong.");

            if (yearIntroduced > DateTime.Now.Year)
                throw new ArgumentException("Nam su dung khong hop le.");

            if (purchasePrice <= 0)
                throw new ArgumentException("Gia mua phai lon hon 0.");

            DeviceId = deviceId;
            Name = name;
            YearIntroduced = yearIntroduced;
            PurchasePrice = purchasePrice;
            Status = DeviceStatus.Available;
        }

        public abstract decimal CalculateAnnualMaintenanceCost();

        public void MarkAsBorrowed()
        {
            if (Status != DeviceStatus.Available)
                throw new InvalidOperationException(
                    "Thiet bi khong san sang cho muon.");

            Status = DeviceStatus.Borrowed;
        }

        public void MarkAsAvailable()
        {
            Status = DeviceStatus.Available;
        }

        public void SetStatus(DeviceStatus status)
        {
            Status = status;
        }

        public override string ToString()
        {
            return $"Ma: {DeviceId}, Ten: {Name}, " +
                   $"Nam: {YearIntroduced}, Gia: {PurchasePrice}, " +
                   $"Trang thai: {Status}";
        }
    }
}
