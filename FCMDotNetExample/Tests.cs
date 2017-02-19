using System;
using FCMDotNet;
using NUnit.Framework;

namespace FCMDotNetExample
{

    public class Example
    {
        static void Main(string[] args)
        {
            var fcmServerKey = "<ADD THIS>";
            var client = new FCMClient(fcmServerKey);


            var registrationToken = "<ADD THIS>";
            var message = "Test";

            var builder = new FCMMessageBuilder();
            builder.SetMessage(message);
            builder.SetRegistrationToken(registrationToken);

            var msg = builder.Build();


            client.PostMessage(msg).Wait();
        }
    }
}