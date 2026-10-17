
namespace LabW06.Exceptions
{
    public class DuplicateDeviceException : BorrowingException
    {
        public string DeviceId { get; }

        public DuplicateDeviceException(string deviceId)
            : base($"Thiet bi {deviceId} da co trong phieu muon.")
        {
            DeviceId = deviceId;
        }
    }
}
