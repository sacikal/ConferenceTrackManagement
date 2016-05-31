using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain
{
    public class TalkLoader : IConferenceTalkLoader
    {
        private readonly Talk _talk;

        public TalkLoader(Talk talk)
        {
            _talk = talk;
        }

        public IEnumerable<Talk> Load()
        {
            return new List<Talk>() { _talk };
        }
    }
}