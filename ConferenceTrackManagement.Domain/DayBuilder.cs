using System;
using System.Collections.Generic;
using System.Linq;

namespace ConferenceTrackManagement.Domain
{
    public class DayBuilder : IDayBuilder
    {
        public IEnumerable<Day> CreateScheduleDays(int trackCount)
        {
            IList<Day> days = new List<Day>();
            IList<Track> tracks = new List<Track>();

            Track track = new Track();
            for (int i = 0; i < trackCount; i++)
            {
                tracks.Add(track.CreateTrack());
            }

            days.Add(new Day(tracks));

            return days;
        }
    }
}