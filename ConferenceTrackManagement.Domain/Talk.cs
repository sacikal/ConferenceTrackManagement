namespace ConferenceTrackManagement.Domain
{
    public class Talk
    {
        private string _title;
        public TalkDuration TalkDuration { get; set; }

        public string Title
        {
            get { return _title; }
            private set
            {
                if (value.HasNumberContains())
                {
                    throw new NoTalkTitleHasNumbersInIntException(value);
                }
                _title = value;
            }
        }
        public Talk(string title, TalkDuration talkDuration)
        {
            Title = title;
            TalkDuration = talkDuration;
        }
    }
}