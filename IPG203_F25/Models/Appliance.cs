using IPG203_F25.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203_F25.Models
{
    public abstract class Appliance : IApplianceService
    {
      public int DeviceId { get; private set; }
      public string DeviceName { get; set; }
      public string ModelNumber { get; private set; }
      public string DeviceStatus { get; set; } 
      public DateTime ReceivedDate { get; private set; }
      public string CustomerName { get; set; }
      public string CustomerNumber { get; set; }
      public static int TotalAppliancesCount = 0;

      public Appliance(int deviceId, string deviceName,string modelNumber, string deviceStatus, DateTime receivedDate ,string customerName, string customerNumber)
      {
         DeviceId = deviceId;
         DeviceName = deviceName;
         ModelNumber = modelNumber;
         DeviceStatus = deviceStatus;
         ReceivedDate = receivedDate;
         CustomerName = customerName;
         CustomerNumber = customerNumber;
         TotalAppliancesCount++;
      }
      public abstract double CalculateCost();
      public virtual void StartMaintenance(){ }
      public virtual void DeviceCheck() { }
      public virtual void UpdateStatus() { }

      public delegate void StatusNotify(string message);
      public event StatusNotify OnStatusChanged;

        public void SendNotification(string message)
        {
            if (OnStatusChanged != null)
            {
                OnStatusChanged(message);
            }
        }
    }
}
