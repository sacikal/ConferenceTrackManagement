using System;
using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain
{
    public class TalkSession : ConferenceSessionEvent
    {
        public IList<Talk> Talks { get; set; }
        private int _talkDuration;

        public int TalkDuration
        {
            get { return _talkDuration; }
            private set { _talkDuration = (int)To.Subtract(From).TotalMinutes; }
        }

        public TimeSpan RemainingTime { get; set; }
    }
}