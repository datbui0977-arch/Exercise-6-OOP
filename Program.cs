
using System;
using LabW06.Models;
using LabW06.Exceptions;

namespace LabW06
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding =
                System.Text.Encoding.UTF8;

            Console.WriteLine("=== HE THONG QUAN LY THIET BI ===");

            try
            {
                // 1. Tao nguoi muon.
                Lecturer lecturer = new Lecturer(
                    "GV01", "Nguyen Van An");

                TeachingAssistant assistant =
                    new TeachingAssistant(
                        "TG01", "Tran Thi Binh");

                // 2. Tao cac thiet bi.
                ProjectorRemote projector =
                    new ProjectorRemote(
                        "TB01", "Dieu khien may chieu",
                        2024, 500000m);

                Microphone microphone =
                    new Microphone(
                        "TB02", "Micro khong day",
                        2023, 800000m);

                AirConditionerRemote airRemote =
                    new AirConditionerRemote(
                        "TB03", "Dieu khien dieu hoa",
                        2020, 300000m);

                // 3. Tao phong va them thiet bi.
                ClassRoom room = new ClassRoom(
                    "P101", "Phong hoc 101", 60);

                room.AddDevice(projector);
                room.AddDevice(microphone);
                room.AddDevice(airRemote);

                Console.WriteLine("\n--- DANH SACH THIET BI ---");

                foreach (Device device in room.Devices)
                    Console.WriteLine(device);

                // 4. Tao phieu muon.
                DateTime borrowedDate = DateTime.Today;

                BorrowingSlip slip = new BorrowingSlip(
                    "PM01", lecturer, "P101", borrowedDate);

                // 5. Muon dieu khien may chieu va micro.
                slip.AddDevice(projector, 2);
                slip.AddDevice(microphone, 1);

                Console.WriteLine("\n--- PHIEU MUON ---");
                Console.WriteLine(slip);

                // 6. Tra dieu khien dung han.
                decimal fee1 = slip.ReturnDevice(
                    "TB01", borrowedDate.AddDays(2));

                Console.WriteLine(
                    $"Tien phat TB01: {fee1:N0} dong");

                // 7. Tra micro muon 2 ngay.
                decimal fee2 = slip.ReturnDevice(
                    "TB02", borrowedDate.AddDays(3));

                Console.WriteLine(
                    $"Tien phat TB02: {fee2:N0} dong");

                Console.WriteLine(
                    $"Tong tien phat: " +
                    $"{slip.CalculateTotalLateFee():N0} dong");

                // 8. Thu muon thiet bi dang bao tri.
                Console.WriteLine("\n--- KIEM THU NGOAI LE ---");

                airRemote.SetStatus(
                    DeviceStatus.UnderMaintenance);

                try
                {
                    slip.AddDevice(airRemote, 1);
                }
                catch (DeviceUnavailableException ex)
                {
                    Console.WriteLine(
                        $"Loi thiet bi: {ex.Message}");
                }

                // 9. Thu them trung micro.
                try
                {
                    slip.AddDevice(microphone, 1);
                }
                catch (DuplicateDeviceException ex)
                {
                    Console.WriteLine(
                        $"Loi trung thiet bi: {ex.Message}");
                }

                // 10. Thu tra thiet bi khong thuoc phieu.
                try
                {
                    slip.ReturnDevice(
                        "TB99", DateTime.Today);
                }
                catch (DeviceNotInSlipException ex)
                {
                    Console.WriteLine(
                        $"Loi tra thiet bi: {ex.Message}");
                }

                // 11. Thu tra micro lan hai.
                try
                {
                    slip.ReturnDevice(
                        "TB02", borrowedDate.AddDays(3));
                }
                catch (DeviceAlreadyReturnedException ex)
                {
                    Console.WriteLine(
                        $"Loi tra hai lan: {ex.Message}");
                }

                // 12. Thu gioi han cua tro giang.
                BorrowingSlip assistantSlip =
                    new BorrowingSlip(
                        "PM02", assistant, "P101",
                        borrowedDate);

                Microphone mic2 = new Microphone(
                    "TB04", "Micro du phong",
                    2025, 600000m);

                ProjectorRemote projector2 =
                    new ProjectorRemote(
                        "TB05", "Dieu khien du phong",
                        2025, 400000m);

                AirConditionerRemote remote2 =
                    new AirConditionerRemote(
                        "TB06", "Dieu khien dieu hoa 2",
                        2025, 250000m);

                assistantSlip.AddDevice(mic2, 1);
                assistantSlip.AddDevice(projector2, 1);

                try
                {
                    assistantSlip.AddDevice(remote2, 1);
                }
                catch (BorrowLimitExceededException ex)
                {
                    Console.WriteLine(
                        $"Loi vuot gioi han: {ex.Message}");
                }

                // 13. Thu thoi han muon vuot gioi han.
                try
                {
                    BorrowingSlip testSlip =
                        new BorrowingSlip(
                            "PM03", lecturer, "P101",
                            borrowedDate);

                    testSlip.AddDevice(microphone, 3);
                }
                catch (InvalidBorrowPeriodException ex)
                {
                    Console.WriteLine(
                        $"Loi thoi han: {ex.Message}");
                }

                // 14. Tinh chi phi bao tri.
                Console.WriteLine(
                    "\nChi phi bao tri nam: " +
                    $"{room.CalculateAnnualMaintenanceCost():N0} dong");

                Console.WriteLine(
                    "\n--- KET THUC KIEM THU ---");
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"Loi khong mong muon: {ex.Message}");
            }
            finally
            {
                Console.WriteLine(
                    "Chuong trinh da ket thuc.");
            }
        }
    }
}
