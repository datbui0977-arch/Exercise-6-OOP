
namespace LabW06.Exceptions
{
    public class DeviceAlreadyReturnedException : BorrowingException
    {
        public string DeviceId { get; }

        public DeviceAlreadyReturnedException(string deviceId)
            : base($"Thiet bi {deviceId} da duoc tra truoc do.")
        {
            DeviceId = deviceId;
        }
    }
}
