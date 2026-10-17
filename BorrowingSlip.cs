
using System;
using System.Collections.Generic;
using System.Linq;
using LabW06.Exceptions;

namespace LabW06.Models
{
    public class BorrowingSlip
    {
        private readonly List<BorrowItem> items =
            new List<BorrowItem>();

        public string SlipId { get; }
        public IBorrower Borrower { get; }
        public string TeachingRoom { get; }
        public DateTime BorrowedDate { get; }

        public IReadOnlyList<BorrowItem> Items => items.AsReadOnly();

        public BorrowingSlip(
            string slipId,
            IBorrower borrower,
            string teachingRoom,
            DateTime borrowedDate)
        {
            if (string.IsNullOrWhiteSpace(slipId))
                throw new ArgumentException("Ma phieu khong duoc rong.");

            if (borrower == null)
                throw new ArgumentNullException(nameof(borrower));

            if (string.IsNullOrWhiteSpace(teachingRoom))
                throw new ArgumentException("Phong day khong hop le.");

            SlipId = slipId;
            Borrower = borrower;
            TeachingRoom = teachingRoom;
            BorrowedDate = borrowedDate;
        }

        public void AddDevice(
            TeachingDevice device,
            int borrowDays)
        {
            // 1. Kiem tra du lieu dau vao.
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            // 2. Kiem tra thoi han muon.
            if (borrowDays <= 0 ||
                borrowDays > device.MaximumBorrowDays)
            {
                throw new InvalidBorrowPeriodException(
                    device.DeviceId,
                    borrowDays,
                    device.MaximumBorrowDays);
            }

            // 3. Khong cho them trung thiet bi.
            if (items.Any(item =>
                item.Device.DeviceId == device.DeviceId))
            {
                throw new DuplicateDeviceException(
                    device.DeviceId);
            }

            // 4. Kiem tra gioi han nguoi muon.
            if (items.Count >= Borrower.GetMaximumDevices())
            {
                throw new BorrowLimitExceededException(
                    Borrower.BorrowerId,
                    Borrower.GetMaximumDevices());
            }

            // 5. Thiet bi phai san sang.
            if (device.Status != DeviceStatus.Available)
            {
                throw new DeviceUnavailableException(
                    device.DeviceId,
                    device.Status);
            }

            // Chi thay doi du lieu sau khi kiem tra thanh cong.
            BorrowItem item = new BorrowItem(
                device,
                BorrowedDate,
                BorrowedDate.AddDays(borrowDays));

            device.MarkAsBorrowed();
            items.Add(item);
        }

        public decimal ReturnDevice(
            string deviceId,
            DateTime returnedDate)
        {
            if (string.IsNullOrWhiteSpace(deviceId))
                throw new ArgumentException(
                    "Ma thiet bi khong duoc rong.");

            // Tim muc muon trong phieu.
            BorrowItem item = items.FirstOrDefault(
                x => x.Device.DeviceId == deviceId);

            if (item == null)
                throw new DeviceNotInSlipException(deviceId);

            if (item.IsReturned)
                throw new DeviceAlreadyReturnedException(deviceId);

            if (returnedDate.Date < item.BorrowedDate.Date)
                throw new ArgumentException(
                    "Ngay tra khong duoc truoc ngay muon.");

            // Ghi nhan tra va cap nhat trang thai.
            item.Return(returnedDate);
            item.Device.MarkAsAvailable();

            return item.CalculateLateFee();
        }

        public decimal CalculateTotalLateFee()
        {
            return items.Sum(item => item.CalculateLateFee());
        }

        public override string ToString()
        {
            return $"Phieu: {SlipId}, " +
                   $"Nguoi muon: {Borrower.FullName}, " +
                   $"Phong: {TeachingRoom}, " +
                   $"So thiet bi: {items.Count}";
        }
    }
}
