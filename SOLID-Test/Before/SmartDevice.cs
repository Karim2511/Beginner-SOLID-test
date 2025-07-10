namespace SOLID_Test.Before
{
    public class SmartDevice
    {
        public string? Name { get; set; }
        public string? Type { get; set; }

        public void TurnOn() { /* ... */ }
        public void TurnOff() { /* ... */ }

        public double ReadTemperature()
        {
            return new Random().NextDouble() * 40;
        }
    }

}
