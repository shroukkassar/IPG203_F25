 using System;
using System.Collections.Generic;
using System.Text;
  
namespace IPG203_F25.Models
{
    public class AirConditioner : Appliance
    {
        public AirConditioner(int deviceId, string deviceName, string modelNumber, string deviceStatus, DateTime receivedDate, string customerName, string customerNumber)
        : base(deviceId, deviceName, modelNumber, deviceStatus, receivedDate, customerName, customerNumber)
        {
        }
        //<summary>
        //This method checks the status of the air conditionar and updates its status acoordingly
        //</summary>

        public override void DeviceCheck()
        {
            Console.WriteLine($"Checking the status of Air Conditioner: {DeviceName}, Model: {ModelNumber} ");
            bool areComponentsWorking = true; // متحول يعبر عن جميع قطع المكيف
             
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
        //<summary>
        //This method starts the maintenance for the air conditioner
        //</summary>

        public override void StartMaintenance()
        {
            Console.WriteLine($"Starting maintenance for Air Conditioner: {DeviceName}, Model: {ModelNumber} ");
            DeviceStatus = "Under Maintenance"; // حالة الجهاز تحت الصيانة
        }
        //<summary>
        //This methid updates the status of the conditionar after maintenance
        //</summary>

        public override void UpdateStatus()
        {
            Console.WriteLine($"\nUpdating final status for Air Conditioner: {DeviceName}, Model: {ModelNumber}");
            DeviceStatus = "Fixed and Ready"; // حالة الجهاز بعد الفحص والإصلاح
            SendNotification("The air conditioner has been fixed and is ready for use.");
        }
        //<summary>
        //This method calculates the cost of maintaining the air conditioner
        //</summary>


        public override double CalculateCost()
        {
            double baseCost = 250;      // التكلفة الخاصة بالمكيف (قطع غيار/غاز)
            double serviceFee = 100;    // أجور فحص وصيانة
            double totalCost = baseCost + serviceFee;

            Console.WriteLine($"\nCalculating cost for {DeviceName} -> Service: ${serviceFee}, Parts: ${baseCost}, Total: ${totalCost}");
            return totalCost;
        }
    }
}
