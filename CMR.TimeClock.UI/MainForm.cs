/*
 * Title:           TimeClock
 * Description:     A simple time clock for logging in and out times
 * Author:          Craig Reimer
 * First Publish:   
 * Last Update:     
*/
using CMR.TimeClock.BL;

namespace CMR.TimeClock.UI
{
    public partial class MainForm : Form
    {
        // fields
        private EntryLog entryLog = new EntryLog();

        public MainForm()
        {
            InitializeComponent();

            entryLog.LoadTestData();
            RebindEntryLog();
        }


        // methods
        private void RebindEntryLog()
        {
            dgvEntryLog.DataSource = null;
            dgvEntryLog.DataSource = entryLog;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            TimeEntry timeEntry = new TimeEntry(DateTime.Now);
            entryLog.Add(timeEntry);
            RebindEntryLog();
        }
    }
}