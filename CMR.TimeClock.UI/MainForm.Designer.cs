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
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).BeginInit();
            grpControls.SuspendLayout();
            SuspendLayout();
            // 
            // btnClockIn
            // 
            btnClockIn.Location = new Point(16, 73);
            btnClockIn.Name = "btnClockIn";
            btnClockIn.Size = new Size(340, 75);
            btnClockIn.TabIndex = 0;
            btnClockIn.Text = "Clock In";
            btnClockIn.UseVisualStyleBackColor = true;
            btnClockIn.Click += btnClockIn_Click;
            // 
            // btnClockOut
            // 
            btnClockOut.Location = new Point(16, 169);
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
            dgvEntryLog.Location = new Point(12, 43);
            dgvEntryLog.Name = "dgvEntryLog";
            dgvEntryLog.RowTemplate.Height = 25;
            dgvEntryLog.Size = new Size(568, 696);
            dgvEntryLog.TabIndex = 1;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Location = new Point(27, 787);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new Size(150, 83);
            btnDeleteEntry.TabIndex = 0;
            btnDeleteEntry.Text = "Delete Entry";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnDeleteEntry_Click;
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
            // rdoTraining
            // 
            rdoTraining.AutoSize = true;
            rdoTraining.Location = new Point(236, 22);
            rdoTraining.Name = "rdoTraining";
            rdoTraining.Size = new Size(102, 19);
            rdoTraining.TabIndex = 5;
            rdoTraining.TabStop = true;
            rdoTraining.Text = "Training Hours";
            rdoTraining.UseVisualStyleBackColor = true;
            // 
            // grpControls
            // 
            grpControls.Controls.Add(btnClockOut);
            grpControls.Controls.Add(btnClockIn);
            grpControls.Controls.Add(rdoTraining);
            grpControls.Controls.Add(rdoWorking);
            grpControls.Location = new Point(209, 781);
            grpControls.Name = "grpControls";
            grpControls.Size = new Size(371, 265);
            grpControls.TabIndex = 8;
            grpControls.TabStop = false;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(594, 1106);
            Controls.Add(btnDeleteEntry);
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
    }
}