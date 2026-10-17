
using System;

namespace LabW06.Models
{
    public class TeachingAssistant : IBorrower
    {
        public string BorrowerId { get; }
        public string FullName { get; }

        public TeachingAssistant(string borrowerId, string fullName)
        {
            if (string.IsNullOrWhiteSpace(borrowerId))
                throw new ArgumentException("Ma tro giang khong duoc rong.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Ho ten khong duoc rong.");

            BorrowerId = borrowerId;
            FullName = fullName;
        }

        public int GetMaximumDevices()
        {
            return 2;
        }

        public override string ToString()
        {
            return $"Tro giang: {FullName} ({BorrowerId})";
        }
    }
}
