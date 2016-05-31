using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagement.Domain
{
    public class ConferenceScheuduler
    {
        public void Scheudule(IList<Day> conferenceDays, IList<Talk> currentTalks)
        {
            foreach (var track in conferenceDays.SelectMany(conferenceDay => conferenceDay.Tracks))
            {
                track.MorningSession.Talks = new List<Talk>();
                track.MorningSession.RemainingTime = track.MorningSession.To.Subtract(track.MorningSession.From);

                track.AfternoonSession.Talks = new List<Talk>();
                track.AfternoonSession.RemainingTime = track.AfternoonSession.To.Subtract(track.AfternoonSession.From);
            }
             
            foreach (var currentTalk in currentTalks)
            {
                foreach (var conferenceDay in conferenceDays)
                {
                    bool isScheuduledMorning = ScheuduleForMorning(currentTalk, conferenceDay);
                    if (!isScheuduledMorning)
                    {
                        ScheduleForAfternoon(currentTalk, conferenceDay);
                    }

                    ScheuduleNetworkingEvent(conferenceDay);
                }
            }
        }

        private void ScheuduleNetworkingEvent(Day conferenceDay)
        {
            foreach (var track in conferenceDay.Tracks)
                track.NetworkingEvent.From = track.AfternoonSession.To.Subtract(track.AfternoonSession.RemainingTime);
        }

        private bool ScheuduleForMorning(Talk currentTalk, Day conferenceDay)
        {
            foreach (var track in conferenceDay.Tracks)
            {
                var duration = currentTalk.TalkDuration.Duration * (int)(currentTalk.TalkDuration.TimeUnit);
                var talkScheduledForMorning = (duration <= track.MorningSession.RemainingTime.TotalMinutes);

                if (talkScheduledForMorning)
                {
                    track.MorningSession.Talks.Add(currentTalk);
                    track.MorningSession.RemainingTime = track.MorningSession
                                                            .RemainingTime.Subtract(new TimeSpan(0, duration, 0));
                    return true;
                }
            }
            return false;
        }

        private bool ScheduleForAfternoon(Talk currentTalk, Day conferenceDay)
        {
            foreach (var track in conferenceDay.Tracks)
            {
                var duration = currentTalk.TalkDuration.Duration * (int)(currentTalk.TalkDuration.TimeUnit);
                bool talkScheduledForAfternoon = (duration <= track.AfternoonSession.RemainingTime.TotalMinutes);
                if (talkScheduledForAfternoon)
                {
                    track.AfternoonSession.Talks.Add(currentTalk);
                    track.AfternoonSession.RemainingTime = track.AfternoonSession.RemainingTime.Subtract(new TimeSpan(0, duration, 0));
                    return true;
                }
            }
            return false;
        }
    }
}