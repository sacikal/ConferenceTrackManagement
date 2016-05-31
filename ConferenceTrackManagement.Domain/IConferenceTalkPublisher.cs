using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain
{
    public interface IConferenceTalkPublisher
    {
        void Publish(List<Day> conferenceDays);
    }
}