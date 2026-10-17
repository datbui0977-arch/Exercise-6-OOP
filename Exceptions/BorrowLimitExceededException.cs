
namespace LabW06.Exceptions
{
    public class BorrowLimitExceededException : BorrowingException
    {
        public string BorrowerId { get; }
        public int MaximumDevices { get; }

        public BorrowLimitExceededException(
            string borrowerId,
            int maximumDevices)
            : base($"Nguoi muon {borrowerId} chi duoc muon toi da {maximumDevices} thiet bi.")
        {
            BorrowerId = borrowerId;
            MaximumDevices = maximumDevices;
        }
    }
}
