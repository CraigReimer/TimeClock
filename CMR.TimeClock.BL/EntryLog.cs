﻿using CMR.TimeClock.PL;

namespace CMR.TimeClock.BL
{
    public class EntryLog : List<TimeEntry>
    {
        
        // properties
        public bool LogChanged { get; set; } = false; // false by default

        public string CurrentFilePath
        {
            get => DataAccess.XMLFilePath;
            set
            {
                DataAccess.XMLFilePath = value;
            }
        }


        // constructors
        public EntryLog()
        {
            
        }


        // methods
        public void LoadTestData()  // No longer used, but here for testing if needed
        {
            TimeEntry timeEntry;

            timeEntry = new TimeEntry(new DateTime(2020, 10, 01, 10, 0, 0), DateTime.Parse("2020-10-01 12:00:00"));
            Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-02 12:00:00"), DateTime.Parse("2020-10-02 13:00:00"));
            Add(timeEntry);

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-03 11:00:00"), DateTime.Parse("2020-10-03 14:00:00"));
            Add(timeEntry);
        }

        public new void Add(TimeEntry entry)
        {
            // TODO: remove if using DB
            entry.EntryID = this.Count + 1; // Assign a semi-unique ID based on list size 

            LogChanged = true; // flag the change to be saved

            base.Add(entry); // Add the entry to the list
        }

        public new void Clear()
        {
            LogChanged = false; // reset the flag
            CurrentFilePath = String.Empty; // reset the file path
            StateManager.Reset(); // reset the Clock state

            base.Clear(); // Clear the list
        }

        public bool HasPath()
        {
            if (String.IsNullOrEmpty(CurrentFilePath))
            {
                return false;
            }

            if (Path.HasExtension(CurrentFilePath))
            {
                return true;
            }

            return false;
        }

        public void SaveAsXML(string path)
        {
            CurrentFilePath = path;
            
            SaveToXML();
        }

        public void SaveToXML()
        {
            LogChanged = false; // reset the flag

            DataAccess.SaveToXML(typeof(EntryLog), this);
        }

        public void LoadFromXML(string path)
        {
            CurrentFilePath = path;

            try
            {
                object obj = DataAccess.LoadFromXML(typeof(EntryLog));

                if (obj is EntryLog loadedEntryLog)
                {
                    foreach (TimeEntry entry in loadedEntryLog) // Add the loaded entries to the current log
                    {
                        this.Add(entry);
                    }
                }
                else
                {

                    throw new Exception("Error loading from XML: incorrect object type");
                }

                LogChanged = false; // reset the flag
            }
            catch (Exception ex)
            {
                LogChanged = true; // set flag if exception occurs
                throw new Exception("Error loading from XML: " + ex.Message);
            }
        }
    }
}
