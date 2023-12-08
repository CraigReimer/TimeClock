namespace CMR.TimeClock.BL
{
    public class TimeEntry
    {
        // define entry types
        public enum EntryType
        {
            Working,
            Training
        }


        // properties
        public int EntryID { get; set; }

        public DateTime TimeIn { get; set; }
        
        public DateTime TimeOut { get; set; }
        
        public bool IsLogged { get; set; }

        public EntryType _EntryType { get; set; }



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

        public TimeEntry(DateTime timeIn, DateTime timeOut, EntryType entryType)
        {
            TimeIn = timeIn;
            TimeOut = timeOut;
            _EntryType = entryType;
        }

        public TimeEntry(DateTime timeIn, DateTime timeOut, EntryType entryType, bool isLogged)
        {
            TimeIn = timeIn;
            TimeOut = timeOut;
            _EntryType = entryType;
            IsLogged = isLogged;
        }
    }
}