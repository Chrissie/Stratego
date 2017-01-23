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
            this.BoardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.ButtonPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.saveButton = new System.Windows.Forms.Button();
            this.UpdateGUIButton = new System.Windows.Forms.Button();
            this.SendBoardButton = new System.Windows.Forms.Button();
            this.ChangeStateButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardPanel
            // 
            this.BoardPanel.Location = new System.Drawing.Point(12, 15);
            this.BoardPanel.Name = "BoardPanel";
            this.BoardPanel.Size = new System.Drawing.Size(903, 963);
            this.BoardPanel.TabIndex = 4;
            // 
            // ButtonPanel
            // 
            this.ButtonPanel.Location = new System.Drawing.Point(935, 15);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(393, 963);
            this.ButtonPanel.TabIndex = 5;
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(1334, 15);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(86, 37);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save gameboard";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateGUIButton
            // 
            this.UpdateGUIButton.Location = new System.Drawing.Point(1334, 58);
            this.UpdateGUIButton.Name = "UpdateGUIButton";
            this.UpdateGUIButton.Size = new System.Drawing.Size(86, 40);
            this.UpdateGUIButton.TabIndex = 7;
            this.UpdateGUIButton.Text = "Update GUI";
            this.UpdateGUIButton.UseVisualStyleBackColor = true;
            this.UpdateGUIButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // SendBoardButton
            // 
            this.SendBoardButton.Location = new System.Drawing.Point(1334, 104);
            this.SendBoardButton.Name = "SendBoardButton";
            this.SendBoardButton.Size = new System.Drawing.Size(86, 44);
            this.SendBoardButton.TabIndex = 8;
            this.SendBoardButton.Text = "Send Gameboard";
            this.SendBoardButton.UseVisualStyleBackColor = true;
            this.SendBoardButton.Click += new System.EventHandler(this.button4_Click);
            // 
            // ChangeStateButton
            // 
            this.ChangeStateButton.Location = new System.Drawing.Point(1334, 154);
            this.ChangeStateButton.Name = "ChangeStateButton";
            this.ChangeStateButton.Size = new System.Drawing.Size(86, 23);
            this.ChangeStateButton.TabIndex = 9;
            this.ChangeStateButton.Text = "Change State";
            this.ChangeStateButton.UseVisualStyleBackColor = true;
            this.ChangeStateButton.Click += new System.EventHandler(this.button5_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1441, 598);
            this.Controls.Add(this.ChangeStateButton);
            this.Controls.Add(this.SendBoardButton);
            this.Controls.Add(this.UpdateGUIButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.ButtonPanel);
            this.Controls.Add(this.BoardPanel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel BoardPanel;
        private System.Windows.Forms.FlowLayoutPanel ButtonPanel;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button UpdateGUIButton;
        private System.Windows.Forms.Button SendBoardButton;
        private System.Windows.Forms.Button ChangeStateButton;
    }
}

