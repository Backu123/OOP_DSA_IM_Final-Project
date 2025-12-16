namespace QR_Generator_Test_C_
{
    partial class EventPanel
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventPanel));
            this.panel1 = new System.Windows.Forms.Panel();
            this.PresentDGV = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.AbsentDGV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PresentDGV)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AbsentDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.PresentDGV);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(127, 92);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 539);
            this.panel1.TabIndex = 0;
            // 
            // PresentDGV
            // 
            this.PresentDGV.AllowUserToOrderColumns = true;
            this.PresentDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.PresentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PresentDGV.Location = new System.Drawing.Point(3, 59);
            this.PresentDGV.Name = "PresentDGV";
            this.PresentDGV.RowHeadersWidth = 51;
            this.PresentDGV.RowTemplate.Height = 24;
            this.PresentDGV.Size = new System.Drawing.Size(485, 477);
            this.PresentDGV.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Haettenschweiler", 30F);
            this.label1.Location = new System.Drawing.Point(176, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(146, 52);
            this.label1.TabIndex = 0;
            this.label1.Text = "Present";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.AbsentDGV);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Location = new System.Drawing.Point(640, 94);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(491, 539);
            this.panel2.TabIndex = 1;
            // 
            // AbsentDGV
            // 
            this.AbsentDGV.AllowUserToOrderColumns = true;
            this.AbsentDGV.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.AbsentDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AbsentDGV.Location = new System.Drawing.Point(3, 60);
            this.AbsentDGV.Name = "AbsentDGV";
            this.AbsentDGV.RowHeadersWidth = 51;
            this.AbsentDGV.RowTemplate.Height = 24;
            this.AbsentDGV.Size = new System.Drawing.Size(485, 476);
            this.AbsentDGV.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Haettenschweiler", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(187, -3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 52);
            this.label2.TabIndex = 1;
            this.label2.Text = "Absent";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(91, 59);
            this.button1.TabIndex = 2;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(941, 17);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(187, 52);
            this.button2.TabIndex = 3;
            this.button2.Text = "Download as PDF";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // EventPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EventPanel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.SIgn_Up_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PresentDGV)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AbsentDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView PresentDGV;
        private System.Windows.Forms.DataGridView AbsentDGV;
        private System.Windows.Forms.Button button2;
    }
}