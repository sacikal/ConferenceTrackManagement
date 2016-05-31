using System;

namespace ConferenceTrackManagement.Domain.Tests.Builders
{
    public static class TrackCreationBuilder
    {
        public static Track CreateTrack()
        {
            var track = new Track()
            {
                MorningSession = new TalkSession() { Title = "Morning", From = new TimeSpan(9, 00, 00), To = new TimeSpan(12, 00, 00) },
                AfternoonSession = new TalkSession() { Title = "Afternoon", From = new TimeSpan(1, 00, 00), To = new TimeSpan(5, 00, 00) },
                NetworkingEvent = new NetworkingEvent() { Title = "Networking Event", From = new TimeSpan(4, 00, 00), To = new TimeSpan(5, 00, 00) },
                Lunch = new Break() { Title = "Lunch", From = new TimeSpan(12, 00, 00), To = new TimeSpan(1, 00, 00) }
            };

            return track;
        }
    }
}