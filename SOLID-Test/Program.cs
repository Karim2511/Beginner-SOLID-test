using SOLID_Test.After;
namespace SOLID_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //#region SOLID_Test.Before
            //Console.WriteLine("This is the Before version of the Smart Home Manager.");
            //var manager = new SOLID_Test.Before.SmartHomeManager();
            //manager.AddDevice(new SOLID_Test.Before.SmartDevice { Name = "AC", Type = "TemperatureSensor" });
            //manager.AddDevice(new SOLID_Test.Before.SmartDevice { Name = "Light", Type = "Light" });

            //manager.TurnOnAllDevices();
            //manager.MonitorDevices();
            //manager.TurnOffAllDevices();

            //Console.WriteLine("Test finished (before refactoring).");
            //Console.ReadKey();
            //#endregion

            #region SOLID_Test.After
            Console.WriteLine("This is the After version of the Smart Home Manager.");
            IDatabase database = new SqlDatabase();
            IAlertService alertService = new AlertService();
            IExternalNotifier notifier = new GoogleHomeApi();

            var devices = new List<SmartDevice>
        {
            new SmartDevice { Name = "AC", Type = "TemperatureSensor" },
            new SmartDevice { Name = "Light", Type = "Light" }
        };

            var manager = new SmartHomeManager(devices, database, alertService, notifier);

            manager.TurnOnAllDevices();
            manager.MonitorDevices();
            manager.TurnOffAllDevices();

            Console.WriteLine("Test finished (after refactoring).");
            Console.ReadKey();
        }
        #endregion
    }

}

