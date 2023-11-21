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
        public EntryLog() {
            
        }


        // methods
        public void LoadTestData()
        {
            TimeEntry timeEntry;

            timeEntry = new TimeEntry(DateTime.Parse("10/01/2020 10:00:00"), DateTime.Parse("10/01/2020 12:00:00"));
            Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("10/02/2020 12:00:00"), DateTime.Parse("10/02/2020 13:00:00"));
            Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("10/03/2020 11:00:00"), DateTime.Parse("10/03/2020 14:00:00"));
            Add(timeEntry);
        }
    }
}
