using System;
using System.Collections.Generic;
using System.Linq;

namespace XamCal.Abstractions
{
    public class Day
    {
        public Day(DateTime date)
        {
            Date = date;
            Events = new Event[0];
        }

        public Day(DateTime date, IEnumerable<Event> events)
        {
            Date = date;
            Events = events;
        }

        public DateTime Date { get; set; }
        public int DayOfMonth
        {
            get { return Date.Day; }
        }

        public IEnumerable<Event> Events { get; set; }
        public bool HasEvents
        {
            get { return Events != null && Events.Any(); }
        }

        public int NumberOfEvents
        {
            get { return Events == null ? 0 : Events.Count(); }
        }
    }
}
