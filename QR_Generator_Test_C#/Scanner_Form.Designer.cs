namespace QR_Generator_Test_C_
{
    partial class Scanner_Form
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.button1 = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.cbo = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.Refresh = new System.Windows.Forms.Button();
            this.Result = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 20);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(1498, 49);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(271, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(764, 87);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1005, 446);
            this.dataGridView1.TabIndex = 3;
            // 
            // cbo
            // 
            this.cbo.FormattingEnabled = true;
            this.cbo.Location = new System.Drawing.Point(131, 20);
            this.cbo.Name = "cbo";
            this.cbo.Size = new System.Drawing.Size(239, 24);
            this.cbo.TabIndex = 4;
            this.cbo.SelectedIndexChanged += new System.EventHandler(this.cbo_SelectedIndexChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(50, 57);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(674, 476);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.Result);
            this.panel1.Controls.Add(this.Refresh);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Controls.Add(this.comboBox1);
            this.panel1.Controls.Add(this.cbo);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Location = new System.Drawing.Point(37, 25);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1823, 682);
            this.panel1.TabIndex = 8;
            // 
            // Refresh
            // 
            this.Refresh.Location = new System.Drawing.Point(764, 49);
            this.Refresh.Name = "Refresh";
            this.Refresh.Size = new System.Drawing.Size(112, 31);
            this.Refresh.TabIndex = 7;
            this.Refresh.Text = "Refresh";
            this.Refresh.UseVisualStyleBackColor = true;
            this.Refresh.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // Result
            // 
            this.Result.AutoSize = true;
            this.Result.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Result.ForeColor = System.Drawing.Color.Transparent;
            this.Result.Location = new System.Drawing.Point(50, 568);
            this.Result.Name = "Result";
            this.Result.Size = new System.Drawing.Size(124, 42);
            this.Result.TabIndex = 8;
            this.Result.Text = "Result";
            // 
            // Scanner_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1924, 742);
            this.Controls.Add(this.panel1);
            this.Name = "Scanner_Form";
            this.Text = "Scanner_Formm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Scanner_Form_FormClosing);
            this.Load += new System.EventHandler(this.Scanner_Form_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox cbo;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button Refresh;
        private System.Windows.Forms.Label Result;
    }
}
