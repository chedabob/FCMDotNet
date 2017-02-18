using System;
using System.Net;
using System.Threading.Tasks;
using RestSharp;

namespace FCMDotNet
{
    public class FCMClient : IFCMClient
    {
        private readonly RestClient _restClient;
        private readonly string _fcmServerKey;

        public FCMClient(string fcmServerKey)
        {
            _fcmServerKey = fcmServerKey;
            _restClient = new RestClient("https://fcm.googleapis.com/");
        }

        public async Task PostMessage(FCMMessage message)
        {
            var request = new RestRequest("fcm/send", Method.POST);
            request.AddJsonBody(message);
            request.AddHeader("Authorization", "key=" + _fcmServerKey);

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