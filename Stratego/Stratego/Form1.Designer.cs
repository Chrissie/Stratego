﻿namespace Stratego
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.GameDialog = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
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
            this.ButtonPanel.Location = new System.Drawing.Point(935, 462);
            this.ButtonPanel.Name = "ButtonPanel";
            this.ButtonPanel.Size = new System.Drawing.Size(393, 516);
            this.ButtonPanel.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(1334, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 37);
            this.button1.TabIndex = 6;
            this.button1.Text = "Save gameboard";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1334, 80);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 40);
            this.button2.TabIndex = 7;
            this.button2.Text = "Update GUI";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GameDialog
            // 
            this.GameDialog.Location = new System.Drawing.Point(935, 15);
            this.GameDialog.Multiline = true;
            this.GameDialog.Name = "GameDialog";
            this.GameDialog.ReadOnly = true;
            this.GameDialog.Size = new System.Drawing.Size(393, 424);
            this.GameDialog.TabIndex = 8;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(1334, 141);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(86, 40);
            this.button3.TabIndex = 9;
            this.button3.Text = "Send gameboard";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1441, 598);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.GameDialog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox GameDialog;
        private System.Windows.Forms.Button button3;
    }
}

