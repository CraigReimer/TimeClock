namespace CMR.TimeClock.BL
{
    public class TimeEntry
    {
        // define entry types
        public enum TimeType 
        {
            Working,
            Training
        }

        // fields
        private DateTime timeIn;
        private DateTime timeOut;


        // properties
        public int EntryID { get; set; }

        public DateTime TimeIn
        {
            get => timeIn;
            set
            {
                timeIn = value.AddSeconds(-value.Second);
            }
        }
        
        public DateTime TimeOut
        {
            get => timeOut;
            set
            {
                timeOut = value.AddSeconds(-value.Second);
            }
        }

        public String ElapsedTime
        {
            get
            {
                if (TimeOut == DateTime.MinValue || TimeOut < TimeIn) // TimeOut not set or invalid
                {
                    return String.Empty; 
                }
                else
                {
                    TimeSpan elapsedTime = TimeOut - TimeIn;
                    return $"{(int)elapsedTime.TotalHours:00}:{elapsedTime.Minutes:00}";
                }
                
            }
            set { }
        }
        
        public bool IsLogged { get; set; }

        public TimeType EntryType { get; set; }



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

        public TimeEntry(DateTime timeIn, TimeType entryType)
        {
            TimeIn = timeIn;
            EntryType = entryType;
        }

    }
}