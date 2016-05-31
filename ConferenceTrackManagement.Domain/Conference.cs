using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagement.Domain
{
    public class Conference
    {
        public List<Talk> CurrentTalks { get; private set; }
        public List<Day> ConferenceDays { get; private set; }
        public ConferenceScheduler ConferenceScheduler { get; private set; }
        public IConferenceTalkLoader ConferenceTalkLoader { get; set; }
        public IConferenceTalkPublisher ConferenceTalkPublisher { get; set; }
        public int RemainingTime { get; set; }
        public Conference(ConferenceScheduler conferenceScheduler, List<Day> days)
        {
            CurrentTalks = new List<Talk>();
            ConferenceScheduler = conferenceScheduler;
            ConferenceDays = days;
            CalculateRemainingConferenceTime();
            ConferenceTalkPublisher = new ConferenceTalkPublisher();
        }

        public void Schedule()
        {
            ConferenceScheduler.Schedule(ConferenceDays, CurrentTalks);
        }

        public void PublishSchedule()
        {
            ConferenceTalkPublisher.Publish(ConferenceDays);
        }

        public void LoadTalks()
        {
            var talks = ConferenceTalkLoader.Load().ToList();
            RegisterTalks(talks);
            CurrentTalks.InsertRange(CurrentTalks.Count, talks);
        }

        public void RegisterTalks(IEnumerable<Talk> talks)
        {
            var taken = talks.Sum(talk => talk.TalkDuration.Duration * (int)talk.TalkDuration.TimeUnit);
            if (taken > RemainingTime)
                throw new ExceededTimeLimitException();

            RemainingTime = RemainingTime - taken;
        }

        public void CalculateRemainingConferenceTime()
        {
            foreach (var track in ConferenceDays.SelectMany(conferenceDay => conferenceDay.Tracks))
            {
                RemainingTime += (int)track.MorningSession.To.Subtract(track.MorningSession.From).TotalMinutes;
                RemainingTime += (int)track.AfternoonSession.To.Subtract(track.AfternoonSession.From).TotalMinutes;
            }
        }
    }
}