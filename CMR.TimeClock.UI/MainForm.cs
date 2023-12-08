/*
 * Title:           TimeClock
 * Description:     A simple time clock for logging in and out times
 * Author:          Craig Reimer
 * First Publish:   
 * Last Update:     12-7-2023
*/
using CMR.TimeClock.BL;
using CMR.TimeClock.PL;

namespace CMR.TimeClock.UI
{
    public partial class MainForm : Form
    {
        // fields
        private EntryLog entryLog = new EntryLog();

        public MainForm()
        {
            InitializeComponent();

            try
            {
                Type type = typeof(EntryLog);
                entryLog = (EntryLog)DataAccess.LoadFromXML(type);
            }
            catch
            {
                //entryLog.LoadTestData();
            }


            RebindEntryLog();
        }


        // methods
        private void RebindEntryLog()
        {
            dgvEntryLog.DataSource = null; // unhook the list
            dgvEntryLog.DataSource = entryLog; // rebind the list

            dgvEntryLog.Columns["IsLogged"].HeaderText = "Logged";
            dgvEntryLog.Columns["_EntryType"].HeaderText = "Type";

            for (int i = 0; i < dgvEntryLog.ColumnCount; i++) // auto size columns
            {
                dgvEntryLog.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            TimeEntry timeEntry = new TimeEntry(DateTime.Now);

            if (rdoTraining.Checked)
            {
                timeEntry._EntryType = TimeEntry.EntryType.Training;
            }

            entryLog.Add(timeEntry);
            RebindEntryLog();
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            if (entryLog.Count > 0)
            {
                // get the last entry
                TimeEntry? lastEntry = entryLog.LastOrDefault(entry => entry.TimeOut == DateTime.MinValue);

                if (lastEntry != null)
                {
                    lastEntry.TimeOut = DateTime.Now;
                    RebindEntryLog();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            entryLog.SaveToXML();
        }

        private void dgvEntryLog_SelectionChanged(object sender, EventArgs e)
        {
            // TimeEntry? selectedEntry = dgvEntryLog.SelectedCells as TimeEntry;
        }
    }
}