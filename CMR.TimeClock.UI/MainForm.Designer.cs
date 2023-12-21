namespace CMR.TimeClock.UI
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            btnClockIn = new Button();
            btnClockOut = new Button();
            btnDeleteEntry = new Button();
            lblEntryLog = new Label();
            rdoWorking = new RadioButton();
            rdoTraining = new RadioButton();
            grpControls = new GroupBox();
            lblTimeType = new Label();
            lblStatus = new Label();
            mnuMainMenu = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            mnuNewLog = new ToolStripMenuItem();
            mnuOpenLog = new ToolStripMenuItem();
            mnuSaveLogAs = new ToolStripMenuItem();
            mnuSaveLog = new ToolStripMenuItem();
            mnuExit = new ToolStripMenuItem();
            dgvEntryLog = new DataGridView();
            statusStrip1 = new StatusStrip();
            staFilePath = new ToolStripStatusLabel();
            staSpring = new ToolStripStatusLabel();
            staTime = new ToolStripStatusLabel();
            tmrDateAndTime = new System.Windows.Forms.Timer(components);
            grpControls.SuspendLayout();
            mnuMainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // btnClockIn
            // 
            btnClockIn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClockIn.Location = new Point(148, 104);
            btnClockIn.Name = "btnClockIn";
            btnClockIn.Size = new Size(340, 75);
            btnClockIn.TabIndex = 0;
            btnClockIn.Text = "Clock In";
            btnClockIn.UseVisualStyleBackColor = true;
            btnClockIn.Click += btnClockIn_Click;
            // 
            // btnClockOut
            // 
            btnClockOut.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnClockOut.Location = new Point(148, 200);
            btnClockOut.Name = "btnClockOut";
            btnClockOut.Size = new Size(340, 75);
            btnClockOut.TabIndex = 0;
            btnClockOut.Text = "Clock Out";
            btnClockOut.UseVisualStyleBackColor = true;
            btnClockOut.Click += btnClockOut_Click;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            btnDeleteEntry.Location = new Point(29, 104);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new Size(77, 171);
            btnDeleteEntry.TabIndex = 0;
            btnDeleteEntry.Text = "Delete Entry";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnDeleteEntry_Click;
            // 
            // lblEntryLog
            // 
            lblEntryLog.AutoSize = true;
            lblEntryLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblEntryLog.Location = new Point(36, 39);
            lblEntryLog.Name = "lblEntryLog";
            lblEntryLog.Size = new Size(76, 21);
            lblEntryLog.TabIndex = 2;
            lblEntryLog.Text = "Entry Log";
            // 
            // rdoWorking
            // 
            rdoWorking.AutoSize = true;
            rdoWorking.Checked = true;
            rdoWorking.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoWorking.Location = new Point(148, 34);
            rdoWorking.Name = "rdoWorking";
            rdoWorking.Size = new Size(128, 25);
            rdoWorking.TabIndex = 5;
            rdoWorking.TabStop = true;
            rdoWorking.Text = "Hours Worked";
            rdoWorking.UseVisualStyleBackColor = true;
            // 
            // rdoTraining
            // 
            rdoTraining.AutoSize = true;
            rdoTraining.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rdoTraining.Location = new Point(358, 34);
            rdoTraining.Name = "rdoTraining";
            rdoTraining.Size = new Size(130, 25);
            rdoTraining.TabIndex = 5;
            rdoTraining.Text = "Training Hours";
            rdoTraining.UseVisualStyleBackColor = true;
            // 
            // grpControls
            // 
            grpControls.Controls.Add(lblTimeType);
            grpControls.Controls.Add(btnDeleteEntry);
            grpControls.Controls.Add(btnClockOut);
            grpControls.Controls.Add(btnClockIn);
            grpControls.Controls.Add(rdoTraining);
            grpControls.Controls.Add(rdoWorking);
            grpControls.Location = new Point(36, 810);
            grpControls.Name = "grpControls";
            grpControls.Size = new Size(520, 305);
            grpControls.TabIndex = 8;
            grpControls.TabStop = false;
            grpControls.Text = "Entry Controls";
            // 
            // lblTimeType
            // 
            lblTimeType.AutoSize = true;
            lblTimeType.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            lblTimeType.Location = new Point(29, 36);
            lblTimeType.Name = "lblTimeType";
            lblTimeType.Size = new Size(83, 21);
            lblTimeType.TabIndex = 6;
            lblTimeType.Text = "Time Type:";
            // 
            // lblStatus
            // 
            lblStatus.BackColor = SystemColors.ControlDark;
            lblStatus.BorderStyle = BorderStyle.FixedSingle;
            lblStatus.Font = new Font("Century Gothic", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            lblStatus.ForeColor = Color.Lime;
            lblStatus.Location = new Point(36, 741);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(520, 66);
            lblStatus.TabIndex = 9;
            lblStatus.Text = "Clocked In";
            lblStatus.TextAlign = ContentAlignment.MiddleCenter;
            lblStatus.Visible = false;
            // 
            // mnuMainMenu
            // 
            mnuMainMenu.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            mnuMainMenu.Location = new Point(0, 0);
            mnuMainMenu.Name = "mnuMainMenu";
            mnuMainMenu.Size = new Size(594, 24);
            mnuMainMenu.TabIndex = 10;
            mnuMainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { mnuNewLog, mnuOpenLog, mnuSaveLogAs, mnuSaveLog, mnuExit });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // mnuNewLog
            // 
            mnuNewLog.Name = "mnuNewLog";
            mnuNewLog.ShortcutKeys = Keys.Control | Keys.N;
            mnuNewLog.Size = new Size(186, 22);
            mnuNewLog.Text = "&New Log...";
            mnuNewLog.Click += mnuNewLog_Click;
            // 
            // mnuOpenLog
            // 
            mnuOpenLog.Name = "mnuOpenLog";
            mnuOpenLog.ShortcutKeys = Keys.Control | Keys.O;
            mnuOpenLog.Size = new Size(186, 22);
            mnuOpenLog.Text = "&Open Log...";
            mnuOpenLog.Click += mnuOpenLog_Click;
            // 
            // mnuSaveLogAs
            // 
            mnuSaveLogAs.Name = "mnuSaveLogAs";
            mnuSaveLogAs.ShortcutKeys = Keys.Control | Keys.Alt | Keys.S;
            mnuSaveLogAs.Size = new Size(186, 22);
            mnuSaveLogAs.Text = "Save &As...";
            mnuSaveLogAs.Click += mnuSaveLogAs_Click;
            // 
            // mnuSaveLog
            // 
            mnuSaveLog.Name = "mnuSaveLog";
            mnuSaveLog.ShortcutKeys = Keys.Control | Keys.S;
            mnuSaveLog.Size = new Size(186, 22);
            mnuSaveLog.Text = "Save";
            mnuSaveLog.Click += mnuSaveLog_Click;
            // 
            // mnuExit
            // 
            mnuExit.Name = "mnuExit";
            mnuExit.Size = new Size(186, 22);
            mnuExit.Text = "E&xit";
            mnuExit.Click += mnuExit_Click;
            // 
            // dgvEntryLog
            // 
            dgvEntryLog.AllowUserToAddRows = false;
            dgvEntryLog.AllowUserToDeleteRows = false;
            dgvEntryLog.AllowUserToResizeColumns = false;
            dgvEntryLog.AllowUserToResizeRows = false;
            dgvEntryLog.CausesValidation = false;
            dgvEntryLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntryLog.EditMode = DataGridViewEditMode.EditOnF2;
            dgvEntryLog.Location = new Point(36, 63);
            dgvEntryLog.Name = "dgvEntryLog";
            dgvEntryLog.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dgvEntryLog.RowTemplate.Height = 25;
            dgvEntryLog.Size = new Size(520, 675);
            dgvEntryLog.TabIndex = 11;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { staFilePath, staSpring, staTime });
            statusStrip1.Location = new Point(0, 1143);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(594, 22);
            statusStrip1.TabIndex = 12;
            statusStrip1.Text = "statusStrip1";
            // 
            // staFilePath
            // 
            staFilePath.Name = "staFilePath";
            staFilePath.Size = new Size(35, 17);
            staFilePath.Text = "PATH";
            // 
            // staSpring
            // 
            staSpring.Name = "staSpring";
            staSpring.Size = new Size(511, 17);
            staSpring.Spring = true;
            // 
            // staTime
            // 
            staTime.Name = "staTime";
            staTime.Size = new Size(33, 17);
            staTime.Text = "TIME";
            // 
            // tmrDateAndTime
            // 
            tmrDateAndTime.Enabled = true;
            tmrDateAndTime.Tick += tmrDateAndTime_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(594, 1165);
            Controls.Add(statusStrip1);
            Controls.Add(dgvEntryLog);
            Controls.Add(lblStatus);
            Controls.Add(grpControls);
            Controls.Add(lblEntryLog);
            Controls.Add(mnuMainMenu);
            MainMenuStrip = mnuMainMenu;
            Name = "MainForm";
            Text = "Time Clock";
            FormClosing += MainForm_FormClosing;
            grpControls.ResumeLayout(false);
            grpControls.PerformLayout();
            mnuMainMenu.ResumeLayout(false);
            mnuMainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClockIn;
        private Button btnClockOut;
        private Button btnDeleteEntry;
        private Label lblEntryLog;
        private RadioButton rdoWorking;
        private RadioButton rdoTraining;
        private GroupBox grpControls;
        private Label lblTimeType;
        private Label lblStatus;
        private MenuStrip mnuMainMenu;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem mnuNewLog;
        private ToolStripMenuItem mnuOpenLog;
        private ToolStripMenuItem mnuSaveLogAs;
        private ToolStripMenuItem mnuSaveLog;
        private ToolStripMenuItem mnuExit;
        private DataGridView dgvEntryLog;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel staFilePath;
        private ToolStripStatusLabel staSpring;
        private ToolStripStatusLabel staTime;
        private System.Windows.Forms.Timer tmrDateAndTime;
    }
}