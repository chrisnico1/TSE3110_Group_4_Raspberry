﻿namespace RaspberryServerClientForm
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
            btnClearAllAlarms = new System.Windows.Forms.Button();
            dgvAlarm = new System.Windows.Forms.DataGridView();
            txtCurrentTemperature = new System.Windows.Forms.TextBox();
            lblGreenDiode = new System.Windows.Forms.Label();
            lblCurrentTemperature = new System.Windows.Forms.Label();
            tmrSampleTime = new System.Windows.Forms.Timer(components);
            btnTemp = new System.Windows.Forms.Button();
            txtTemp = new System.Windows.Forms.TextBox();
            panel1 = new System.Windows.Forms.Panel();
            panel3 = new System.Windows.Forms.Panel();
            panel4 = new System.Windows.Forms.Panel();
            label5 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            label1 = new System.Windows.Forms.Label();
            panel5 = new System.Windows.Forms.Panel();
            btnTemperature = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)dgvAlarm).BeginInit();
            panel1.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel2.SuspendLayout();
            panel5.SuspendLayout();
            SuspendLayout();
            // 
            // txtIP
            // 
            txtIP.Location = new System.Drawing.Point(46, 148);
            txtIP.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(305, 39);
            txtIP.TabIndex = 4;
            txtIP.Text = "192.168.97.55";
            txtIP.KeyPress += txtIP_KeyPress;
            // 
            // lblServerIP
            // 
            lblServerIP.AutoSize = true;
            lblServerIP.ForeColor = System.Drawing.Color.Coral;
            lblServerIP.Location = new System.Drawing.Point(46, 114);
            lblServerIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            lblServerIP.Name = "lblServerIP";
            lblServerIP.Size = new System.Drawing.Size(107, 32);
            lblServerIP.TabIndex = 5;
            lblServerIP.Text = "Server IP";
            // 
            // btnGreenDiode
            // 
            btnGreenDiode.BackColor = System.Drawing.Color.White;
            btnGreenDiode.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnGreenDiode.Location = new System.Drawing.Point(35, 66);
            btnGreenDiode.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnGreenDiode.Name = "btnGreenDiode";
            btnGreenDiode.Size = new System.Drawing.Size(204, 194);
            btnGreenDiode.TabIndex = 6;
            btnGreenDiode.Text = "💡";
            btnGreenDiode.UseVisualStyleBackColor = false;
            btnGreenDiode.Click += btnGreenDiode_Click;
            // 
            // lblDoorStatus
            // 
            lblDoorStatus.AutoSize = true;
            lblDoorStatus.Location = new System.Drawing.Point(313, 375);
            lblDoorStatus.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblDoorStatus.Name = "lblDoorStatus";
            lblDoorStatus.Size = new System.Drawing.Size(138, 32);
            lblDoorStatus.TabIndex = 20;
            lblDoorStatus.Text = "Door Status";
            // 
            // txtDoorClosed
            // 
            txtDoorClosed.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            txtDoorClosed.Location = new System.Drawing.Point(290, 66);
            txtDoorClosed.Margin = new System.Windows.Forms.Padding(6);
            txtDoorClosed.Multiline = true;
            txtDoorClosed.Name = "txtDoorClosed";
            txtDoorClosed.Size = new System.Drawing.Size(182, 303);
            txtDoorClosed.TabIndex = 19;
            // 
            // txtDoorOpen
            // 
            txtDoorOpen.BackColor = System.Drawing.SystemColors.ScrollBar;
            txtDoorOpen.Location = new System.Drawing.Point(430, 66);
            txtDoorOpen.Margin = new System.Windows.Forms.Padding(6);
            txtDoorOpen.Multiline = true;
            txtDoorOpen.Name = "txtDoorOpen";
            txtDoorOpen.Size = new System.Drawing.Size(45, 303);
            txtDoorOpen.TabIndex = 18;
            // 
            // btnClearAllAlarms
            // 
            btnClearAllAlarms.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            btnClearAllAlarms.ForeColor = System.Drawing.SystemColors.Control;
            btnClearAllAlarms.Location = new System.Drawing.Point(0, 347);
            btnClearAllAlarms.Margin = new System.Windows.Forms.Padding(6);
            btnClearAllAlarms.Name = "btnClearAllAlarms";
            btnClearAllAlarms.Size = new System.Drawing.Size(400, 69);
            btnClearAllAlarms.TabIndex = 16;
            btnClearAllAlarms.Text = "Clear All Alarms";
            btnClearAllAlarms.UseVisualStyleBackColor = false;
            btnClearAllAlarms.Click += btnClearAllAlarms_Click;
            btnClearAllAlarms.MouseLeave += btnClearAllAlarms_MouseLeave;
            btnClearAllAlarms.MouseHover += btnClearAllAlarms_MouseHover;
            // 
            // dgvAlarm
            // 
            dgvAlarm.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAlarm.Location = new System.Drawing.Point(409, 0);
            dgvAlarm.Margin = new System.Windows.Forms.Padding(6);
            dgvAlarm.Name = "dgvAlarm";
            dgvAlarm.ReadOnly = true;
            dgvAlarm.RowHeadersWidth = 82;
            dgvAlarm.RowTemplate.Height = 25;
            dgvAlarm.Size = new System.Drawing.Size(1398, 416);
            dgvAlarm.TabIndex = 13;
            // 
            // txtCurrentTemperature
            // 
            txtCurrentTemperature.Location = new System.Drawing.Point(517, 259);
            txtCurrentTemperature.Margin = new System.Windows.Forms.Padding(6);
            txtCurrentTemperature.Name = "txtCurrentTemperature";
            txtCurrentTemperature.Size = new System.Drawing.Size(239, 39);
            txtCurrentTemperature.TabIndex = 21;
            txtCurrentTemperature.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblGreenDiode
            // 
            lblGreenDiode.AutoSize = true;
            lblGreenDiode.Location = new System.Drawing.Point(64, 262);
            lblGreenDiode.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblGreenDiode.Name = "lblGreenDiode";
            lblGreenDiode.Size = new System.Drawing.Size(146, 32);
            lblGreenDiode.TabIndex = 22;
            lblGreenDiode.Text = "Light Toggle";
            // 
            // lblCurrentTemperature
            // 
            lblCurrentTemperature.AutoSize = true;
            lblCurrentTemperature.Location = new System.Drawing.Point(567, 304);
            lblCurrentTemperature.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            lblCurrentTemperature.Name = "lblCurrentTemperature";
            lblCurrentTemperature.Size = new System.Drawing.Size(149, 32);
            lblCurrentTemperature.TabIndex = 23;
            lblCurrentTemperature.Text = "Temperature";
            // 
            // tmrSampleTime
            // 
            tmrSampleTime.Interval = 3000;
            tmrSampleTime.Tick += tmrSampleTime_Tick;
            // 
            // btnTemp
            // 
            btnTemp.Location = new System.Drawing.Point(35, 471);
            btnTemp.Margin = new System.Windows.Forms.Padding(6);
            btnTemp.Name = "btnTemp";
            btnTemp.Size = new System.Drawing.Size(204, 49);
            btnTemp.TabIndex = 24;
            btnTemp.Text = "Make alarm";
            btnTemp.UseVisualStyleBackColor = true;
            btnTemp.Click += btnTemp_Click;
            // 
            // txtTemp
            // 
            txtTemp.Location = new System.Drawing.Point(409, 1009);
            txtTemp.Margin = new System.Windows.Forms.Padding(6);
            txtTemp.Multiline = true;
            txtTemp.Name = "txtTemp";
            txtTemp.Size = new System.Drawing.Size(836, 190);
            txtTemp.TabIndex = 25;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.FromArgb(51, 51, 76);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(panel2);
            panel1.Controls.Add(btnClearAllAlarms);
            panel1.Dock = System.Windows.Forms.DockStyle.Left;
            panel1.Location = new System.Drawing.Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(400, 1199);
            panel1.TabIndex = 26;
            // 
            // panel3
            // 
            panel3.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            panel3.Controls.Add(panel4);
            panel3.Controls.Add(label4);
            panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel3.Location = new System.Drawing.Point(0, 446);
            panel3.Name = "panel3";
            panel3.Size = new System.Drawing.Size(400, 753);
            panel3.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            panel4.Controls.Add(label5);
            panel4.Controls.Add(lblServerIP);
            panel4.Controls.Add(txtIP);
            panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            panel4.Location = new System.Drawing.Point(0, 552);
            panel4.Name = "panel4";
            panel4.Size = new System.Drawing.Size(400, 201);
            panel4.TabIndex = 1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label5.ForeColor = System.Drawing.SystemColors.Control;
            label5.Location = new System.Drawing.Point(46, 41);
            label5.Name = "label5";
            label5.Size = new System.Drawing.Size(249, 50);
            label5.TabIndex = 0;
            label5.Text = "Configuration";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label4.ForeColor = System.Drawing.SystemColors.Control;
            label4.Location = new System.Drawing.Point(46, 38);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(210, 50);
            label4.TabIndex = 0;
            label4.Text = "Site control";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label2.ForeColor = System.Drawing.SystemColors.Control;
            label2.Location = new System.Drawing.Point(46, 255);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(135, 50);
            label2.TabIndex = 1;
            label2.Text = "Alarms";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.FromArgb(39, 39, 58);
            panel2.Controls.Add(label1);
            panel2.Dock = System.Windows.Forms.DockStyle.Top;
            panel2.Location = new System.Drawing.Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(400, 200);
            panel2.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            label1.ForeColor = System.Drawing.SystemColors.Control;
            label1.Location = new System.Drawing.Point(46, 64);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(305, 71);
            label1.TabIndex = 0;
            label1.Text = "Control GUI";
            // 
            // panel5
            // 
            panel5.BackColor = System.Drawing.Color.White;
            panel5.Controls.Add(btnTemperature);
            panel5.Controls.Add(btnGreenDiode);
            panel5.Controls.Add(lblGreenDiode);
            panel5.Controls.Add(lblDoorStatus);
            panel5.Controls.Add(btnTemp);
            panel5.Controls.Add(txtDoorClosed);
            panel5.Controls.Add(txtCurrentTemperature);
            panel5.Controls.Add(lblCurrentTemperature);
            panel5.Controls.Add(txtDoorOpen);
            panel5.Location = new System.Drawing.Point(406, 446);
            panel5.Name = "panel5";
            panel5.Size = new System.Drawing.Size(839, 551);
            panel5.TabIndex = 27;
            // 
            // btnTemperature
            // 
            btnTemperature.BackColor = System.Drawing.Color.White;
            btnTemperature.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnTemperature.Location = new System.Drawing.Point(517, 66);
            btnTemperature.Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            btnTemperature.Name = "btnTemperature";
            btnTemperature.Size = new System.Drawing.Size(239, 185);
            btnTemperature.TabIndex = 25;
            btnTemperature.Text = "♨️";
            btnTemperature.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackColor = System.Drawing.Color.Azure;
            ClientSize = new System.Drawing.Size(1831, 1199);
            Controls.Add(panel5);
            Controls.Add(panel1);
            Controls.Add(txtTemp);
            Controls.Add(dgvAlarm);
            Margin = new System.Windows.Forms.Padding(4, 2, 4, 2);
            Name = "Form1";
            Text = "Raspberry Server Client";
            ((System.ComponentModel.ISupportInitialize)dgvAlarm).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
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
        private System.Windows.Forms.Button btnClearAllAlarms;
        private System.Windows.Forms.DataGridView dgvAlarm;
        private System.Windows.Forms.TextBox txtCurrentTemperature;
        private System.Windows.Forms.Label lblGreenDiode;
        private System.Windows.Forms.Label lblCurrentTemperature;
        private System.Windows.Forms.Timer tmrSampleTime;
        private System.Windows.Forms.Button btnTemp;
        private System.Windows.Forms.TextBox txtTemp;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Button btnTemperature;
    }
}
