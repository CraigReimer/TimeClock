/*
 * Title:           TimeClock
 * Description:     A simple time clock for logging in and out times
 * Author:          Craig Reimer
 * First Publish:   12-7-2023
 * Last Update:     12-21-2023
*/


using CMR.TimeClock.BL;
using CMR.TimeClock.PL;
using System.Windows.Forms;

namespace CMR.TimeClock.UI
{
    public partial class MainForm : Form
    {
        // enums
        public enum UnsavedChangesAction
        {
            SaveChanges,
            DiscardChanges,
            CancelOperation,
            NoChanges
        }

        // fields
        public EntryLog entryLog = new();


        public MainForm()
        {
            InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(200, 50);

            tmrDateAndTime_Tick(this, EventArgs.Empty);

            UpdateStatusStrip();
        }


        // methods
        private void RebindEntryLog()
        {
            dgvEntryLog.DataSource = null; // unhook the list
            dgvEntryLog.DataSource = entryLog; // rebind the list


            // format the grid
            for (int i = 0; i < dgvEntryLog.ColumnCount; i++)
            {
                // auto size columns
                dgvEntryLog.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // set column headers
            dgvEntryLog.Columns["EntryID"].HeaderText = "ID";
            dgvEntryLog.Columns["TimeIn"].HeaderText = "Time In";
            dgvEntryLog.Columns["TimeOut"].HeaderText = "Time Out";
            dgvEntryLog.Columns["ElapsedTime"].HeaderText = "Duration";
            dgvEntryLog.Columns["IsLogged"].HeaderText = "Logged";
            dgvEntryLog.Columns["EntryType"].HeaderText = "Time Type";

            dgvEntryLog.RowHeadersWidth = 35;

        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            if (StateManager.IsClockedIn) return; // already clocked in

            if (rdoTraining.Checked)
            {
                StateManager.ClockIn(entryLog, true);
            }
            else
            {
                StateManager.ClockIn(entryLog);
            }

            RebindEntryLog();

            lblStatus.Visible = true;

        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            if (!StateManager.IsClockedIn) return; // not clocked in

            StateManager.ClockOut(entryLog);

            RebindEntryLog();

            lblStatus.Visible = false;
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Delete", MessageBoxButtons.OKCancel);

            if (dialogResult != DialogResult.OK) return;

            if (dgvEntryLog.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvEntryLog.SelectedRows[0]; // Get the first selected row

                // Access the TimeEntry object stored in the row's DataBoundItem
                if (selectedRow.DataBoundItem is TimeEntry selectedEntry)
                {
                    entryLog.Remove(selectedEntry);
                    RebindEntryLog();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ManageUnsavedChanges();
        }

        private void mnuNewLog_Click(object sender, EventArgs e)
        {
            if (ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation) return; // user cancelled

            entryLog.Clear(); // clear the log contents

            RebindEntryLog();
            UpdateStatusStrip();
        }

        private void mnuOpenLog_Click(object sender, EventArgs e)
        {
            if (ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation) return; // user cancelled

            OpenFileDialog dlgOpen = new OpenFileDialog
            {
                Filter = "XML File|*.xml"
            };

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {                
                entryLog.Clear(); // clear the log contents

                try
                {
                    entryLog.LoadFromXML(dlgOpen.FileName); // load the new log
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                RebindEntryLog(); // rebind the log
                UpdateStatusStrip();
            }
        }

        private void mnuSaveLog_Click(object sender, EventArgs e)
        {
            // check if file has path
            if (!entryLog.HasPath())
            {
                // File has no path, send to SaveAs
                mnuSaveLogAs_Click(sender, e); return;
            }

            try
            {
                entryLog.SaveToXML();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void mnuSaveLogAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog
            {
                Filter = "XML File|*.xml"
            };

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    entryLog.SaveAsXML(dlgSave.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            UpdateStatusStrip();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation) return; // user cancelled

            this.Close();
        }


        private void tmrDateAndTime_Tick(object sender, EventArgs e)
        {
            // display date and time in status strip
            staTime.Text = DateTime.Now.ToString("h:mm:ss tt");

            // display elapsed shift time if clocked in
            if (StateManager.IsClockedIn)
            {
                lblStatus.Text = $"Clocked In - [{StateManager.CurrentShiftDuration}]";
            }

        }

        private void UpdateStatusStrip()
        {
            // display file path or "--Untitled--" if no path is set
            staFilePath.Text = "File: " + (string.IsNullOrEmpty(entryLog.CurrentFilePath) ? "--Untitled--" : entryLog.CurrentFilePath);
        }

        private UnsavedChangesAction ManageUnsavedChanges()
        {
            if (entryLog.LogChanged)
            {
                DialogResult result = MessageBox.Show(this, "This log has unsaved changes.\nDo you want to save the changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    // user elects to save
                    mnuSaveLog_Click(this, new EventArgs());
                    return UnsavedChangesAction.SaveChanges;
                }
                else if (result == DialogResult.Cancel)
                {
                    // user elects to cancel action, changes persist
                    return UnsavedChangesAction.CancelOperation;
                }
                else
                {
                    // user elects to disregard changes
                    return UnsavedChangesAction.DiscardChanges;
                }
            }

            // no unsaved changes found, do nothing
            return UnsavedChangesAction.NoChanges;
        }

        private void dgvEntryLog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            entryLog.LogChanged = true;
        }
    }
}