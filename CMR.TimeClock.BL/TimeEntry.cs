//-----------------------------------------------------------------------
// <copyright file="TimeEntry.cs" company="Craig Reimer">
//     Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-10-2024</lastUpdate>
//-----------------------------------------------------------------------

namespace CMR.TimeClock.BL
{
    using System.Xml.Serialization;
    using Newtonsoft.Json;

    /// <summary>
    /// An object that represents a time entry (hours worked).
    /// </summary>
    [JsonObject]
    public class TimeEntry
    {
        // FIELDS
        private DateTime timeIn;
        private DateTime timeOut;

        // CONSTRUCTORS

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeEntry"/> class.
        /// </summary>
        public TimeEntry()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeEntry"/> class.
        /// </summary>
        /// <param name="timeIn">The start time of the shift.</param>
        /// <param name="entryType">The type of time entry.</param>
        public TimeEntry(DateTime timeIn, TimeType entryType)
        {
            this.TimeIn = timeIn;
            this.EntryType = entryType;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="TimeEntry"/> class.
        /// Only used by the EntryLog.LoadTestData() method.
        /// </summary>
        /// <param name="timeIn">The start time of the shift.</param>
        /// <param name="timeOut">The end time of the shift.</param>
        /// /// <param name="entryType">The type of time entry.</param>
        public TimeEntry(DateTime timeIn, DateTime timeOut, TimeType entryType)
        {
            this.TimeIn = timeIn;
            this.TimeOut = timeOut;
        }

        // ENUMS

        /// <summary>
        /// Types of time entries.
        /// </summary>
        public enum TimeType
        {
            /// <summary>
            /// An entry that represents 'Working' hours.
            /// </summary>
            Working,

            /// <summary>
            /// An entry that represents 'Training' hours.
            /// </summary>
            Training,
        }

        // PROPERTIES

        /// <summary>
        /// Gets or sets the Entry ID.
        /// </summary>
        public int EntryID { get; set; }

        /// <summary>
        /// Gets or sets the 'Time In' punch for the entry.
        /// </summary>
        public DateTime TimeIn
        {
            get => this.timeIn;
            set
            {
                this.timeIn = value;
            }
        }

        /// <summary>
        /// Gets or sets the 'Time Out' punch for the entry.
        /// </summary>
        public DateTime TimeOut
        {
            get => this.timeOut;
            set
            {
                this.timeOut = value;
            }
        }

        /// <summary>
        /// Gets the elapsed time for the current entry.
        /// </summary>
        [JsonIgnore]
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

        /// <summary>
        /// Gets or sets a value indicating whether the entry has been logged.
        /// </summary>
        public bool IsLogged { get; set; }

        /// <summary>
        /// Gets or sets the type of time entry (working or training).
        /// </summary>
        public TimeType EntryType { get; set; }
    }
}