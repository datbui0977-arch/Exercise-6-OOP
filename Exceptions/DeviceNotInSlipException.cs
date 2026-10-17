
namespace LabW06.Exceptions
{
    public class DeviceNotInSlipException : BorrowingException
    {
        public string DeviceId { get; }

        public DeviceNotInSlipException(string deviceId)
            : base($"Thiet bi {deviceId} khong thuoc phieu muon.")
        {
            DeviceId = deviceId;
        }
    }
}
