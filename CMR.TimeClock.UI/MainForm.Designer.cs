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
            btnClockIn = new Button();
            btnClockOut = new Button();
            dgvEntryLog = new DataGridView();
            btnUpdateEntry = new Button();
            btnDeleteEntry = new Button();
            lblEntryLog = new Label();
            rdoWorking = new RadioButton();
            rdoTrainingHours = new RadioButton();
            grpControls = new GroupBox();
            grpEntryDetails = new GroupBox();
            chkLoggedInWorkDay = new CheckBox();
            lblDateTimeOut = new Label();
            lblDateTimeIn = new Label();
            dtpDateTimeOut = new DateTimePicker();
            dtpDateTimeIn = new DateTimePicker();
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).BeginInit();
            grpControls.SuspendLayout();
            grpEntryDetails.SuspendLayout();
            SuspendLayout();
            // 
            // btnClockIn
            // 
            btnClockIn.Location = new Point(16, 62);
            btnClockIn.Name = "btnClockIn";
            btnClockIn.Size = new Size(342, 50);
            btnClockIn.TabIndex = 0;
            btnClockIn.Text = "Clock In";
            btnClockIn.UseVisualStyleBackColor = true;
            btnClockIn.Click += btnClockIn_Click;
            // 
            // btnClockOut
            // 
            btnClockOut.Location = new Point(16, 131);
            btnClockOut.Name = "btnClockOut";
            btnClockOut.Size = new Size(342, 50);
            btnClockOut.TabIndex = 0;
            btnClockOut.Text = "Clock Out";
            btnClockOut.UseVisualStyleBackColor = true;
            btnClockOut.Click += btnClockOut_Click;
            // 
            // dgvEntryLog
            // 
            dgvEntryLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntryLog.Location = new Point(12, 43);
            dgvEntryLog.Name = "dgvEntryLog";
            dgvEntryLog.RowTemplate.Height = 25;
            dgvEntryLog.Size = new Size(568, 696);
            dgvEntryLog.TabIndex = 1;
            // 
            // btnUpdateEntry
            // 
            btnUpdateEntry.Location = new Point(16, 199);
            btnUpdateEntry.Name = "btnUpdateEntry";
            btnUpdateEntry.Size = new Size(150, 50);
            btnUpdateEntry.TabIndex = 0;
            btnUpdateEntry.Text = "Update";
            btnUpdateEntry.UseVisualStyleBackColor = true;
            btnUpdateEntry.Click += btnClockIn_Click;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Location = new Point(208, 199);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new Size(150, 50);
            btnDeleteEntry.TabIndex = 0;
            btnDeleteEntry.Text = "Delete";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnClockIn_Click;
            // 
            // lblEntryLog
            // 
            lblEntryLog.AutoSize = true;
            lblEntryLog.Location = new Point(14, 20);
            lblEntryLog.Name = "lblEntryLog";
            lblEntryLog.Size = new Size(57, 15);
            lblEntryLog.TabIndex = 2;
            lblEntryLog.Text = "Entry Log";
            // 
            // rdoWorking
            // 
            rdoWorking.AutoSize = true;
            rdoWorking.Location = new Point(16, 22);
            rdoWorking.Name = "rdoWorking";
            rdoWorking.Size = new Size(101, 19);
            rdoWorking.TabIndex = 5;
            rdoWorking.TabStop = true;
            rdoWorking.Text = "Hours Worked";
            rdoWorking.UseVisualStyleBackColor = true;
            // 
            // rdoTrainingHours
            // 
            rdoTrainingHours.AutoSize = true;
            rdoTrainingHours.Location = new Point(236, 22);
            rdoTrainingHours.Name = "rdoTrainingHours";
            rdoTrainingHours.Size = new Size(102, 19);
            rdoTrainingHours.TabIndex = 5;
            rdoTrainingHours.TabStop = true;
            rdoTrainingHours.Text = "Training Hours";
            rdoTrainingHours.UseVisualStyleBackColor = true;
            // 
            // grpControls
            // 
            grpControls.Controls.Add(btnDeleteEntry);
            grpControls.Controls.Add(btnUpdateEntry);
            grpControls.Controls.Add(btnClockOut);
            grpControls.Controls.Add(btnClockIn);
            grpControls.Controls.Add(rdoTrainingHours);
            grpControls.Controls.Add(rdoWorking);
            grpControls.Location = new Point(673, 474);
            grpControls.Name = "grpControls";
            grpControls.Size = new Size(371, 265);
            grpControls.TabIndex = 8;
            grpControls.TabStop = false;
            // 
            // grpEntryDetails
            // 
            grpEntryDetails.Controls.Add(chkLoggedInWorkDay);
            grpEntryDetails.Controls.Add(lblDateTimeOut);
            grpEntryDetails.Controls.Add(lblDateTimeIn);
            grpEntryDetails.Controls.Add(dtpDateTimeOut);
            grpEntryDetails.Controls.Add(dtpDateTimeIn);
            grpEntryDetails.Location = new Point(673, 43);
            grpEntryDetails.Name = "grpEntryDetails";
            grpEntryDetails.Size = new Size(371, 425);
            grpEntryDetails.TabIndex = 9;
            grpEntryDetails.TabStop = false;
            grpEntryDetails.Text = "Entry Details";
            // 
            // chkLoggedInWorkDay
            // 
            chkLoggedInWorkDay.AutoSize = true;
            chkLoggedInWorkDay.Location = new Point(16, 160);
            chkLoggedInWorkDay.Name = "chkLoggedInWorkDay";
            chkLoggedInWorkDay.Size = new Size(129, 19);
            chkLoggedInWorkDay.TabIndex = 2;
            chkLoggedInWorkDay.Text = "Logged In Workday";
            chkLoggedInWorkDay.UseVisualStyleBackColor = true;
            // 
            // lblDateTimeOut
            // 
            lblDateTimeOut.AutoSize = true;
            lblDateTimeOut.Location = new Point(16, 111);
            lblDateTimeOut.Name = "lblDateTimeOut";
            lblDateTimeOut.Size = new Size(56, 15);
            lblDateTimeOut.TabIndex = 1;
            lblDateTimeOut.Text = "Time Out";
            // 
            // lblDateTimeIn
            // 
            lblDateTimeIn.AutoSize = true;
            lblDateTimeIn.Location = new Point(16, 56);
            lblDateTimeIn.Name = "lblDateTimeIn";
            lblDateTimeIn.Size = new Size(46, 15);
            lblDateTimeIn.TabIndex = 1;
            lblDateTimeIn.Text = "Time In";
            // 
            // dtpDateTimeOut
            // 
            dtpDateTimeOut.Format = DateTimePickerFormat.Time;
            dtpDateTimeOut.Location = new Point(158, 105);
            dtpDateTimeOut.Name = "dtpDateTimeOut";
            dtpDateTimeOut.Size = new Size(200, 23);
            dtpDateTimeOut.TabIndex = 0;
            // 
            // dtpDateTimeIn
            // 
            dtpDateTimeIn.Format = DateTimePickerFormat.Time;
            dtpDateTimeIn.Location = new Point(158, 50);
            dtpDateTimeIn.Name = "dtpDateTimeIn";
            dtpDateTimeIn.Size = new Size(200, 23);
            dtpDateTimeIn.TabIndex = 0;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1077, 760);
            Controls.Add(grpEntryDetails);
            Controls.Add(grpControls);
            Controls.Add(lblEntryLog);
            Controls.Add(dgvEntryLog);
            Name = "MainForm";
            Text = "Time Clock";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).EndInit();
            grpControls.ResumeLayout(false);
            grpControls.PerformLayout();
            grpEntryDetails.ResumeLayout(false);
            grpEntryDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClockIn;
        private Button btnClockOut;
        private DataGridView dgvEntryLog;
        private Button btnUpdateEntry;
        private Button btnDeleteEntry;
        private Label lblEntryLog;
        private DateTimePicker dateTimePicker1;
        private DateTimePicker dateTimePicker2;
        private RadioButton rdoWorking;
        private RadioButton rdoTrainingHours;
        private GroupBox grpControls;
        private GroupBox grpEntryDetails;
        private DateTimePicker dtpDateTimeOut;
        private DateTimePicker dtpDateTimeIn;
        private Label lblDateTimeOut;
        private Label lblDateTimeIn;
        private CheckBox chkLoggedInWorkDay;
    }
}