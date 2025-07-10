namespace SOLID_Test.After
{
    public class SmartHomeManager
    {
        private List<SmartDevice> devices = new();
        private readonly IDatabase _database;
        private readonly IAlertService _alertService;
        private readonly IExternalNotifier _notifier;

        public SmartHomeManager(List<SmartDevice> devices, IDatabase database, IAlertService alertService, IExternalNotifier notifier)
        {
            this.devices = devices;
            _database = database;
            _alertService = alertService;
            _notifier = notifier;
        }

        public void AddDevice(SmartDevice device)
        {
            devices.Add(device);
        }

        public void TurnOnAllDevices()
        {
            foreach (var device in devices)
            {
                device.TurnOn();
                SaveToDatabase($"{device.Name} turned ON at {DateTime.Now}");
                SendAlert($"{device.Name} has been activated.");
                NotifyGoogleAssistant(device.Name + " is now ON");
            }
        }

        public void TurnOffAllDevices()
        {
            foreach (var device in devices)
            {
                device.TurnOff();
                SaveToDatabase($"{device.Name} turned OFF at {DateTime.Now}");
                SendAlert($"{device.Name} has been deactivated.");
            }
        }

        public void MonitorDevices()
        {
            foreach (var device in devices)
            {
                if (device.Type == "TemperatureSensor")
                {
                    var value = device.ReadTemperature();
                    if (value > 30)
                    {
                        SendAlert($"High temperature detected by {device.Name}: {value}°C");
                    }
                }
            }
        }

        private void SaveToDatabase(string message)
        {
            _database.Save(message);
        }

        private void SendAlert(string message)
        {
            _alertService.Send(message);
        }

        private void NotifyGoogleAssistant(string message)
        {
            _notifier.Notify(message);
        }
    }
}
