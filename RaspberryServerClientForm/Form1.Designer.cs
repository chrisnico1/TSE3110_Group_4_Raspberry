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
            btnTest = new System.Windows.Forms.Button();
            txtMsg = new System.Windows.Forms.TextBox();
            label1 = new System.Windows.Forms.Label();
            btnGetTemperature = new System.Windows.Forms.Button();
            txtIP = new System.Windows.Forms.TextBox();
            label2 = new System.Windows.Forms.Label();
            button1 = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // btnTest
            // 
            btnTest.Location = new System.Drawing.Point(42, 165);
            btnTest.Name = "btnTest";
            btnTest.Size = new System.Drawing.Size(190, 46);
            btnTest.TabIndex = 0;
            btnTest.Text = "Diode Status";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // txtMsg
            // 
            txtMsg.Location = new System.Drawing.Point(238, 172);
            txtMsg.Name = "txtMsg";
            txtMsg.ReadOnly = true;
            txtMsg.Size = new System.Drawing.Size(492, 39);
            txtMsg.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(238, 130);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(237, 32);
            label1.TabIndex = 2;
            label1.Text = "Message from server";
            label1.Click += label1_Click;
            // 
            // btnGetTemperature
            // 
            btnGetTemperature.Location = new System.Drawing.Point(42, 217);
            btnGetTemperature.Name = "btnGetTemperature";
            btnGetTemperature.Size = new System.Drawing.Size(190, 46);
            btnGetTemperature.TabIndex = 3;
            btnGetTemperature.Text = "Temperature";
            btnGetTemperature.UseVisualStyleBackColor = true;
            btnGetTemperature.Click += btnGetTemperature_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new System.Drawing.Point(42, 335);
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(190, 39);
            txtIP.TabIndex = 4;
            txtIP.Text = "192.168.11.3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(42, 300);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(107, 32);
            label2.TabIndex = 5;
            label2.Text = "Server IP";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.White;
            button1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(238, 217);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(495, 446);
            button1.TabIndex = 6;
            button1.Text = "💡";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(866, 1250);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtIP);
            Controls.Add(btnGetTemperature);
            Controls.Add(label1);
            Controls.Add(txtMsg);
            Controls.Add(btnTest);
            Name = "Form1";
            Text = "Raspberry Server Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGetTemperature;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
    }
}
