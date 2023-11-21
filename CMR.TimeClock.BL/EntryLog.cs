using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMR.TimeClock.BL
{
    public class EntryLog : List<TimeEntry>
    {
        // constructors
        public EntryLog() { }


        // methods
        public void LoadTestData()
        {
            TimeEntry timeEntry;

            timeEntry = new TimeEntry(new DateTime(2020, 10, 01, 10, 0, 0), DateTime.Parse("2020-10-01 12:00:00"));
            Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-02 12:00:00"), DateTime.Parse("2020-10-02 13:00:00"));
            Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-03 11:00:00"), DateTime.Parse("2020-10-03 14:00:00"));
            Add(timeEntry);
        }
    }
}
