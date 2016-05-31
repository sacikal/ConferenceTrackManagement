using System;
using NUnit.Framework;

namespace ConferenceTrackManagement.Domain.Tests
{
    [TestFixture]
    public class TalkTests
    {
        private Talk _talk;
        private TalkDuration _talkDuration;

        [SetUp]
        public void SetUp()
        {
            _talkDuration = new TalkDuration(TimeUnit.Min, 5);
            _talk = new Talk("Ruby session", _talkDuration);   
        }

        [Test]
        public void WhenTalkTitleContainsNumbers()
        {
            Assert.Throws<NoTalkTitleHasNumbersInIntException>(() => _talk = new Talk("Title66", _talkDuration));
        }

        [Test]
        public void WhenTalkDurationInvalid()
        {
            Assert.Throws<DurationShouldNotLessThanZeroException>(() => _talk = new Talk("Title", new TalkDuration(TimeUnit.Min, -5)));
        }
    }
}