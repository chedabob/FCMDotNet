
using System;
using System.Net;
using System.Threading.Tasks;
using FCMDotNet.Model;
using RestSharp;

namespace FCMDotNet
{
    public class FCMClient : IFCMClient
    {
        private readonly RestClient _restClient;

        public FCMClient(string fcmServerKey)
        {
            if (string.IsNullOrEmpty(fcmServerKey))
            {
                throw new ArgumentException($"{nameof(fcmServerKey)} cannot be null or empty");
            }
            _restClient = new RestClient("https://fcm.googleapis.com/");
            _restClient.AddDefaultHeader("Authorization", "key=" + fcmServerKey);
        }

        public async Task PostMessage(FCMMessage message)
        {
            var request = new RestRequest("fcm/send", Method.POST);
            request.AddJsonBody(message);

            var response = await _restClient.ExecuteTaskAsync(request);

            var statusCode = response.StatusCode;
            if (statusCode == HttpStatusCode.OK)
            {
                // TODO Extract message
            }
            else
            {
                // TODO Do something with an error
            }
        }
    }
}