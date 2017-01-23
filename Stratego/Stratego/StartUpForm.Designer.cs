namespace Stratego
{
    partial class StartUpForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.TitleBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(77, 106);
            this.button1.Name = "saveButton";
            this.button1.Size = new System.Drawing.Size(232, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ik wil stratego spelen";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // UpdateGUIButton
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(77, 135);
            this.button2.Name = "UpdateGUIButton";
            this.button2.Size = new System.Drawing.Size(232, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "Ik wil een stratego gameserver opzetten";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // TitleBox
            // 
            this.TitleBox.BackColor = System.Drawing.Color.Azure;
            this.TitleBox.Cursor = System.Windows.Forms.Cursors.No;
            this.TitleBox.Font = new System.Drawing.Font("Bauhaus 93", 37.25F);
            this.TitleBox.Location = new System.Drawing.Point(77, 12);
            this.TitleBox.Name = "TitleBox";
            this.TitleBox.Size = new System.Drawing.Size(232, 80);
            this.TitleBox.TabIndex = 2;
            this.TitleBox.Text = "STRATEGO";
            // 
            // StartUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkBlue;
            this.ClientSize = new System.Drawing.Size(399, 248);
            this.Controls.Add(this.TitleBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "StartUpForm";
            this.Text = "StartUpForm";
            this.Load += new System.EventHandler(this.StartUpForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox TitleBox;
    }
}