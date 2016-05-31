using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Domain
{
    public class TalkDuration
    {
        private int _duration;

        public int Duration
        {
            get { return _duration; }
            set
            {
                if (value < 0)
                {
                    throw new DurationShouldNotLessThanZeroException(value);
                }
                _duration = value;
            }
        }

        public TimeUnit TimeUnit { get; set; }

        public TalkDuration(TimeUnit timeUnit, int duration)
        {
            TimeUnit = timeUnit;
            Duration = duration;
        }
    }
}
