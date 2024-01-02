﻿//-----------------------------------------------------------------------
// <copyright file="StateManager.cs" company="Craig Reimer">
//     Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-02-2024</lastUpdate>
//-----------------------------------------------------------------------

namespace CMR.TimeClock.BL
{
    using System.Threading;

    public static class StateManager
    {
        // fields
        private static ClockState currentState;
        private static DateTime lastPunchIn;

        // static constructor
        static StateManager()
        {
            currentState = ClockState.ClockedOut; // Initial state: ClockedOut
        }

        // enums

        /// <summary>
        /// Types of clock state.
        /// </summary>
        public enum ClockState
        {
            /// <summary>
            /// User is punched in (on the clock).
            /// </summary>
            ClockedIn,

            /// <summary>
            /// User is punched out (off the clock).
            /// </summary>
            ClockedOut,
        }

        // properties

        /// <summary>
        /// Gets a value indicating whether the user is currently clocked in.
        /// </summary>
        public static bool IsClockedIn
        {
            get
            {
                return currentState == ClockState.ClockedIn;
            }
        }

        /// <summary>
        /// Gets the duration of the current shift.
        /// </summary>
        public static string CurrentShiftDuration
        {
            get
            {
                if (IsClockedIn)
                {
                    TimeSpan elapsedTime = DateTime.Now - lastPunchIn;
                    return $"{(int)elapsedTime.TotalHours:00}:{elapsedTime.Minutes:00}";
                }

                return string.Empty;
            }
    }

        // methods

        /// <summary>
        /// Creates a new time entry and adds it to the specified Entry Log.
        /// </summary>
        /// <param name="entryLog">The Entry Log to which the entry should be written.</param>
        /// <param name="isTraining">True if the work entry is 'Training' time. False indicates entry is 'Working' time.</param>
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

        /// <summary>
        /// Add a punch out time to the most recent entry in the specified Entry Log.
        /// </summary>
        /// <param name="entryLog">The Entry Log in which the 'In' punch should be found.</param>
        public static void ClockOut(EntryLog entryLog)
        {
            DateTime punchEvent = DateTime.Now; // get current time
            punchEvent = punchEvent.AddSeconds(-punchEvent.Second); // remove seconds

            // TODO: Abstract to own method
            // get the last entry
            TimeEntry? lastEntry = entryLog.LastOrDefault(entry => entry.TimeOut == DateTime.MinValue);

            if (lastEntry != null)
            {
                lastEntry.TimeOut = punchEvent; // set the time out
            }

            currentState = ClockState.ClockedOut; // change the punch state

            entryLog.LogChanged = true;  // flag the log as changed
        }

        /// <summary>
        /// Resets the clock state to 'ClockedOut'.
        /// </summary>
        public static void ResetClockState()
        {
            currentState = ClockState.ClockedOut; // set the punch state
        }
    }
}