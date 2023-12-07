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
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).BeginInit();
            SuspendLayout();
            // 
            // btnClockIn
            // 
            btnClockIn.Location = new Point(12, 12);
            btnClockIn.Name = "btnClockIn";
            btnClockIn.Size = new Size(200, 50);
            btnClockIn.TabIndex = 0;
            btnClockIn.Text = "Clock In";
            btnClockIn.UseVisualStyleBackColor = true;
            btnClockIn.Click += btnClockIn_Click;
            // 
            // btnClockOut
            // 
            btnClockOut.Location = new Point(240, 12);
            btnClockOut.Name = "btnClockOut";
            btnClockOut.Size = new Size(200, 50);
            btnClockOut.TabIndex = 0;
            btnClockOut.Text = "Clock Out";
            btnClockOut.UseVisualStyleBackColor = true;
            btnClockOut.Click += btnClockOut_Click;
            // 
            // dgvEntryLog
            // 
            dgvEntryLog.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEntryLog.Location = new Point(12, 68);
            dgvEntryLog.Name = "dgvEntryLog";
            dgvEntryLog.RowTemplate.Height = 25;
            dgvEntryLog.Size = new Size(428, 470);
            dgvEntryLog.TabIndex = 1;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(452, 601);
            Controls.Add(dgvEntryLog);
            Controls.Add(btnClockOut);
            Controls.Add(btnClockIn);
            Name = "MainForm";
            Text = "Time Clock";
            ((System.ComponentModel.ISupportInitialize)dgvEntryLog).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Button btnClockIn;
        private Button btnClockOut;
        private DataGridView dgvEntryLog;
    }
}