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
            dataGridView1 = new System.Windows.Forms.DataGridView();
            lblDataGridView = new System.Windows.Forms.Label();
            btnAckAndClear = new System.Windows.Forms.Button();
            label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnTest
            // 
            btnTest.Location = new System.Drawing.Point(10, 253);
            btnTest.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            btnTest.Name = "btnTest";
            btnTest.Size = new System.Drawing.Size(102, 22);
            btnTest.TabIndex = 0;
            btnTest.Text = "Diode Status";
            btnTest.UseVisualStyleBackColor = true;
            btnTest.Click += btnTest_Click;
            // 
            // txtMsg
            // 
            txtMsg.Location = new System.Drawing.Point(115, 257);
            txtMsg.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            txtMsg.Name = "txtMsg";
            txtMsg.ReadOnly = true;
            txtMsg.Size = new System.Drawing.Size(267, 23);
            txtMsg.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(115, 237);
            label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(116, 15);
            label1.TabIndex = 2;
            label1.Text = "Message from server";
            label1.Click += label1_Click;
            // 
            // btnGetTemperature
            // 
            btnGetTemperature.Location = new System.Drawing.Point(10, 278);
            btnGetTemperature.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            btnGetTemperature.Name = "btnGetTemperature";
            btnGetTemperature.Size = new System.Drawing.Size(102, 22);
            btnGetTemperature.TabIndex = 3;
            btnGetTemperature.Text = "Temperature";
            btnGetTemperature.UseVisualStyleBackColor = true;
            btnGetTemperature.Click += btnGetTemperature_Click;
            // 
            // txtIP
            // 
            txtIP.Location = new System.Drawing.Point(10, 333);
            txtIP.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            txtIP.Name = "txtIP";
            txtIP.Size = new System.Drawing.Size(104, 23);
            txtIP.TabIndex = 4;
            txtIP.Text = "192.168.11.3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(10, 317);
            label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(52, 15);
            label2.TabIndex = 5;
            label2.Text = "Server IP";
            // 
            // button1
            // 
            button1.BackColor = System.Drawing.Color.White;
            button1.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            button1.Location = new System.Drawing.Point(115, 278);
            button1.Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(267, 209);
            button1.TabIndex = 6;
            button1.Text = "💡";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new System.Drawing.Point(28, 41);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new System.Drawing.Size(354, 150);
            dataGridView1.TabIndex = 7;
            // 
            // lblDataGridView
            // 
            lblDataGridView.AutoSize = true;
            lblDataGridView.Location = new System.Drawing.Point(28, 23);
            lblDataGridView.Name = "lblDataGridView";
            lblDataGridView.Size = new System.Drawing.Size(132, 15);
            lblDataGridView.TabIndex = 8;
            lblDataGridView.Text = "Datagrid from Database";
            // 
            // btnAckAndClear
            // 
            btnAckAndClear.Location = new System.Drawing.Point(28, 197);
            btnAckAndClear.Name = "btnAckAndClear";
            btnAckAndClear.Size = new System.Drawing.Size(144, 23);
            btnAckAndClear.TabIndex = 9;
            btnAckAndClear.Text = "ACK and Clear all alarms";
            btnAckAndClear.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(168, 355);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(175, 15);
            label3.TabIndex = 10;
            label3.Text = "Denne lyser med den rød lampa";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(673, 497);
            Controls.Add(label3);
            Controls.Add(btnAckAndClear);
            Controls.Add(lblDataGridView);
            Controls.Add(dataGridView1);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(txtIP);
            Controls.Add(btnGetTemperature);
            Controls.Add(label1);
            Controls.Add(txtMsg);
            Controls.Add(btnTest);
            Margin = new System.Windows.Forms.Padding(2, 1, 2, 1);
            Name = "Form1";
            Text = "Raspberry Server Client";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
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
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lblDataGridView;
        private System.Windows.Forms.Button btnAckAndClear;
        private System.Windows.Forms.Label label3;
    }
}
