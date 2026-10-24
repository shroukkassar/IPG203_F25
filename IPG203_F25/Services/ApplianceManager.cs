using System;
using System.Collections.Generic;
using System.Text;
using IPG203_F25.Models;

namespace IPG203_F25.Services
{
    public class ApplianceManager
    {
      private List<Appliance> appliances = new List<Appliance>();
        public void AddAppliance(Appliance appliance)
        {
            appliances.Add(appliance);
        }
        public void RemoveAppliance(Appliance appliance)
        {
            appliances.Remove(appliance);
        }
        public List<Appliance> GetAllAppliances()
        {
            return appliances;
        }
        public Appliance GetApplianceById(int deviceId)
        {
            foreach (var appliance in appliances)
            {
                if (appliance.DeviceId == deviceId)
                {
                    return appliance; 
                }
            }

            return null;
        }
    }
}
