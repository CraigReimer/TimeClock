using CMR.TimeClock.PL;

namespace CMR.TimeClock.BL
{
    public class EntryLog : List<TimeEntry>
    {
        // fields
        private string _currentFilePath = String.Empty;

        // properties
        public bool LogChanged { get; set; } = false; // false by default

        public string CurrentFilePath
        {
            get => _currentFilePath;
            private set
            {
                _currentFilePath = value;
                DataAccess.XMLFilePath = value;
            }
        }


        // constructors
        public EntryLog()
        {
            CurrentFilePath = String.Empty; // Initialize the file path, empty by default
        }


        // methods
        public void LoadTestData()  // No longer used, but here for testing if needed
        {
            TimeEntry timeEntry;

            timeEntry = new TimeEntry(DateTime.Parse("2020-10-02 10:00:00"), DateTime.Parse("2020-10-01 12:00:00"));
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

        public new void Remove(TimeEntry entry)
        {
            LogChanged = true; // flag the change to be saved
            
            base.Remove(entry); // Remove the entry from the list
        }

        public new void Clear()
        {
            LogChanged = false; // reset the flag
            CurrentFilePath = String.Empty; // reset the file path
            StateManager.Reset(); // reset the Clock state

            base.Clear(); // Clear the list
        }

        public bool HasValidPath()
        {
            if (!String.IsNullOrEmpty(CurrentFilePath) && Path.HasExtension(CurrentFilePath))
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
            CurrentFilePath = path; // Set the file path

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
