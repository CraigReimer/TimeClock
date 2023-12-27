
using System.Threading;

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
        private static DateTime lastPunchIn;


        // properties
        public static bool IsClockedIn
        {
            get
            {
                return currentState == ClockState.ClockedIn;
            }
        }

        public static string CurrentShiftDuration
        {
            get
            {
                if (IsClockedIn)
                {
                    TimeSpan elapsedTime = DateTime.Now - lastPunchIn;
                    return $"{(int)elapsedTime.TotalHours:00}:{elapsedTime.Minutes:00}";
                }

                return String.Empty;
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
            DateTime punchEvent = DateTime.Now; // get current time
            punchEvent = punchEvent.AddSeconds(-punchEvent.Second); // remove seconds

            TimeEntry timeEntry; // create time entry

            if (isTraining) // check if training
            {
                timeEntry = new TimeEntry(punchEvent, TimeEntry.TimeType.Training); // create training time entry
            }
            else
            {
                timeEntry = new TimeEntry(punchEvent); // create time entry
            }

            entryLog.Add(timeEntry); // add time entry to log

            currentState = ClockState.ClockedIn; // change the punch state

            entryLog.LogChanged = true;  // flag the log as changed

            lastPunchIn = punchEvent; // set the last punch in
        }

        public static void ClockOut(EntryLog entryLog)
        {
            DateTime punchEvent = DateTime.Now; // get current time
            punchEvent = punchEvent.AddSeconds(-punchEvent.Second); // remove seconds

            // get the last entry
            TimeEntry? lastEntry = entryLog.LastOrDefault(entry => entry.TimeOut == DateTime.MinValue);

            if (lastEntry != null)
            {
                lastEntry.TimeOut = punchEvent; // set the time out
            }

            currentState = ClockState.ClockedOut; // change the punch state

            entryLog.LogChanged = true;  // flag the change to be saved
        }

        public static void ResetClockState()
        {
            currentState = ClockState.ClockedOut; // change the punch state
        }

    }
}
