using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Domain.Tests.Builders
{
    public class StubDayBuilder : IDayBuilder
    {
        public IEnumerable<Day> CreateScheduleDays(int count)
        {
            IList<Day> days = new List<Day>();
            IList<Track> tracks = new List<Track>();

            for (int i = 0; i < count; i++)
            {
                tracks.Add(TrackCreationBuilder.CreateTrack());
            }

            days.Add(new Day(tracks));

            return days;
        }
    }
}
