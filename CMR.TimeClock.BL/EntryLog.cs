//-----------------------------------------------------------------------
// <copyright file="EntryLog.cs" company="Craig Reimer">
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
    using CMR.TimeClock.PL;

    /// <summary>
    /// Entry Log. A list of time entries.
    /// </summary>
    public class EntryLog : List<TimeEntry>
    {
        // fields
        private string currentFilePath = string.Empty;

        // constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="EntryLog"/> class.
        /// </summary>
        public EntryLog()
        {
            this.CurrentFilePath = string.Empty; // Initialize the file path, empty by default
        }

        // properties

        /// <summary>
        /// Gets or sets a value indicating whether the log has been changed and needs to be saved.
        /// </summary>
        public bool LogChanged { get; set; } = false; // false by default

        /// <summary>
        /// Gets the current file path.
        /// </summary>
        public string CurrentFilePath
        {
            get => this.currentFilePath;
            private set
            {
                this.currentFilePath = value; // Set the local file path
                DataAccess.XMLFilePath = value; // Set the XML file path
            }
        }

        // methods

        /// <summary>
        /// A method to load dummy data for testing or development purposes.
        /// </summary>
        public void LoadTestData() // No longer used, but here for testing if needed
        {
            TimeEntry timeEntry;

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-02 10:00:00"), DateTime.Parse("2020-10-01 12:00:00"));
            this.Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-02 12:00:00"), DateTime.Parse("2020-10-02 13:00:00"));
            this.Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-03 11:00:00"), DateTime.Parse("2020-10-03 14:00:00"));
            this.Add(timeEntry);
        }

        /// <summary>
        /// Adds a time entry to the list.
        /// </summary>
        /// <param name="entry">The entry to add to the list.</param>
        public new void Add(TimeEntry entry)
        {
            // TODO: remove if using DB
            entry.EntryID = this.Count + 1; // Assign a semi-unique ID based on current list size

            this.LogChanged = true; // flag the change to be saved

            base.Add(entry); // Add the entry to the list
        }

        /// <summary>
        /// Removes a time entry from the list.
        /// </summary>
        /// <param name="entry">The entry to be removed.</param>
        public new void Remove(TimeEntry entry)
        {
            this.LogChanged = true; // flag the change to be saved

            base.Remove(entry); // Remove the entry from the list
        }

        /// <summary>
        /// Empty the current list.
        /// </summary>
        public new void Clear()
        {
            this.LogChanged = false; // reset the flag
            this.CurrentFilePath = string.Empty; // reset the file path
            StateManager.ResetClockState(); // reset the default Clock state

            base.Clear(); // Clear the list
        }

        /// <summary>
        /// Checks if the current file path is set and valid.
        /// </summary>
        /// <returns>True if file path is valid.</returns>
        public bool HasValidPath()
        {
            if (!string.IsNullOrEmpty(this.CurrentFilePath) && Path.HasExtension(this.CurrentFilePath))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Sets the file path and redirects to SaveToXML() to save the log.
        /// </summary>
        /// <param name="path">The path to which the log should be saved.</param>
        public void SaveAsXML(string path)
        {
            this.CurrentFilePath = path;

            this.SaveToXML();
        }

        /// <summary>
        /// Saves the log to the current file path.
        /// </summary>
        public void SaveToXML()
        {
            this.LogChanged = false; // reset the flag

            DataAccess.SaveToXML(typeof(EntryLog), this);
        }

        /// <summary>
        /// Loads the log from the current file path.
        /// </summary>
        /// <param name="path">The path from which the log should be loaded.</param>
        /// <exception cref="Exception">XML Loading error.</exception>
        public void LoadFromXML(string path)
        {
            this.CurrentFilePath = path; // Set the file path

            try
            {
                object obj = DataAccess.LoadFromXML(typeof(EntryLog));

                if (obj is EntryLog loadedEntryLog)
                {
                    foreach (TimeEntry entry in loadedEntryLog) // Add the retrieved entries to the current log
                    {
                        this.Add(entry);
                    }
                }
                else
                {
                    throw new Exception("Error loading from XML: incorrect object type");
                }

                this.LogChanged = false; // reset the flag
            }
            catch (Exception ex)
            {
                this.LogChanged = true; // set flag if exception occurs
                throw new Exception("Error loading from XML: " + ex.Message);
            }
        }
    }
}