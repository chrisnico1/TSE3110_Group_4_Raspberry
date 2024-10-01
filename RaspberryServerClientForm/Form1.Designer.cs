namespace RaspberryServerClientForm
{
    partial class Form1
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
            txtIP = new System.Windows.Forms.TextBox();
            lblServerIP = new System.Windows.Forms.Label();
            btnGreenDiode = new System.Windows.Forms.Button();
            lblDoorStatus = new System.Windows.Forms.Label();
            txtDoorClosed = new System.Windows.Forms.TextBox();
            txtDoorOpen = new System.Windows.Forms.TextBox();
            btnClearAlarm = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            dgvAlarm = new System.Windows.Forms.DataGridView();
            btnAcknowledge = new System.Windows.Forms.Button();
            txtCurrentTemperature = new System.Windows.Forms.TextBox();
            lblGreenDiode = new System.Windows.Forms.Label();
            lblCurrentTemperature = new System.Windows.Forms.Label();
            tmrSampleTime = new System.Windows.Forms.Timer(components);
            btnTemp = new System.Windows.Forms.Button();
            txtTemp = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvAlarm).BeginInit();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.Location = new System.Drawing.Point(17, 243);
            txtIP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(104, 23);
            txtIP.TabIndex = 4;
            txtIP.Text = "192.168.97.55";
            // 
            // lblServerIP
            // 
            lblServerIP.AutoSize = true;
            lblServerIP.Location = new System.Drawing.Point(17, 227);
            lblServerIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new System.Drawing.Size(52, 15);
            lblServerIP.TabIndex = 5;
            lblServerIP.Text = "Server IP";
            // 
            // btnGreenDiode
            // 
            btnGreenDiode.BackColor = System.Drawing.Color.White;
            btnGreenDiode.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnGreenDiode.Location = new System.Drawing.Point(17, 306);
            btnGreenDiode.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            btnGreenDiode.Name = "btnGreenDiode";
            btnGreenDiode.Size = new System.Drawing.Size(110, 91);
            btnGreenDiode.TabIndex = 6;
            btnGreenDiode.Text = "💡";
            btnGreenDiode.UseVisualStyleBackColor = false;
            btnGreenDiode.Click += btnGreenDiode_Click;
            // 
            // lblDoorStatus
            // 
            lblDoorStatus.AutoSize = true;
            lblDoorStatus.Location = new System.Drawing.Point(574, 209);
            lblDoorStatus.Name = "lblDoorStatus";
            lblDoorStatus.Size = new System.Drawing.Size(68, 15);
            lblDoorStatus.TabIndex = 20;
            lblDoorStatus.Text = "Door Status";
            // 
            // txtDoorClosed
            // 
            txtDoorClosed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            txtDoorClosed.Location = new System.Drawing.Point(551, 227);
            txtDoorClosed.Multiline = true;
            txtDoorClosed.Name = "txtDoorClosed";
            txtDoorClosed.Size = new System.Drawing.Size(100, 144);
            txtDoorClosed.TabIndex = 19;
            // 
            // txtDoorOpen
            // 
            txtDoorOpen.BackColor = System.Drawing.SystemColors.ScrollBar;
            txtDoorOpen.Location = new System.Drawing.Point(626, 227);
            txtDoorOpen.Multiline = true;
            txtDoorOpen.Name = "txtDoorOpen";
            txtDoorOpen.Size = new System.Drawing.Size(26, 144);
            txtDoorOpen.TabIndex = 18;
            // 
            // btnClearAlarm
            // 
            btnClearAlarm.Location = new System.Drawing.Point(127, 181);
            btnClearAlarm.Name = "btnClearAlarm";
            btnClearAlarm.Size = new System.Drawing.Size(116, 23);
            btnClearAlarm.TabIndex = 16;
            btnClearAlarm.Text = "Clear Alarm";
            btnClearAlarm.UseVisualStyleBackColor = true;
            btnClearAlarm.Click += btnClearAlarm_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(12, 7);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(55, 15);
            label3.TabIndex = 15;
            label3.Text = "Database";
            // 
            // dgvAlarm
            // 
            dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlarm.Location = new System.Drawing.Point(12, 25);
            dgvAlarm.Name = "dgvAlarm";
            dgvAlarm.ReadOnly = true;
            dgvAlarm.RowHeadersWidth = 82;
            dgvAlarm.RowTemplate.Height = 25;
            dgvAlarm.Size = new System.Drawing.Size(698, 150);
            dgvAlarm.TabIndex = 13;
            // 
            // btnAcknowledge
            // 
            btnAcknowledge.Location = new System.Drawing.Point(12, 181);
            btnAcknowledge.Name = "btnAcknowledge";
            btnAcknowledge.Size = new System.Drawing.Size(109, 23);
            btnAcknowledge.TabIndex = 12;
            btnAcknowledge.Text = "Acknowledge";
            btnAcknowledge.UseVisualStyleBackColor = true;
            btnAcknowledge.Click += btnAcknowledge_Click;
            // 
            // txtCurrentTemperature
            // 
            txtCurrentTemperature.Location = new System.Drawing.Point(127, 243);
            txtCurrentTemperature.Name = "txtCurrentTemperature";
            txtCurrentTemperature.Size = new System.Drawing.Size(116, 23);
            txtCurrentTemperature.TabIndex = 21;
            // 
            // lblGreenDiode
            // 
            lblGreenDiode.AutoSize = true;
            lblGreenDiode.Location = new System.Drawing.Point(17, 290);
            lblGreenDiode.Name = "lblGreenDiode";
            lblGreenDiode.Size = new System.Drawing.Size(110, 15);
            lblGreenDiode.TabIndex = 22;
            lblGreenDiode.Text = "Toggle Green Diode";
            // 
            // lblCurrentTemperature
            // 
            lblCurrentTemperature.AutoSize = true;
            lblCurrentTemperature.Location = new System.Drawing.Point(127, 225);
            lblCurrentTemperature.Name = "lblCurrentTemperature";
            lblCurrentTemperature.Size = new System.Drawing.Size(116, 15);
            lblCurrentTemperature.TabIndex = 23;
            lblCurrentTemperature.Text = "Current Temperature";
            // 
            // tmrSampleTime
            // 
            tmrSampleTime.Enabled = true;
            tmrSampleTime.Interval = 1000;
            tmrSampleTime.Tick += tmrSampleTime_Tick;
            // 
            // btnTemp
            // 
            btnTemp.Location = new System.Drawing.Point(316, 260);
            btnTemp.Name = "btnTemp";
            btnTemp.Size = new System.Drawing.Size(140, 23);
            btnTemp.TabIndex = 24;
            btnTemp.Text = "Make alarm";
            btnTemp.UseVisualStyleBackColor = true;
            btnTemp.Click += btnTemp_Click;
            // 
            // txtTemp
            // 
            txtTemp.Location = new System.Drawing.Point(200, 345);
            txtTemp.Name = "txtTemp";
            txtTemp.Size = new System.Drawing.Size(100, 23);
            txtTemp.TabIndex = 25;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(721, 417);
            Controls.Add(txtTemp);
            Controls.Add(btnTemp);
            Controls.Add(lblCurrentTemperature);
            Controls.Add(lblGreenDiode);
            Controls.Add(txtCurrentTemperature);
            Controls.Add(lblDoorStatus);
            Controls.Add(txtDoorClosed);
            Controls.Add(txtDoorOpen);
            Controls.Add(btnClearAlarm);
            Controls.Add(label3);
            Controls.Add(dgvAlarm);
            Controls.Add(btnAcknowledge);
            Controls.Add(btnGreenDiode);
            Controls.Add(lblServerIP);
            Controls.Add(txtIP);
            Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Raspberry Server Client";
            ((System.ComponentModel.ISupportInitialize)dgvAlarm).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label lblServerIP;
        private System.Windows.Forms.Button btnGreenDiode;
        private System.Windows.Forms.Label lblDoorStatus;
        private System.Windows.Forms.TextBox txtDoorClosed;
        private System.Windows.Forms.TextBox txtDoorOpen;
        private System.Windows.Forms.Button btnClearAlarm;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.Button btnAcknowledge;
        private System.Windows.Forms.TextBox txtCurrentTemperature;
        private System.Windows.Forms.Label lblGreenDiode;
        private System.Windows.Forms.Label lblCurrentTemperature;
        private System.Windows.Forms.Timer tmrSampleTime;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.TextBox txtTemp;
    }
}
