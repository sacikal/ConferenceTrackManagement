using System;

namespace ConferenceTrackManagement.Domain
{
    public class NoTalkTitleHasNumbersInIntException : Exception
    {
        public NoTalkTitleHasNumbersInIntException(string title) : base(string.Format("No talk title has numbers in it. Value: {0}", title))
        {
            
        }
    }
}