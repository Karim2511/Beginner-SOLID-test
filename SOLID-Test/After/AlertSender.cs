namespace SOLID_Test.After
{
    public class AlertService : IAlertService
    {
        private readonly EmailSender _emailSender;
        private readonly SmsSender _smsSender;

        public AlertService()
        {
            _emailSender = new EmailSender();
            _smsSender = new SmsSender();
        }

        public void Send(string message)
        {
            if (message.Contains("temperature"))
            {
                _smsSender.Send(message);
            }
            else
            {
                _emailSender.Send(message);
            }
        }
    }

}
