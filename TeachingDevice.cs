
namespace LabW06.Models
{
    public abstract class TeachingDevice : Device
    {
        public int MaximumBorrowDays { get; }
        public decimal LateFeePerDay { get; }

        protected TeachingDevice(
            string deviceId,
            string name,
            int yearIntroduced,
            decimal purchasePrice,
            int maximumBorrowDays,
            decimal lateFeePerDay)
            : base(deviceId, name, yearIntroduced, purchasePrice)
        {
            if (maximumBorrowDays <= 0)
                throw new System.ArgumentException(
                    "So ngay muon toi da phai lon hon 0.");

            if (lateFeePerDay < 0)
                throw new System.ArgumentException(
                    "Phi tre han khong duoc am.");

            MaximumBorrowDays = maximumBorrowDays;
            LateFeePerDay = lateFeePerDay;
        }
    }
}
