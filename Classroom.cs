
using System;
using System.Collections.Generic;
using System.Linq;

namespace LabW06.Models
{
    public class ClassRoom
    {
        private readonly List<Device> devices =
            new List<Device>();

        public string RoomId { get; }
        public string RoomName { get; set; }
        public int Capacity { get; }

        public IReadOnlyList<Device> Devices =>
            devices.AsReadOnly();

        public ClassRoom(
            string roomId,
            string roomName,
            int capacity)
        {
            if (string.IsNullOrWhiteSpace(roomId))
                throw new ArgumentException("Ma phong khong hop le.");

            if (string.IsNullOrWhiteSpace(roomName))
                throw new ArgumentException("Ten phong khong hop le.");

            if (capacity <= 0)
                throw new ArgumentException("Suc chua phai lon hon 0.");

            RoomId = roomId;
            RoomName = roomName;
            Capacity = capacity;
        }

        public void AddDevice(Device device)
        {
            if (device == null)
                throw new ArgumentNullException(nameof(device));

            if (devices.Any(d => d.DeviceId == device.DeviceId))
                throw new ArgumentException(
                    "Phong da co thiet bi voi ma nay.");

            devices.Add(device);
        }

        public bool RemoveDevice(string deviceId)
        {
            Device device = FindDevice(deviceId);

            if (device == null)
                return false;

            devices.Remove(device);
            return true;
        }

        public Device FindDevice(string deviceId)
        {
            return devices.FirstOrDefault(
                d => d.DeviceId == deviceId);
        }

        public decimal CalculateAnnualMaintenanceCost()
        {
            return devices.Sum(
                device => device.CalculateAnnualMaintenanceCost());
        }

        public List<Device> GetDevicesRequiringMaintenance()
        {
            int currentYear = DateTime.Now.Year;

            return devices
                .Where(device =>
                    device.Status == DeviceStatus.UnderMaintenance
                    || currentYear - device.YearIntroduced > 5)
                .ToList();
        }
    }
}
