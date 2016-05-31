using System.Linq;
using ConferenceTrackManagement.Domain;

namespace ConferenceTrackManagement.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var dayBuilder = new DayBuilder();
            var days = dayBuilder.CreateScheduleDays(2).ToList();

            var conferenceScheduler = new ConferenceScheduler();
            var talks = new FileParserService().Read("../../Input.txt");

            var conference = new Conference(conferenceScheduler, days);
            conference.ConferenceTalkLoader = new ConferenceTalkLoader(talks);
            conference.LoadTalks();
            conference.Schedule();
            conference.PublishSchedule();

            System.Console.WriteLine("Success!");
            System.Console.ReadLine();
        }
    }
}
