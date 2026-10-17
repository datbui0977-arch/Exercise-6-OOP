
namespace LabW06.Exceptions
{
    public class InvalidBorrowPeriodException : BorrowingException
    {
        public string DeviceId { get; }
        public int RequestedDays { get; }
        public int MaximumDays { get; }

        public InvalidBorrowPeriodException(
            string deviceId,
            int requestedDays,
            int maximumDays)
            : base($"So ngay muon {requestedDays} khong hop le cho thiet bi {deviceId}. Gioi han: {maximumDays} ngay.")
        {
            DeviceId = deviceId;
            RequestedDays = requestedDays;
            MaximumDays = maximumDays;
        }
    }
}
