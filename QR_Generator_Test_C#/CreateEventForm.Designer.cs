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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateEventForm));
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.TB_ID = new System.Windows.Forms.TextBox();
            this.TB_Desc = new System.Windows.Forms.TextBox();
            this.CB_Category = new System.Windows.Forms.ComboBox();
            this.CB_Settings = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TB_Title = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label1.Location = new System.Drawing.Point(382, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Event ID";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(379, 454);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label4.Location = new System.Drawing.Point(379, 281);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Category:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label5.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label5.Location = new System.Drawing.Point(381, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Event Date:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label6.Location = new System.Drawing.Point(379, 422);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(113, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Event Setting:";
            // 
            // TB_ID
            // 
            this.TB_ID.BackColor = System.Drawing.Color.Black;
            this.TB_ID.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TB_ID.ForeColor = System.Drawing.Color.White;
            this.TB_ID.Location = new System.Drawing.Point(385, 157);
            this.TB_ID.Name = "TB_ID";
            this.TB_ID.Size = new System.Drawing.Size(379, 30);
            this.TB_ID.TabIndex = 6;
            // 
            // TB_Desc
            // 
            this.TB_Desc.BackColor = System.Drawing.Color.Black;
            this.TB_Desc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TB_Desc.ForeColor = System.Drawing.Color.White;
            this.TB_Desc.Location = new System.Drawing.Point(385, 477);
            this.TB_Desc.Multiline = true;
            this.TB_Desc.Name = "TB_Desc";
            this.TB_Desc.Size = new System.Drawing.Size(379, 63);
            this.TB_Desc.TabIndex = 8;
            // 
            // CB_Category
            // 
            this.CB_Category.BackColor = System.Drawing.SystemColors.InfoText;
            this.CB_Category.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.CB_Category.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CB_Category.ForeColor = System.Drawing.Color.White;
            this.CB_Category.FormattingEnabled = true;
            this.CB_Category.Items.AddRange(new object[] {
            "University-Wide",
            "Campus-Wide",
            "College Event",
            "Subject Event"});
            this.CB_Category.Location = new System.Drawing.Point(479, 273);
            this.CB_Category.Name = "CB_Category";
            this.CB_Category.Size = new System.Drawing.Size(285, 33);
            this.CB_Category.TabIndex = 9;
            // 
            // CB_Settings
            // 
            this.CB_Settings.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.CB_Settings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.CB_Settings.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.CB_Settings.ForeColor = System.Drawing.Color.White;
            this.CB_Settings.FormattingEnabled = true;
            this.CB_Settings.Items.AddRange(new object[] {
            "Off-Campus",
            "CCS Laboratory",
            "New CCS Building",
            "Campus Gymnasium",
            "Campus Field"});
            this.CB_Settings.Location = new System.Drawing.Point(511, 417);
            this.CB_Settings.Name = "CB_Settings";
            this.CB_Settings.Size = new System.Drawing.Size(251, 33);
            this.CB_Settings.TabIndex = 11;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(479, 541);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(185, 72);
            this.button1.TabIndex = 12;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.CalendarFont = new System.Drawing.Font("MS Outlook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.dateTimePickerStart.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePickerStart.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dateTimePickerStart.CalendarTitleBackColor = System.Drawing.SystemColors.HotTrack;
            this.dateTimePickerStart.CalendarTitleForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dateTimePickerStart.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerStart.Location = new System.Drawing.Point(495, 327);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(269, 30);
            this.dateTimePickerStart.TabIndex = 13;
            this.dateTimePickerStart.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button2.BackgroundImage")));
            this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.button2.Cursor = System.Windows.Forms.Cursors.Default;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(282, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 45);
            this.button2.TabIndex = 14;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label2.Location = new System.Drawing.Point(382, 200);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Event Title";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // TB_Title
            // 
            this.TB_Title.BackColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.TB_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.TB_Title.ForeColor = System.Drawing.Color.White;
            this.TB_Title.Location = new System.Drawing.Point(385, 223);
            this.TB_Title.Name = "TB_Title";
            this.TB_Title.Size = new System.Drawing.Size(379, 30);
            this.TB_Title.TabIndex = 7;
            this.TB_Title.TextChanged += new System.EventHandler(this.TB_Title_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Haettenschweiler", 30F);
            this.label7.ForeColor = System.Drawing.Color.Snow;
            this.label7.Location = new System.Drawing.Point(475, 61);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(187, 52);
            this.label7.TabIndex = 33;
            this.label7.Text = "EVENT INFO";
            this.label7.Click += new System.EventHandler(this.label7_Click);
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.CalendarFont = new System.Drawing.Font("MS Outlook", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.dateTimePickerEnd.CalendarForeColor = System.Drawing.Color.Black;
            this.dateTimePickerEnd.CalendarMonthBackground = System.Drawing.SystemColors.ControlLightLight;
            this.dateTimePickerEnd.CalendarTitleBackColor = System.Drawing.SystemColors.HotTrack;
            this.dateTimePickerEnd.CalendarTitleForeColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.dateTimePickerEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(495, 373);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(269, 30);
            this.dateTimePickerEnd.TabIndex = 35;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.label8.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label8.Location = new System.Drawing.Point(381, 378);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(90, 20);
            this.label8.TabIndex = 34;
            this.label8.Text = "Event End:";
            // 
            // CreateEventForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.CB_Settings);
            this.Controls.Add(this.CB_Category);
            this.Controls.Add(this.TB_Desc);
            this.Controls.Add(this.TB_ID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TB_Title);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreateEventForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CreateEventForm";
            this.Load += new System.EventHandler(this.CreateEventForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TB_ID;
        private System.Windows.Forms.TextBox TB_Desc;
        private System.Windows.Forms.ComboBox CB_Category;
        private System.Windows.Forms.ComboBox CB_Settings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TB_Title;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Label label8;
    }
}