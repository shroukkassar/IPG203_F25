using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203_F25.Models
{
    public class WashingMachine : Appliance
    {
        public WashingMachine(int deviceId, string deviceName, string modelNumber, string deviceStatus, DateTime receivedDate, string customerName, string customerNumber)
        : base(deviceId, deviceName, modelNumber, deviceStatus, receivedDate, customerName, customerNumber)
        {
        }

        public override void DeviceCheck()
        {
            Console.WriteLine($"Checking the status of Washing Machine: {DeviceName}, Model: {ModelNumber} ");
            bool areComponentsWorking = true; // متحول يعبر عن جميع قطع الغسالة

            if (areComponentsWorking)
            {
                Console.WriteLine("All components are working correctly.\n");
                DeviceStatus = "Sound"; // حالة الجهاز سليم
            }
            else
            {
                Console.WriteLine("Some components are not working correctly.");
                Console.WriteLine("For more details, please contact the company");
                DeviceStatus = "Not Sound"; // حالة الجهاز غير سليم
            }
        }

        public override void StartMaintenance()
        {
            Console.WriteLine($"Starting maintenance for Washing Machine: {DeviceName}, Model: {ModelNumber} ");
            DeviceStatus = "Under Maintenance"; // حالة الجهاز تحت الصيانة
        }

        public override void UpdateStatus()
        {
            Console.WriteLine($"\nUpdating final status for Washing Machine: {DeviceName}, Model: {ModelNumber}");
            DeviceStatus = "Fixed and Ready"; // حالة الجهاز بعد الفحص والإصلاح
            SendNotification("The washing machine has been fixed and is ready for use.");
        }

        public override double CalculateCost()
        {
            double baseCost = 200;      // التكلفة الخاصة بالغسالة (قطع غيار/محرك أو مضخة)
            double serviceFee = 80;     // أجور فحص وصيانة
            double totalCost = baseCost + serviceFee;

            Console.WriteLine($"\nCalculating cost for {DeviceName} -> Service: ${serviceFee}, Parts: ${baseCost}, Total: ${totalCost}");
            return totalCost;
        }
    }
}
