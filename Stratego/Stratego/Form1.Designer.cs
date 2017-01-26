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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BoardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ReadyButton = new System.Windows.Forms.Button();
            this.IsTurnLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BoardPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("BoardPanel.BackgroundImage")));
            this.BoardPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BoardPanel.Location = new System.Drawing.Point(12, 15);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(850, 922);
            this.BoardPanel.TabIndex = 4;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.BackColor = System.Drawing.Color.DarkGray;
            this.ButtonPanel.Location = new System.Drawing.Point(868, 15);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(393, 881);
            this.ButtonPanel.TabIndex = 5;
            // 
            // ReadyButton
            // 
            this.ReadyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ReadyButton.Location = new System.Drawing.Point(1175, 899);
            this.ReadyButton.Name = "ReadyButton";
            this.ReadyButton.Size = new System.Drawing.Size(86, 38);
            this.ReadyButton.TabIndex = 10;
            this.ReadyButton.Text = "Ready to game!";
            this.ReadyButton.UseVisualStyleBackColor = true;
            this.ReadyButton.Click += new System.EventHandler(this.ReadyButton_Click);
            // 
            // IsTurnLabel
            // 
            this.IsTurnLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.IsTurnLabel.AutoSize = true;
            this.IsTurnLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsTurnLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.IsTurnLabel.Location = new System.Drawing.Point(868, 899);
            this.IsTurnLabel.Name = "IsTurnLabel";
            this.IsTurnLabel.Size = new System.Drawing.Size(54, 16);
            this.IsTurnLabel.TabIndex = 11;
            this.IsTurnLabel.Text = "Ready";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.ClientSize = new System.Drawing.Size(1270, 1053);
            this.Controls.Add(this.IsTurnLabel);
            this.Controls.Add(this.ReadyButton);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.BoardPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel BoardPanel;
        private System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button ReadyButton;
        private System.Windows.Forms.Label IsTurnLabel;
    }
}

