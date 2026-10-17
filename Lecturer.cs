
using System;

namespace LabW06.Models
{
    public class Lecturer : IBorrower
    {
        public string BorrowerId { get; }
        public string FullName { get; }

        public Lecturer(string borrowerId, string fullName)
        {
            if (string.IsNullOrWhiteSpace(borrowerId))
                throw new ArgumentException("Ma giang vien khong duoc rong.");

            if (string.IsNullOrWhiteSpace(fullName))
                throw new ArgumentException("Ho ten khong duoc rong.");

            BorrowerId = borrowerId;
            FullName = fullName;
        }

        public int GetMaximumDevices()
        {
            return 3;
        }

        public override string ToString()
        {
            return $"Giang vien: {FullName} ({BorrowerId})";
        }
    }
}
