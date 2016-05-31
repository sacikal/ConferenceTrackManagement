using System;

namespace ConferenceTrackManagement.Domain
{
    public class ConferenceSessionEvent
    {
        public string Title { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
    }
}