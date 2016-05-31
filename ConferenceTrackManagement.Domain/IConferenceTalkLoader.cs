using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain
{
    public interface IConferenceTalkLoader
    {
        IEnumerable<Talk> Load();
    }
}