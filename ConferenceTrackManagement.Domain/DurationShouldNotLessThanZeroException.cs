using System;
using System.Runtime.Serialization;

namespace ConferenceTrackManagement.Domain
{
    public class DurationShouldNotLessThanZeroException : Exception
    {
        public DurationShouldNotLessThanZeroException(int value) : base(string.Format("Invalid time. Duration should not be negative. Value: {0}", value))
        {
        }
    }
}