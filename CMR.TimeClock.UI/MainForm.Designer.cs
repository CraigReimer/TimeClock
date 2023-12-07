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
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).BeginInit();
            SuspendLayout();
            // 
            // btnClockIn
            // 
            btnClockIn.Location = new Point(463, 577);
            btnClockIn.Name = "btnClockIn";
            btnClockIn.Size = new Size(376, 50);
            btnClockIn.TabIndex = 0;
            btnClockIn.Text = "Clock In";
            btnClockIn.UseVisualStyleBackColor = true;
            btnClockIn.Click += btnClockIn_Click;
            // 
            // btnClockOut
            // 
            btnClockOut.Location = new Point(463, 633);
            btnClockOut.Name = "btnClockOut";
            btnClockOut.Size = new Size(376, 50);
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
            dgvEntryLog.Size = new Size(428, 696);
            dgvEntryLog.TabIndex = 1;
            // 
            // btnUpdateEntry
            // 
            btnUpdateEntry.Location = new Point(463, 689);
            btnUpdateEntry.Name = "btnUpdateEntry";
            btnUpdateEntry.Size = new Size(175, 50);
            btnUpdateEntry.TabIndex = 0;
            btnUpdateEntry.Text = "Update";
            btnUpdateEntry.UseVisualStyleBackColor = true;
            btnUpdateEntry.Click += btnClockIn_Click;
            // 
            // btnDeleteEntry
            // 
            btnDeleteEntry.Location = new Point(664, 689);
            btnDeleteEntry.Name = "btnDeleteEntry";
            btnDeleteEntry.Size = new Size(175, 50);
            btnDeleteEntry.TabIndex = 0;
            btnDeleteEntry.Text = "Delete";
            btnDeleteEntry.UseVisualStyleBackColor = true;
            btnDeleteEntry.Click += btnClockIn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(866, 760);
            Controls.Add(dgvEntryLog);
            Controls.Add(btnClockOut);
            Controls.Add(btnDeleteEntry);
            Controls.Add(btnUpdateEntry);
            Controls.Add(btnClockIn);
            Name = "MainForm";
            Text = "Time Clock";
            FormClosing += MainForm_FormClosing;
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClockIn;
        private Button btnClockOut;
        private DataGridView dgvEntryLog;
        private Button btnUpdateEntry;
        private Button btnDeleteEntry;
    }
}