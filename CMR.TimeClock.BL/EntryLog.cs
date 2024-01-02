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

    public class EntryLog : List<TimeEntry>
    {
        // fields
        private string currentFilePath = string.Empty;

        // constructors
        public EntryLog()
        {
            this.CurrentFilePath = string.Empty; // Initialize the file path, empty by default
        }

        // properties
        public bool LogChanged { get; set; } = false; // false by default

        public string CurrentFilePath
        {
            get => this.currentFilePath;
            private set
            {
                this.currentFilePath = value;
                DataAccess.XMLFilePath = value;
            }
        }

        // methods
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

        public new void Add(TimeEntry entry)
        {
            // TODO: remove if using DB
            entry.EntryID = this.Count + 1; // Assign a semi-unique ID based on list size 

            this.LogChanged = true; // flag the change to be saved

            base.Add(entry); // Add the entry to the list
        }

        public new void Remove(TimeEntry entry)
        {
            this.LogChanged = true; // flag the change to be saved

            base.Remove(entry); // Remove the entry from the list
        }

        public new void Clear()
        {
            this.LogChanged = false; // reset the flag
            this.CurrentFilePath = string.Empty; // reset the file path
            StateManager.ResetClockState(); // reset the default Clock state

            base.Clear(); // Clear the list
        }

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

        public void SaveAsXML(string path)
        {
            this.CurrentFilePath = path;

            this.SaveToXML();
        }

        public void SaveToXML()
        {
            this.LogChanged = false; // reset the flag

            DataAccess.SaveToXML(typeof(EntryLog), this);
        }

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
