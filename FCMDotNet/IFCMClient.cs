using System.Threading.Tasks;
using FCMDotNet.Model;

namespace FCMDotNet
{
    public interface IFCMClient
    {
        /// <summary>
        /// Posts a message to Firebase
        /// </summary>
        /// <param name="message">Message to send. Use FCMMessageBuilder to construct it</param>
        /// <returns></returns>
        Task PostMessage(FCMMessage message);
    }
}