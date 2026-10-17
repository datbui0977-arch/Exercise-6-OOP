
using System;
using LabW06.Exceptions;

namespace LabW06.Models
{
    public class BorrowItem
    {
        public TeachingDevice Device { get; }
        public DateTime BorrowedDate { get; }
        public DateTime DueDate { get; }

        public DateTime? ReturnedDate { get; private set; }

        public int FromPeriod { get; }
        public int ToPeriod { get; }

        public bool IsReturned => ReturnedDate.HasValue;

        public BorrowItem(
            TeachingDevice device,
            DateTime borrowedDate,
            DateTime dueDate,
            int fromPeriod = 1,
            int toPeriod = 1)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            if (dueDate.Date < borrowedDate.Date)
                throw new ArgumentException(
                    "Han tra khong duoc truoc ngay muon.");

            if (fromPeriod <= 0 ||
                toPeriod < fromPeriod)
                throw new ArgumentException(
                    "Khoang tiet muon khong hop le.");

            Device = device;
            BorrowedDate = borrowedDate;
            DueDate = dueDate;
            FromPeriod = fromPeriod;
            ToPeriod = toPeriod;
            ReturnedDate = null;
        }

        public void Return(DateTime returnedDate)
        {
            if (IsReturned)
                throw new DeviceAlreadyReturnedException(Device.DeviceId);

            if (returnedDate.Date < BorrowedDate.Date)
                throw new ArgumentException(
                    "Ngay tra khong duoc truoc ngay muon.");

            ReturnedDate = returnedDate;
        }

        public int CalculateLateDays()
        {
            if (!IsReturned)
                return 0;

            int lateDays =
                (ReturnedDate!.Value.Date - DueDate.Date).Days;

            return Math.Max(0, lateDays);
        }

        public decimal CalculateLateFee()
        {
            return CalculateLateDays() * Device.LateFeePerDay;
        }
    }
}

