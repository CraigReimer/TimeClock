
namespace CMR.TimeClock.BL
{
    public static class StateManager
    {
        // define clock states
        public enum ClockState
        {
            ClockedIn,
            ClockedOut
        }

        // fields
        private static ClockState currentState;


        // properties
        public static bool IsClockedIn
        {
            get
            {
                return currentState == ClockState.ClockedIn;
            }
        }





        // static constructor
        static StateManager()
        {
            currentState = ClockState.ClockedOut; // Initial state: ClockedOut
        }


        // methods
        public static void ClockIn(EntryLog entryLog, bool isTraining = false)
        {
            TimeEntry timeEntry;

            if (isTraining)
            {
                timeEntry = new TimeEntry(DateTime.Now, TimeEntry.TimeType.Training);
            }
            else
            {
                timeEntry = new TimeEntry(DateTime.Now);
            }

            entryLog.Add(timeEntry); // add time entry

            currentState = ClockState.ClockedIn; // change punch state

            entryLog.LogChanged = true;  // flag the log as changed
        }

        public static void ClockOut(EntryLog entryLog)
        {
            // get the last entry
            TimeEntry? lastEntry = entryLog.LastOrDefault(entry => entry.TimeOut == DateTime.MinValue);

            if (lastEntry != null)
            {
                lastEntry.TimeOut = DateTime.Now;

            }

            currentState = ClockState.ClockedOut;

            entryLog.LogChanged = true;  // flag the change to be saved
        }

        public static void Reset()
        {
            currentState = ClockState.ClockedOut;
        }

    }
}
