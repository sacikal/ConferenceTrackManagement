using System;
using System.Collections.Generic;

namespace ConferenceTrackManagement.Domain
{
    public class ConferenceTalkLoader : IConferenceTalkLoader
    {
        public List<string> Talks { get; set; }

        public ConferenceTalkLoader(List<string> talks)
        {
            Talks = talks;
        }
        public IEnumerable<Talk> Load()
        {
            var talks = new List<Talk>();

            foreach (var talk in Talks)
            {
                var unit = CheckTimeUnit(talk);
                string title;

                int durationIndex = talk.IndexOfAny("0123456789".ToCharArray());

                var duration = "1";

                if (durationIndex == -1)
                {
                    title = talk.Substring(0, talk.LastIndexOf(unit, StringComparison.OrdinalIgnoreCase));
                }
                else
                {
                    title = talk.Substring(0, durationIndex);

                    duration = talk.Substring(durationIndex,
                        talk.LastIndexOfAny("0123456789".ToCharArray()) - durationIndex + 1);
                }

                var timeUnit = (TimeUnit)Enum.Parse(typeof(TimeUnit), unit, true);
                var talkDuration = new TalkDuration(timeUnit, Convert.ToInt32(duration));

                talks.Add(new Talk(title, talkDuration));
            }

            return talks;
        }

        private string CheckTimeUnit(string talk)
        {
            var values = Enum.GetValues(typeof(TimeUnit));

            foreach (var unit in values)
            {
                if (talk.IndexOf(unit.ToString(), StringComparison.OrdinalIgnoreCase) > -1)
                    return unit.ToString();
            }
            return null;
        }
    }
}