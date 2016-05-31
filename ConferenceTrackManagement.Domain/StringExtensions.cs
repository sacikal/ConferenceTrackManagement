using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Domain
{
    public static class StringExtensions
    {
        public static bool HasNumberContains(this string text)
        {
            return text.IndexOfAny("0123456789".ToArray()) >= 0;
        }
    }
}
