using System;
using System.Collections.Generic;
using System.Text;

namespace IPG203_F25.Interfaces
{
    public interface IApplianceService
    {
        void StartMaintenance();
        void DeviceCheck();
        void UpdateStatus();
    }
}
