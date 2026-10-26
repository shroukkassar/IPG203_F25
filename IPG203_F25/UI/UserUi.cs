using IPG203_F25.Helpers.IPG203_F25.Helpers;
using IPG203_F25.Models;
using IPG203_F25.Services;
using IPG203_F25.UI;

namespace IPG203_F25.UI
{
    public class UserUi
    {
        private ApplianceManager manager = new ApplianceManager();

        public void ShowMainMenu()
        {
            bool keepGoing = true;

            while (keepGoing)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkBlue;
                Console.WriteLine("==================================================");
                Console.WriteLine("    HOME APPLIANCE REPAIR & MAINTENANCE SYSTEM    ");
                Console.WriteLine("==================================================");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\n((Total Appliances in System: " + Appliance.TotalAppliancesCount + "))");
                Console.ResetColor();
                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                Console.WriteLine("\n1. Receive a new appliance from customer");
                Console.WriteLine("2. Show all registered appliances & status");
                Console.WriteLine("3. Start maintenance process");
                Console.WriteLine("4. Exit");
                Console.Write("\nChoose an option: ");
                Console.ResetColor();

                string choice = Console.ReadLine();

                if (choice == "1")
                {
                    AddNewApplianceScreen();
                }
                else if (choice == "2")
                {
                    ShowAllAppliancesScreen();
                }
                else if (choice == "3")
                {
                    RunMaintenanceScreen();
                }
                else if (choice == "4")
                {
                    keepGoing = false;
                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                    Console.WriteLine("\nThank you for using the system. Goodbye:)");
                    Console.ResetColor();
                }
                else
                {
                    Console.WriteLine("Invalid option! Press any key to try again.");
                    Console.ReadKey();
                }
            }
        }

        private void AddNewApplianceScreen()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("--- New Appliance Reception ---");
            Console.ResetColor();

            Console.WriteLine("Select Appliance Type:\n");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("1. Refrigerator");
            Console.WriteLine("2. Washing Machine");
            Console.WriteLine("3. Air Conditioner");
            Console.WriteLine("4. Microwave");
            Console.WriteLine("5. Other ");
            Console.ResetColor();
            Console.Write("\nEnter choice : ");
            string typeChoice = Console.ReadLine();

            if (typeChoice == "5")
            {
                Console.WriteLine("\n--------------------------------------------------");
                Console.WriteLine(">>> Coming Soon! Maintenance for this appliance type is not available yet.");
                Console.WriteLine(">>> For more details, please contact the company.");
                Console.WriteLine("--------------------------------------------------");
                Console.WriteLine("\nPress any key to return to menu...");
                Console.ReadKey();
                return;
            }

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Customer Phone Number: ");
            string customerPhone = Console.ReadLine();

            Console.Write("Enter Device Name: ");
            string deviceName = Console.ReadLine();



            if (InputChecker.IsValidString(deviceName) == false || InputChecker.IsValidString(customerName) == false)
            {
                Console.WriteLine("\n[Error]: Names cannot be empty!");
                Console.WriteLine("Press any key to return...");
                Console.ReadKey();
                return;
            }
            Console.Write("Enter Model Number: ");
            string modelNumber = Console.ReadLine();

            int newId = Appliance.TotalAppliancesCount + 1;
            Appliance newDevice = null;

            if (typeChoice == "1")
            {
                newDevice = new Refrigerator(newId, deviceName, modelNumber, "Received", DateTime.Now, customerName, customerPhone);
            }
            else if (typeChoice == "2")
            {
                newDevice = new WashingMachine(newId, deviceName, modelNumber, "Received", DateTime.Now, customerName, customerPhone);
            }
            else if (typeChoice == "3")
            {
                newDevice = new AirConditioner(newId, deviceName, modelNumber, "Received", DateTime.Now, customerName, customerPhone);
            }
            else
            {
                newDevice = new Microwave(newId, deviceName, modelNumber, "Received", DateTime.Now, customerName, customerPhone);
            }

            manager.AddAppliance(newDevice);

            Console.WriteLine("\n> Success Appliance registered for " + customerName);
            Console.WriteLine("Press any key to return to menu...");
            Console.ReadKey();
        }

        private void ShowAllAppliancesScreen()
        {
            Console.Clear();
            Console.WriteLine("--- All Registered Appliances ---");

            List<Appliance> allDevices = manager.GetAllAppliances();

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No appliances found in the system.");
            }
            else
            {
                foreach (Appliance appliance in allDevices)
                {
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("ID: " + appliance.DeviceId);
                    Console.WriteLine("Device: " + appliance.DeviceName + " (" + appliance.ModelNumber + ")");
                    Console.WriteLine("Customer: " + appliance.CustomerName + " - Phone: " + appliance.CustomerNumber);
                    Console.WriteLine("Status: " + appliance.DeviceStatus);
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }

        private void RunMaintenanceScreen()
        {
            Console.Clear();
            Console.WriteLine("--- Processing Maintenance for All Devices ---");

            List<Appliance> allDevices = manager.GetAllAppliances();

            if (allDevices.Count == 0)
            {
                Console.WriteLine("No appliances in the system to maintain!");
            }
            else
            {
                foreach (Appliance appliance in allDevices)
                {
                    Console.WriteLine("--------------------------------------------------");

                    appliance.OnStatusChanged += DisplayNotification;

                    appliance.DeviceCheck();
                    appliance.StartMaintenance();
                    appliance.UpdateStatus();
                    appliance.CalculateCost();

                    appliance.OnStatusChanged -= DisplayNotification;
                }
            }

            Console.WriteLine("\nPress any key to return to menu...");
            Console.ReadKey();
        }
        private void DisplayNotification(string message)
        {
            Console.WriteLine("* [System Notification]: " + message + " *");
        }
    }
}
namespace IPG203_F25
{
    internal class Program
    {
        static void Main(string[] args)
        {
            UserUi ui = new UserUi();
            ui.ShowMainMenu();
        }
    }
}