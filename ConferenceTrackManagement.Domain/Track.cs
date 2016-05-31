using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Domain
{
    public class Track
    {
        public TalkSession MorningSession { get; set; }
        public TalkSession AfternoonSession { get; set; }
        public NetworkingEvent NetworkingEvent { get; set; }
        public Break Lunch { get; set; }

        public Track CreateTrack()
        {
            var track = new Track()
            {
                MorningSession = new TalkSession() { Title = "Morning", From = new TimeSpan(9, 00, 00), To = new TimeSpan(12, 00, 00) },
                AfternoonSession = new TalkSession() { Title = "Afternoon", From = new TimeSpan(1, 00, 00), To = new TimeSpan(5, 00, 00) },
                NetworkingEvent = new NetworkingEvent() { Title = "Networking Event", From = new TimeSpan(4, 00, 00), To = new TimeSpan(5, 00, 00) },
                Lunch = new Break() { Title = "Lunch", From = new TimeSpan(12, 00, 00), To = new TimeSpan(1, 00, 00) }
            };

            return track;
        }
    }
}
