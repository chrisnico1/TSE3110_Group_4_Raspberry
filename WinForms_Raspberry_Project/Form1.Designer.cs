namespace WinFormsTestOne
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
            btnAcknowledge = new Button();
            dataGridView1 = new DataGridView();
            progressBar1 = new ProgressBar();
            label1 = new Label();
            label2 = new Label();
            btnClearAlarm = new Button();
            btnDiode = new Button();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            lblDoorStatus = new Label();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // btnAcknowledge
            // 
            btnAcknowledge.Location = new Point(51, 186);
            btnAcknowledge.Name = "btnAcknowledge";
            btnAcknowledge.Size = new Size(109, 23);
            btnAcknowledge.TabIndex = 0;
            btnAcknowledge.Text = "Acknowledge";
            btnAcknowledge.UseVisualStyleBackColor = true;
            btnAcknowledge.Click += button1_Click;
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(51, 30);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(698, 150);
            dataGridView1.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(649, 186);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(100, 23);
            progressBar1.TabIndex = 2;
            progressBar1.Value = 50;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(51, 306);
            label1.Name = "label1";
            label1.Size = new Size(65, 15);
            label1.TabIndex = 4;
            label1.Text = "Light Satus";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(51, 12);
            label2.Name = "label2";
            label2.Size = new Size(55, 15);
            label2.TabIndex = 5;
            label2.Text = "Database";
            // 
            // btnClearAlarm
            // 
            btnClearAlarm.Location = new Point(166, 186);
            btnClearAlarm.Name = "btnClearAlarm";
            btnClearAlarm.Size = new Size(90, 23);
            btnClearAlarm.TabIndex = 6;
            btnClearAlarm.Text = "Clear Alarm";
            btnClearAlarm.UseVisualStyleBackColor = true;
            // 
            // btnDiode
            // 
            btnDiode.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point);
            btnDiode.Location = new Point(51, 324);
            btnDiode.Name = "btnDiode";
            btnDiode.Size = new Size(55, 56);
            btnDiode.TabIndex = 7;
            btnDiode.Text = "💡";
            btnDiode.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(568, 236);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(26, 144);
            textBox1.TabIndex = 8;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ControlDarkDark;
            textBox2.Location = new Point(462, 236);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(100, 144);
            textBox2.TabIndex = 9;
            // 
            // lblDoorStatus
            // 
            lblDoorStatus.AutoSize = true;
            lblDoorStatus.Location = new Point(485, 218);
            lblDoorStatus.Name = "lblDoorStatus";
            lblDoorStatus.Size = new Size(68, 15);
            lblDoorStatus.TabIndex = 10;
            lblDoorStatus.Text = "Door Status";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 440);
            Controls.Add(lblDoorStatus);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(btnDiode);
            Controls.Add(btnClearAlarm);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(progressBar1);
            Controls.Add(dataGridView1);
            Controls.Add(btnAcknowledge);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnAcknowledge;
        private DataGridView dataGridView1;
        private ProgressBar progressBar1;
        private Label label1;
        private Label label2;
        private Button btnClearAlarm;
        private Button btnDiode;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label lblDoorStatus;
    }
}