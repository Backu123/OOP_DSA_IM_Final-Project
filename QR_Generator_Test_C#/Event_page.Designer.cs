namespace QR_Generator_Test_C_
{
    partial class Event_page
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
            this.flowEventsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TB_EventID = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // flowEventsPanel
            // 
            this.flowEventsPanel.Location = new System.Drawing.Point(21, 60);
            this.flowEventsPanel.Name = "flowEventsPanel";
            this.flowEventsPanel.Size = new System.Drawing.Size(1149, 517);
            this.flowEventsPanel.TabIndex = 0;
            this.flowEventsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(21, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(114, 42);
            this.button1.TabIndex = 1;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1041, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(109, 42);
            this.button2.TabIndex = 2;
            this.button2.Text = "Join Event";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TB_EventID
            // 
            this.TB_EventID.Location = new System.Drawing.Point(841, 19);
            this.TB_EventID.Multiline = true;
            this.TB_EventID.Name = "TB_EventID";
            this.TB_EventID.Size = new System.Drawing.Size(183, 29);
            this.TB_EventID.TabIndex = 3;
            // 
            // Event_page
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1182, 589);
            this.Controls.Add(this.TB_EventID);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.flowEventsPanel);
            this.Name = "Event_page";
            this.Text = "Event_page";
            this.Load += new System.EventHandler(this.Event_page_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowEventsPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TB_EventID;
    }
}