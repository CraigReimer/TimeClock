//-----------------------------------------------------------------------
// <copyright file="MainForm.cs" company="Craig Reimer">
//     Copyright (c) Craig Reimer. All rights reserved.
// </copyright>
// <title>TimeClock</title>
// <summary>A simple time clock for logging in and out times.</summary>
// <author>Craig Reimer</author>
// <firstPublish>12-7-2023</firstPublish>
// <lastUpdate>01-10-2024</lastUpdate>
//-----------------------------------------------------------------------

namespace CMR.TimeClock.UI
{
    using System.Windows.Forms;
    using CMR.TimeClock.BL;

    /// <summary>
    /// The primary UI for the application.
    /// </summary>
    public partial class MainForm : Form
    {
        // fields
        private EntryLog entryLog = new ();

        // constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            this.InitializeComponent();

            // set the initial location
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new System.Drawing.Point(200, 50);

            this.tmrDateAndTime_Tick(this, EventArgs.Empty); // update the clock

            this.UpdateStatusStrip(); // update the status strip
        }

        // enums

        /// <summary>
        /// Types of user choice regarding unsaved changes.
        /// </summary>
        public enum UnsavedChangesAction
        {
            /// <summary>
            /// The user elected to save changes.
            /// </summary>
            SaveChanges,

            /// <summary>
            /// The user elected to discard changes.
            /// </summary>
            DiscardChanges,

            /// <summary>
            /// The user elected to cancel the operation.
            /// </summary>
            CancelOperation,

            /// <summary>
            /// There are no unsaved changes.
            /// </summary>
            NoChanges,
        }

        // methods

        /// <summary>
        /// Rebinds the data source of the <see cref="dgvEntryLog"/>. Formats the column headers.
        /// </summary>
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

        /// <summary>
        /// Clocks in the user.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
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

        /// <summary>
        /// Clocks out the user.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
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

        /// <summary>
        /// Deletes the selected entry from the log.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
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

        /// <summary>
        /// Resets the entry log to an empty state.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
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

        /// <summary>
        /// Opens an existing log via a dialog.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
        private void mnuOpenLog_Click(object sender, EventArgs e)
        {
            if (this.ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation)
            {
                return; // user cancelled
            }

            OpenFileDialog dlgOpen = new OpenFileDialog
            {
                Filter = "JSON File|*.json|XML File|*.xml",
            };

            if (dlgOpen.ShowDialog() == DialogResult.OK)
            {
                this.entryLog.Clear(); // clear the log contents

                try
                {
                    if (Path.GetExtension(dlgOpen.FileName) == ".json")
                    {
                        this.entryLog.LoadFromJSON(dlgOpen.FileName); // load the new log
                    }

                    if (Path.GetExtension(dlgOpen.FileName) == ".xml")
                    {
                        this.entryLog.LoadFromXML(dlgOpen.FileName); // load the new log
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                this.RebindEntryLog(); // rebind the log

                this.UpdateStatusStrip();
            }
        }

        /// <summary>
        /// Saves changes to the entry log.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
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
                this.entryLog.SaveToJSON();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.UpdateStatusStrip();
        }

        /// <summary>
        /// Opens a SaveAs dialog to save the entry log.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
        private void mnuSaveLogAs_Click(object sender, EventArgs e)
        {
            SaveFileDialog dlgSave = new SaveFileDialog
            {
                Filter = "JSON File|*.json", // TODO: Return to XML if not using JSON
            };

            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    this.entryLog.SaveAs(dlgSave.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            this.UpdateStatusStrip();
        }

        /// <summary>
        /// Exits the application.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
        private void mnuExit_Click(object sender, EventArgs e)
        {
            if (this.ManageUnsavedChanges() == UnsavedChangesAction.CancelOperation)
            {
                return; // user cancelled
            }

            this.Close();
        }

        /// <summary>
        /// Updates the clock in the status strip. Updates shift duration if 'Clocked in.' Updates every second.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
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

        /// <summary>
        /// Updates the status strips, displaying the current file path and the last saved time.
        /// </summary>
        private void UpdateStatusStrip()
        {
            // display file path or "--Untitled--" if no path is set
            this.staFilePath.Text = "File: " + (this.entryLog.HasValidPath() ? this.entryLog.CurrentFilePath : "--Untitled--");

            // display last saved time
            if (this.entryLog.LastSaved == DateTime.MinValue)
            {
                this.staLastSaved.Text = "Last Saved: --Never Saved--";
            }
            else
            {
                this.staLastSaved.Text = "Last Saved: " + this.entryLog.LastSaved.ToString("MM-dd-yyyy HH:mm:ss");
            }
        }

        /// <summary>
        /// Creates a dialog to prompt the user to manage unsaved changes.
        /// </summary>
        /// <returns>The user's election for what to do with changes.</returns>
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

        /// <summary>
        /// Flags the log as changed when a cell is changed.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
        private void dgvEntryLog_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            this.entryLog.LogChanged = true; // flag log as changed
        }

        /// <summary>
        /// Actions to take when the form is closing.
        /// </summary>
        /// <param name="sender">The source of the call.</param>
        /// <param name="e">Event Arguments.</param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.ManageUnsavedChanges(); // check for unsaved changes before closing
        }
    }
}