using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConferenceTrackManagement.Domain.Tests.Builders;
using NUnit.Framework;

namespace ConferenceTrackManagement.Domain.Tests
{
    [TestFixture]
    public class ConferenceTests
    {
        private List<Day> _days;
        private IDayBuilder _dayBuilder;
        private Conference _conference;
        private ConferenceScheduler _conferenceScheduler;
        [SetUp]
        public void SetUp()
        {
            _dayBuilder = new StubDayBuilder();
            _conferenceScheduler = new ConferenceScheduler();
            _days = _dayBuilder.CreateScheduleDays(2).ToList();

            _conference = new Conference(_conferenceScheduler, _days);
            _conference.ConferenceTalkLoader = new ConferenceTalkLoader(TalkCreationBuilder.GetTalks());
            _conference.LoadTalks();

            _conference.Schedule();
        }

        [Test]
        public void WhenImportTalksList()
        {
            Assert.AreEqual(19, _conference.CurrentTalks.Count);
        }

        [Test]
        public void WhenOneTalkRegistered()
        {
            Talk talk = new Talk("test talk", new TalkDuration(TimeUnit.Min, 20));
            Conference conference = new Conference(_conferenceScheduler, _days);
            conference.ConferenceTalkLoader = new TalkLoader(talk);

            conference.LoadTalks();

            Assert.AreEqual(1, conference.CurrentTalks.Count);
        }

        [Test]
        public void WhenPublishSchedule()
        {
            Assert.DoesNotThrow(() => _conference.PublishSchedule());
        }
    }
}
