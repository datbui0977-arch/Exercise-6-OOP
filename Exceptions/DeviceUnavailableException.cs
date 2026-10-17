
using LabW06.Models;

namespace LabW06.Exceptions
{
    public class DeviceUnavailableException : BorrowingException
    {
        public string DeviceId { get; }
        public DeviceStatus CurrentStatus { get; }

        public DeviceUnavailableException(
            string deviceId,
            DeviceStatus currentStatus)
            : base($"Thiet bi {deviceId} khong san sang. Trang thai: {currentStatus}")
        {
            DeviceId = deviceId;
            CurrentStatus = currentStatus;
        }
    }
}
