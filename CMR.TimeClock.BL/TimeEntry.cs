namespace CMR.TimeClock.BL
{
    public class TimeEntry
    {
        // properties
        public DateTime TimeIn { get; set; }
        public DateTime TimeOut { get; set; }


        // constructors
        public TimeEntry() { }

        public TimeEntry(DateTime timeIn)
        {
            TimeIn = timeIn;
        }

        public TimeEntry (DateTime timeIn, DateTime timeOut)
        {
            TimeIn = timeIn;
            TimeOut = timeOut;
        }


    }
}