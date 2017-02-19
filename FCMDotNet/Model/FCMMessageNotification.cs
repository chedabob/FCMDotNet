namespace FCMDotNet.Model
{
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