
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
        public static void ClockIn(EntryLog entryLog)
        {
            currentState = ClockState.ClockedIn;
            
            entryLog.LogChanged = true;  // flag the change to be saved
        }

        public static void ClockOut(EntryLog entryLog)
        {
            currentState = ClockState.ClockedOut;

            entryLog.LogChanged = true;  // flag the change to be saved
        }

        public static void Reset()
        {
            currentState = ClockState.ClockedOut;
        }

    }
}
