using System;
using FCMDotNet.Model;

namespace FCMDotNet
{
    public class FCMMessageBuilder
    {
        private string _to;
        private string _title;
        private string _body;
        public FCMMessageBuilder SetTopic(string topic)
        {
            if (!string.IsNullOrEmpty(topic))
            {
                _to = "/topics/" + topic;
            }
            return this;
        }

        public FCMMessageBuilder SetRegistrationToken(string registrationToken)
        {

            _to = registrationToken;
            return this;
        }

        public FCMMessageBuilder SetTitle(string title)
        {
            _title = title;
            return this;
        }

        public FCMMessageBuilder SetMessage(string message)
        {
            _body = message;
            return this;
        }

        public FCMMessage Build()
        {
            if (string.IsNullOrEmpty(_to))
            {
                throw new ArgumentException("You must supply a topic or registration token");
            }

            // For now only a body is a requirement, but for iOS silent pushes this will not be necessary
            if (string.IsNullOrEmpty(_body))
            {
                throw new ArgumentException("You must supply a message body");
            }

            return new FCMMessage(_to, new FCMMessageNotification(_title, _body));
        }
    }
}