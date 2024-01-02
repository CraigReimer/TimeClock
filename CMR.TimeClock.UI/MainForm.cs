//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Craig Reimer">
//     Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-02-2024</lastUpdate>
//-----------------------------------------------------------------------

namespace CMR.TimeClock.UI
{
    using System.Windows.Forms;
    using CMR.TimeClock.BL;

    public partial class MainForm : Form
    {
        // fields
        private EntryLog entryLog = new ();

        // constructors
        public MainForm()
        {
            this.InitializeComponent();

            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(200, 50);

            this.tmrDateAndTime_Tick(this, EventArgs.Empty);

            this.UpdateStatusStrip();
        }

        // enums

        /// <summary>
        /// Types of user choice regarding unsaved changes.
        /// </summary>
        public enum UnsavedChangesAction
        {
            SaveChanges,
            DiscardChanges,
            CancelOperation,
            NoChanges,
        }

        // methods
        private void RebindEntryLog()
        {
            this.dgvEntryLog.DataSource = null; // unhook the list
            this.dgvEntryLog.DataSource = this.entryLog; // rebind the list

            // format the grid
            for (int i = 0; i < this.dgvEntryLog.ColumnCount; i++)
            {
                // auto size columns
                this.dgvEntryLog.Columns[i].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }

            // set column headers
            this.dgvEntryLog.Columns["EntryID"].HeaderText = "ID";
            this.dgvEntryLog.Columns["TimeIn"].HeaderText = "Time In";
            this.dgvEntryLog.Columns["TimeOut"].HeaderText = "Time Out";
            this.dgvEntryLog.Columns["ElapsedTime"].HeaderText = "Duration";
            this.dgvEntryLog.Columns["IsLogged"].HeaderText = "Logged";
            this.dgvEntryLog.Columns["EntryType"].HeaderText = "Time Type";

            this.dgvEntryLog.RowHeadersWidth = 35;
        }

        private void btnClockIn_Click(object sender, EventArgs e)
        {
            if (StateManager.IsClockedIn)
            {
                return; // already clocked in
            }

            if (this.rdoTraining.Checked)
            {
                StateManager.ClockIn(this.entryLog, true);
            }
            else
            {
                StateManager.ClockIn(this.entryLog);
            }

            this.RebindEntryLog();

            this.lblStatus.Visible = true;
        }

        private void btnClockOut_Click(object sender, EventArgs e)
        {
            if (!StateManager.IsClockedIn)
            {
                return; // not clocked in
            }

            StateManager.ClockOut(this.entryLog);

            this.RebindEntryLog();

            this.lblStatus.Visible = false;
        }

        private void btnDeleteEntry_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete this entry?", "Confirm Delete", MessageBoxButtons.OKCancel);

            if (dialogResult != DialogResult.OK)
            {
                return;
            }

            if (this.dgvEntryLog.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = this.dgvEntryLog.SelectedRows[0]; // Get the first selected row

                // Access the TimeEntry object stored in the row's DataBoundItem
                if (selectedRow.DataBoundItem is TimeEntry selectedEntry)
                {
                    this.entryLog.Remove(selectedEntry);
                    this.RebindEntryLog();
                }
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ManageUnsavedChanges();
        }

        private void mnuNewLog_Click(object sender, EventArgs e)
        {
            if (this.ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation)
            {
                return; // user cancelled
            }

            this.entryLog.Clear(); // clear the log contents

            this.RebindEntryLog();
            this.UpdateStatusStrip();
        }

        private void mnuOpenLog_Click(object sender, EventArgs e)
        {
            if (this.ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation)
            {
                return; // user cancelled
            }

            OpenFileDialog dlgOpen = new OpenFileDialog
            {
                Filter = "XML File|*.xml",
            };

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                this.entryLog.Clear(); // clear the log contents

                try
                {
                    this.entryLog.LoadFromXML(dlgOpen.FileName); // load the new log
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.RebindEntryLog(); // rebind the log

                this.UpdateStatusStrip();
            }
        }

        private void mnuSaveLog_Click(object sender, EventArgs e)
        {
            // check if file has valid path
            if (!this.entryLog.HasValidPath())
            {
                // File has no valid path, send to SaveAs
                this.mnuSaveLogAs_Click(sender, e);
                return;
            }

            try
            {
                this.entryLog.SaveToXML();
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
                Filter = "XML File|*.xml",
            };

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.entryLog.SaveAsXML(dlgSave.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.UpdateStatusStrip();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (this.ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation)
            {
                return; // user cancelled
            }

            this.Close();
        }

        private void tmrDateAndTime_Tick(object sender, EventArgs e)
        {
            // display date and time in status strip
            this.staTime.Text = DateTime.Now.ToString("h:mm:ss tt");

            // display elapsed shift time if clocked in
            if (StateManager.IsClockedIn)
            {
                this.lblStatus.Text = $"Clocked In - [{StateManager.CurrentShiftDuration}]";
            }
        }

        private void UpdateStatusStrip()
        {
            // display file path or "--Untitled--" if no path is set
            this.staFilePath.Text = "File: " + (this.entryLog.HasValidPath() ? this.entryLog.CurrentFilePath : "--Untitled--");
        }

        private UnsavedChangesAction ManageUnsavedChanges()
        {
            if (this.entryLog.LogChanged)
            {
                DialogResult result = MessageBox.Show(this, "This log has unsaved changes.\nDo you want to save the changes?", "Save", MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    // user elects to save
                    this.mnuSaveLog_Click(this, new EventArgs());
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
            this.entryLog.LogChanged = true;
        }
    }
}