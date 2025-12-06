namespace QR_Generator_Test_C_
{
    partial class Admin_Event
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
            this.createEventButton = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.mainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowEventsPanel
            // 
            this.flowEventsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowEventsPanel.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.flowEventsPanel.Location = new System.Drawing.Point(135, 105);
            this.flowEventsPanel.Name = "flowEventsPanel";
            this.flowEventsPanel.Size = new System.Drawing.Size(1139, 542);
            this.flowEventsPanel.TabIndex = 0;
            this.flowEventsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // createEventButton
            // 
            this.createEventButton.Location = new System.Drawing.Point(1064, 59);
            this.createEventButton.Name = "createEventButton";
            this.createEventButton.Size = new System.Drawing.Size(210, 36);
            this.createEventButton.TabIndex = 1;
            this.createEventButton.Text = "Create an Event";
            this.createEventButton.UseVisualStyleBackColor = true;
            this.createEventButton.Click += new System.EventHandler(this.createEventButton_Click);
            // 
            // Back
            // 
            this.Back.Location = new System.Drawing.Point(135, 59);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(112, 36);
            this.Back.TabIndex = 2;
            this.Back.Text = "Back";
            this.Back.UseVisualStyleBackColor = true;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainPanel.Controls.Add(this.Back);
            this.mainPanel.Controls.Add(this.createEventButton);
            this.mainPanel.Controls.Add(this.flowEventsPanel);
            this.mainPanel.Location = new System.Drawing.Point(33, 36);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1400, 715);
            this.mainPanel.TabIndex = 3;
            // 
            // Admin_Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1454, 763);
            this.Controls.Add(this.mainPanel);
            this.Name = "Admin_Event";
            this.Text = "Admin_Event";
            this.Load += new System.EventHandler(this.Admin_Event_Load);
            this.mainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowEventsPanel;
        private System.Windows.Forms.Button createEventButton;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Panel mainPanel;
    }
}