using System;
using FCMDotNet;
using NUnit.Framework;

namespace FCMDotNetTest
{
    [TestFixture]
    public class TestMessageBuilder
    {

        [Test]
        public void TestExcptionThrownWhenNothingSet()
        {
            var builder = new FCMMessageBuilder();

            Assert.Throws<ArgumentException>(() => builder.Build());
        }

        [Test]
        public void TestExcptionThrownWhenNoMessageSet()
        {

            var builder = new FCMMessageBuilder();
            builder.SetRegistrationToken("123456");

            Assert.Throws<ArgumentException>(() => builder.Build());
        }

        [Test]
        public void TestExcptionThrownWhenNoDestSet()
        {

            var builder = new FCMMessageBuilder();
            builder.SetMessage("qwert");

            Assert.Throws<ArgumentException>(() => builder.Build());
        }

        [Test]
        public void TestExcptionThrownWhenTitleSetButNoMessage()
        {

            var builder = new FCMMessageBuilder();
            builder.SetTitle("qwert");
            builder.SetTopic("asdfg");

            Assert.Throws<ArgumentException>(() => builder.Build());
        }

        [Test]
        public void TestTopicSet()
        {
            var topic = "qwerty";

            var builder = new FCMMessageBuilder();
            builder.SetTopic(topic);
            builder.SetMessage("empty");

            var res = builder.Build();


            Assert.That(res.To, Is.EqualTo("/topics/" + topic));
        }

        [Test]
        public void TestRegTokenSet()
        {
            var regToken = "qwerty";

            var builder = new FCMMessageBuilder();
            builder.SetRegistrationToken(regToken);
            builder.SetMessage("empty");

            var res = builder.Build();


            Assert.That(res.To, Is.EqualTo(regToken));
        }

        [Test]
        public void TestTopicOverWritesRegToken()
        {
            var regToken = "qwerty";
            var topic = "asdfg";

            var builder = new FCMMessageBuilder();
            builder.SetRegistrationToken(regToken);
            builder.SetTopic(topic);
            builder.SetMessage("empty");

            var res = builder.Build();

            Assert.That(res.To, Is.EqualTo("/topics/" + topic));
        }

        [Test]
        public void TestTitleSet()
        {
            var topic = "qwerty";

            var builder = new FCMMessageBuilder();
            builder.SetTopic(topic);
            var title = "ghjkl";
            builder.SetTitle(title);
            builder.SetMessage("empty");

            var res = builder.Build();


            Assert.That(res.Notification.Title, Is.EqualTo(title));
        }

        [Test]
        public void TestBodySet()
        {
            var topic = "qwerty";

            var builder = new FCMMessageBuilder();
            builder.SetTopic(topic);
            var message = "ghjkl";
            builder.SetMessage(message);

            var res = builder.Build();


            Assert.That(res.Notification.Body, Is.EqualTo(message));
        }
    }
}