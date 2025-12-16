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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin_Event));
            this.flowEventsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.createEventButton = new System.Windows.Forms.Button();
            this.Back = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // flowEventsPanel
            // 
            this.flowEventsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowEventsPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.flowEventsPanel.BackColor = System.Drawing.Color.Transparent;
            this.flowEventsPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.flowEventsPanel.Location = new System.Drawing.Point(47, 112);
            this.flowEventsPanel.Name = "flowEventsPanel";
            this.flowEventsPanel.Size = new System.Drawing.Size(1124, 534);
            this.flowEventsPanel.TabIndex = 0;
            this.flowEventsPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel1_Paint);
            // 
            // createEventButton
            // 
            this.createEventButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.createEventButton.BackColor = System.Drawing.Color.Transparent;
            this.createEventButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("createEventButton.BackgroundImage")));
            this.createEventButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.createEventButton.FlatAppearance.BorderSize = 0;
            this.createEventButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createEventButton.ForeColor = System.Drawing.Color.Transparent;
            this.createEventButton.Location = new System.Drawing.Point(999, 41);
            this.createEventButton.Name = "createEventButton";
            this.createEventButton.Size = new System.Drawing.Size(162, 65);
            this.createEventButton.TabIndex = 1;
            this.createEventButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.createEventButton.UseVisualStyleBackColor = false;
            this.createEventButton.Click += new System.EventHandler(this.createEventButton_Click);
            // 
            // Back
            // 
            this.Back.BackColor = System.Drawing.Color.Transparent;
            this.Back.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("Back.BackgroundImage")));
            this.Back.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Back.FlatAppearance.BorderSize = 0;
            this.Back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Back.Location = new System.Drawing.Point(37, 49);
            this.Back.Name = "Back";
            this.Back.Size = new System.Drawing.Size(60, 45);
            this.Back.TabIndex = 2;
            this.Back.UseVisualStyleBackColor = false;
            this.Back.Click += new System.EventHandler(this.Back_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.mainPanel.Location = new System.Drawing.Point(33, 36);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(1400, 715);
            this.mainPanel.TabIndex = 3;
            this.mainPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.mainPanel_Paint);
            // 
            // Admin_Event
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.Back);
            this.Controls.Add(this.createEventButton);
            this.Controls.Add(this.flowEventsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Admin_Event";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin_Event";
            this.Load += new System.EventHandler(this.Admin_Event_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowEventsPanel;
        private System.Windows.Forms.Button createEventButton;
        private System.Windows.Forms.Button Back;
        private System.Windows.Forms.Panel mainPanel;
    }
}