namespace SOLID_Test.Before
{
    public class SmartHomeManager
    {
        private List<SmartDevice> devices = new List<SmartDevice>();

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
            var db = new SqlDatabase();
            db.Save(message);
        }

        private void SendAlert(string message)
        {
            if (message.Contains("temperature"))
            {
                var sms = new SmsSender();
                sms.Send(message);
            }
            else
            {
                var email = new EmailSender();
                email.Send(message);
            }
        }

        private void NotifyGoogleAssistant(string message)
        {
            var google = new GoogleHomeApi();
            google.SendCommand(message);
        }
    }

}
