﻿using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConferenceTrackManagement.Domain
{
    public interface IDayBuilder
    {
        IEnumerable<Day> CreateScheduleDays(int count);
    }
}
