namespace SOLID_Test.After
{
    public class GoogleHomeApi : IExternalNotifier
    {
        public void Notify(string message)
        {
            SendCommand(message); 
        }
        public void SendCommand(string command)
        {
            // call external API
        }
    }
}
