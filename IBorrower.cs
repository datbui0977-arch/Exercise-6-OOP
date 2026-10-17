
namespace LabW06.Models
{
    public interface IBorrower
    {
        string BorrowerId { get; }
        string FullName { get; }

        int GetMaximumDevices();
    }
}
