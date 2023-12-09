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
            btnDeleteEntry = new Button();
            lblEntryLog = new Label();
            rdoWorking = new RadioButton();
            rdoTraining = new RadioButton();
            grpControls = new GroupBox();
            lblTimeType = new Label();
            lblStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).BeginInit();
            grpControls.SuspendLayout();
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
            // dgvEntryLog
            // 
            dgvEntryLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntryLog.Location = new Point(36, 40);
            dgvEntryLog.Margin = new Padding(5);
            dgvEntryLog.Name = "dgvEntryLog";
            dgvEntryLog.RowTemplate.Height = 25;
            dgvEntryLog.Size = new Size(520, 696);
            dgvEntryLog.TabIndex = 1;
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
            lblEntryLog.Location = new Point(36, 14);
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
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(594, 1130);
            Controls.Add(lblStatus);
            Controls.Add(grpControls);
            Controls.Add(lblEntryLog);
            Controls.Add(dgvEntryLog);
            Name = "MainForm";
            Text = "Time Clock";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).EndInit();
            grpControls.ResumeLayout(false);
            grpControls.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnClockIn;
        private Button btnClockOut;
        private DataGridView dgvEntryLog;
        private Button btnDeleteEntry;
        private Label lblEntryLog;
        private RadioButton rdoWorking;
        private RadioButton rdoTraining;
        private GroupBox grpControls;
        private Label lblTimeType;
        private Label lblStatus;
    }
}