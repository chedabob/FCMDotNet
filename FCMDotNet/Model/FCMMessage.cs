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

    public class FCMMessageNotification
    {
        public string Title { get; }
        public string Body { get; }

        protected internal FCMMessageNotification()
        {

        }

        protected internal FCMMessageNotification(string title, string body)
        {
            Title = title;
            Body = body;
        }
    }
}