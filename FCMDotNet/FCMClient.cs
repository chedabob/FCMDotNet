
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FCMDotNet.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using RestSharp;
using RestSharp.Serializers;

namespace FCMDotNet
{
    /// <summary>
    /// FCM Client
    /// </summary>
    public class FCMClient : IFCMClient
    {
        private readonly RestClient _restClient;
        private readonly NewtonsoftJSONSerializer _jsonSerializer;

        /// <summary>
        /// Creates an FCM Client
        /// </summary>
        /// <param name="fcmServerKey">FCM Server Key. Retrieve this from the Firebase console. See https://firebase.google.com/docs/cloud-messaging/server#auth</param>
        public FCMClient(string fcmServerKey)
        {
            if (string.IsNullOrEmpty(fcmServerKey))
            {
                throw new ArgumentException($"{nameof(fcmServerKey)} cannot be null or empty");
            }
            _restClient = new RestClient("https://fcm.googleapis.com/");
            _restClient.AddDefaultHeader("Authorization", "key=" + fcmServerKey);

            _jsonSerializer = new NewtonsoftJSONSerializer();
        }

        public async Task PostMessage(FCMMessage message)
        {
            var request = new RestRequest("fcm/send", Method.POST);
            request.JsonSerializer = _jsonSerializer;
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

    // From https://github.com/adamfisher/RestSharp.Newtonsoft.Json/blob/master/RestSharp.Newtonsoft.Json/NewtonsoftJsonSerializer.cs
    public class NewtonsoftJSONSerializer : ISerializer
    {
        private readonly Newtonsoft.Json.JsonSerializer _serializer;
        public NewtonsoftJSONSerializer()
        {
            _serializer = new Newtonsoft.Json.JsonSerializer
            {
                NullValueHandling = NullValueHandling.Ignore,
                ContractResolver = new LowercaseContractResolver()
            };
        }

        public string Serialize(object obj)
        {
            using (var sw = new StringWriter())
            using (var jtw = new JsonTextWriter(sw))
            {
                jtw.Formatting = Formatting.Indented;
                jtw.QuoteChar = '"';

                _serializer.Serialize(jtw, obj);

                return sw.ToString();
            }
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }

        public string ContentType
        {
            get { return "application/json"; }
            set { }
        }

        // From: http://stackoverflow.com/a/6288726/78496
        private class LowercaseContractResolver : DefaultContractResolver
        {
            protected override string ResolvePropertyName(string propertyName)
            {
                return propertyName.ToLower();
            }
        }
    }
}