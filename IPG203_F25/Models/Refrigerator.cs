using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203_F25.Models
{
    public class Refrigerator : Appliance
    {
        public Refrigerator(int deviceId, string deviceName, string modelNumber, string deviceStatus, DateTime receivedDate, string customerName, string customerNumber)
        : base(deviceId, deviceName, modelNumber, deviceStatus, receivedDate, customerName, customerNumber)
        {
        }
        public override void DeviceCheck()
        {
        
        Console.WriteLine($"Checking the status of Refrigerator: {DeviceName}, Model: {ModelNumber} ");
          bool areComponentsWorking = true; // متحول يعبر عن جميع قطع البراد 

            if (areComponentsWorking)
            {
                Console.WriteLine("All components are working correctly.\n");
                DeviceStatus = "Sound";// حالة الجهاز سليم 
            }
            else
            {
                Console.WriteLine("Some components are not working correctly.");
                Console.WriteLine("For more details, please contact the company");
                DeviceStatus = "Not Sound";// حالة الجهاز غير سليم 
            }
        }
        public override void StartMaintenance()
        {
           Console.WriteLine($"Starting maintenance for Refrigerator: {DeviceName}, Model: {ModelNumber} ");
           DeviceStatus = "Under Maintenance";// حالة الجهاز تحت الصيانة
        }
       
        public override void UpdateStatus()
        {
            Console.WriteLine($"\nUpdating final status for Refrigerator: {DeviceName}, Model: {ModelNumber}");
            DeviceStatus = "Fixed and Ready"; // حالة الجهاز بعد الفحص والإصلاح 
            SendNotification("The refrigerator has been fixed and is ready for use.");

        }
        public override double CalculateCost()
        {
            double baseCost = 300;  // التكلفة الخاصة بالبراد
            double refrigeratorFee = 100; // أجور فحص وصيانة 
            double totalCost = baseCost + refrigeratorFee;
            Console.WriteLine($"\nCalculating cost for {DeviceName} -> Service: ${baseCost}, Parts: ${refrigeratorFee}, Total: ${totalCost}");
            return totalCost;
        }
    }
}
