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


        // properties
        public int EntryID { get; set; }

        public DateTime TimeIn { get; set; }
        
        public DateTime TimeOut { get; set; }

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

    }
}