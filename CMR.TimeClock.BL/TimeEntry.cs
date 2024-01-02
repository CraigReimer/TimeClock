//-----------------------------------------------------------------------
// <copyright file="TimeEntry.cs" company="Craig Reimer">
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
    public class TimeEntry
    {
        /// <summary>
        /// Types of time entries.
        /// </summary>
        public enum TimeType
        {
            Working,
            Training,
        }

        // fields
        private DateTime timeIn;
        private DateTime timeOut;


        // properties
        public int EntryID { get; set; }

        public DateTime TimeIn
        {
            get => this.timeIn;
            set
            {
                this.timeIn = value.AddSeconds(-value.Second);
            }
        }

        public DateTime TimeOut
        {
            get => this.timeOut;
            set
            {
                this.timeOut = value.AddSeconds(-value.Second);
            }
        }

        public string ElapsedTime
        {
            get
            {
                if (this.TimeOut == DateTime.MinValue || this.TimeOut < this.TimeIn) // TimeOut not set or invalid
                {
                    return string.Empty;
                }
                else
                {
                    TimeSpan elapsedTime = this.TimeOut - this.TimeIn;
                    return $"{(int)elapsedTime.TotalHours:00}:{elapsedTime.Minutes:00}";
                }
            }
        }

        public bool IsLogged { get; set; }

        public TimeType EntryType { get; set; }

        // constructors
        public TimeEntry()
        {
        }

        public TimeEntry(DateTime timeIn)
        {
            this.TimeIn = timeIn;
        }

        public TimeEntry (DateTime timeIn, DateTime timeOut)
        {
            this.TimeIn = timeIn;
            this.TimeOut = timeOut;
        }

        public TimeEntry(DateTime timeIn, TimeType entryType)
        {
            this.TimeIn = timeIn;
            this.EntryType = entryType;
        }

    }
}