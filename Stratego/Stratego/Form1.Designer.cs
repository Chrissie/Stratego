namespace Stratego
{
    partial class Form1
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
            this.joinButton = new System.Windows.Forms.Button();
            this.hostButton = new System.Windows.Forms.Button();
            this.menuPanel = new System.Windows.Forms.Panel();
            this.searchHostPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.searchPlayerPanel = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.backButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.menuPanel.SuspendLayout();
            this.searchHostPanel.SuspendLayout();
            this.searchPlayerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // joinButton
            // 
            this.joinButton.Location = new System.Drawing.Point(127, 199);
            this.joinButton.Name = "joinButton";
            this.joinButton.Size = new System.Drawing.Size(282, 162);
            this.joinButton.TabIndex = 0;
            this.joinButton.Text = "Join Game";
            this.joinButton.UseVisualStyleBackColor = true;
            this.joinButton.Click += new System.EventHandler(this.joinButton_Click);
            // 
            // hostButton
            // 
            this.hostButton.Location = new System.Drawing.Point(469, 199);
            this.hostButton.Name = "hostButton";
            this.hostButton.Size = new System.Drawing.Size(282, 162);
            this.hostButton.TabIndex = 1;
            this.hostButton.Text = "Host Game";
            this.hostButton.UseVisualStyleBackColor = true;
            this.hostButton.Click += new System.EventHandler(this.hostButton_Click);
            // 
            // menuPanel
            // 
            this.menuPanel.Controls.Add(this.joinButton);
            this.menuPanel.Controls.Add(this.hostButton);
            this.menuPanel.Location = new System.Drawing.Point(12, 12);
            this.menuPanel.Name = "menuPanel";
            this.menuPanel.Size = new System.Drawing.Size(886, 557);
            this.menuPanel.TabIndex = 2;
            // 
            // searchHostPanel
            // 
            this.searchHostPanel.Controls.Add(this.button1);
            this.searchHostPanel.Controls.Add(this.label1);
            this.searchHostPanel.Location = new System.Drawing.Point(12, 12);
            this.searchHostPanel.Name = "searchHostPanel";
            this.searchHostPanel.Size = new System.Drawing.Size(886, 557);
            this.searchHostPanel.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(359, 157);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Searching for host...";
            // 
            // searchPlayerPanel
            // 
            this.searchPlayerPanel.Controls.Add(this.backButton);
            this.searchPlayerPanel.Controls.Add(this.label2);
            this.searchPlayerPanel.Location = new System.Drawing.Point(12, 12);
            this.searchPlayerPanel.Name = "searchPlayerPanel";
            this.searchPlayerPanel.Size = new System.Drawing.Size(886, 557);
            this.searchPlayerPanel.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(383, 248);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Searching for player...";
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(403, 486);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 1;
            this.backButton.Text = "Back";
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.backButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(375, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Back";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.backButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1893, 1268);
            this.Controls.Add(this.searchPlayerPanel);
            this.Controls.Add(this.searchHostPanel);
            this.Controls.Add(this.menuPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuPanel.ResumeLayout(false);
            this.searchHostPanel.ResumeLayout(false);
            this.searchHostPanel.PerformLayout();
            this.searchPlayerPanel.ResumeLayout(false);
            this.searchPlayerPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button joinButton;
        private System.Windows.Forms.Button hostButton;
        private System.Windows.Forms.Panel menuPanel;
        private System.Windows.Forms.Panel searchHostPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel searchPlayerPanel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button backButton;
    }
}

