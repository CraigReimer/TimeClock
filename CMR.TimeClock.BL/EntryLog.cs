using CMR.TimeClock.PL;

namespace CMR.TimeClock.BL
{
    public class EntryLog : List<TimeEntry>
    {
        // constructors
        public EntryLog()
        {
            DataAccess.XMLFilePath = "EntryLog.xml";
        }


        // methods
        public void LoadTestData()  // TODO: DELETE after File IO for Log files. Create a test log before deleting
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

            base.Add(entry); // Add the entry to the list
        }

        public void SaveToXML()
        {
            DataAccess.SaveToXML(typeof(EntryLog), this);
        }
    }
}
