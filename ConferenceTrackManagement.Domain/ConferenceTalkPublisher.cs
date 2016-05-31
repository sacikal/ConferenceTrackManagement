using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ConferenceTrackManagement.Domain
{
    public class ConferenceTalkPublisher : IConferenceTalkPublisher
    {
        public void Publish(List<Day> conferenceDays)
        {
            using (var streamWriter = new StreamWriter("OutputConference.txt"))
            {
                int trackNumber = 0;
                foreach (var day in conferenceDays)
                {
                    var tracks = day.Tracks.ToList();
                    foreach (var track in tracks)
                    {
                        trackNumber++;
                        streamWriter.WriteLine();
                        streamWriter.WriteLine(string.Format("Track {0}: ", trackNumber));
                        
                        var currentTime = track.MorningSession.From;

                        foreach (var talk in track.MorningSession.Talks)
                        {
                            streamWriter.WriteLine("{0}AM\t{1}\t{2}{3}", currentTime.ToString("hh\\:mm"), talk.Title,
                                talk.TalkDuration.Duration,
                                talk.TalkDuration.TimeUnit);
                            currentTime = currentTime.Add(new TimeSpan(0, talk.TalkDuration.Duration * (int)talk.TalkDuration.TimeUnit, 0));
                        }

                        streamWriter.WriteLine("{0}PM\t{1}", track.Lunch.From.ToString("hh\\:mm"), track.Lunch.Title);

                        currentTime = track.AfternoonSession.From;

                        foreach (var talk in track.AfternoonSession.Talks)
                        {
                            streamWriter.WriteLine("{0}PM\t{1}\t{2}{3}", currentTime.ToString("hh\\:mm"), talk.Title,
                                talk.TalkDuration.Duration,
                                talk.TalkDuration.TimeUnit);
                            currentTime = currentTime.Add(new TimeSpan(0, talk.TalkDuration.Duration * (int)talk.TalkDuration.TimeUnit, 0));
                        }

                        streamWriter.WriteLine("{0}PM\t{1}", track.NetworkingEvent.From.ToString("hh\\:mm"), track.NetworkingEvent.Title);
                    }
                }
            }
        }
    }
}