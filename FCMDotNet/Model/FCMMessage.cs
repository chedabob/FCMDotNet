namespace FCMDotNet.Model
{
    public class FCMMessage
    {

        public string To { get; }
        public FCMMessageNotification Notification { get; }

        protected internal FCMMessage()
        {

        }

        protected internal FCMMessage(string to, FCMMessageNotification notification)
        {
            To = to;
            Notification = notification;
        }
    }
}