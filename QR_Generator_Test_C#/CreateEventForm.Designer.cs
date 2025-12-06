namespace QR_Generator_Test_C_
{
    partial class CreateEventForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.TB_Title = new System.Windows.Forms.TextBox();
            this.TB_Desc = new System.Windows.Forms.TextBox();
            this.CB_Category = new System.Windows.Forms.ComboBox();
            this.CB_Settings = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(26, 73);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event ID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "Event Title:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(26, 148);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 22);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(26, 249);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 22);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(26, 287);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 22);
            this.label5.TabIndex = 4;
            this.label5.Text = "Event Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(26, 322);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 22);
            this.label6.TabIndex = 5;
            this.label6.Text = "Event Setting:";
            // 
            // TB_ID
            // 
            this.TB_ID.Location = new System.Drawing.Point(153, 73);
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(237, 22);
            this.TB_ID.TabIndex = 6;
            // 
            // TB_Title
            // 
            this.TB_Title.Location = new System.Drawing.Point(153, 111);
            this.TB_Title.Name = "TB_Title";
            this.TB_Title.Size = new System.Drawing.Size(237, 22);
            this.TB_Title.TabIndex = 7;
            // 
            // TB_Desc
            // 
            this.TB_Desc.Location = new System.Drawing.Point(153, 148);
            this.TB_Desc.Multiline = true;
            this.TB_Desc.Name = "TB_Desc";
            this.TB_Desc.Size = new System.Drawing.Size(237, 87);
            this.TB_Desc.TabIndex = 8;
            // 
            // CB_Category
            // 
            this.CB_Category.FormattingEnabled = true;
            this.CB_Category.Items.AddRange(new object[] {
            "University-Wide",
            "Campus-Wide",
            "College Event",
            "Subject Event"});
            this.CB_Category.Location = new System.Drawing.Point(153, 249);
            this.CB_Category.Name = "CB_Category";
            this.CB_Category.Size = new System.Drawing.Size(237, 24);
            this.CB_Category.TabIndex = 9;
            // 
            // CB_Settings
            // 
            this.CB_Settings.FormattingEnabled = true;
            this.CB_Settings.Items.AddRange(new object[] {
            "Off-Campus",
            "CCS Laboratory",
            "New CCS Building",
            "Campus Gymnasium",
            "Campus Field"});
            this.CB_Settings.Location = new System.Drawing.Point(153, 320);
            this.CB_Settings.Name = "CB_Settings";
            this.CB_Settings.Size = new System.Drawing.Size(237, 24);
            this.CB_Settings.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(101, 383);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(188, 48);
            this.button1.TabIndex = 12;
            this.button1.Text = "Submit Event";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(153, 286);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(237, 22);
            this.dateTimePicker1.TabIndex = 13;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(458, 585);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(110, 39);
            this.button2.TabIndex = 14;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CB_Settings);
            this.panel1.Controls.Add(this.dateTimePicker1);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.CB_Category);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.TB_Desc);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.TB_Title);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.TB_ID);
            this.panel1.Location = new System.Drawing.Point(70, 76);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 480);
            this.panel1.TabIndex = 15;
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(601, 649);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.panel1);
            this.Name = "CreateEventForm";
            this.Text = "CreateEventForm";
            this.Load += new System.EventHandler(this.CreateEventForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.TextBox TB_Title;
        private System.Windows.Forms.TextBox TB_Desc;
        private System.Windows.Forms.ComboBox CB_Category;
        private System.Windows.Forms.ComboBox CB_Settings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Panel panel1;
    }
}