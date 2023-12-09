
namespace CMR.TimeClock.BL
{
    public static class StateManager
    {
        public enum ClockState
        {
            ClockedIn,
            ClockedOut
        }

        private static ClockState currentState;

        static StateManager()
        {
            currentState = ClockState.ClockedOut; // Initial state: ClockedOut
        }

        public static void ClockIn()
        {
            currentState = ClockState.ClockedIn;
        }

        public static void ClockOut()
        {
            currentState = ClockState.ClockedOut;
        }

        public static bool IsClockedIn()
        {
            return currentState == ClockState.ClockedIn;
        }
    }
}
