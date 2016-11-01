namespace Stratego
{
    partial class ClientStartupForm
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
            this.gebruikersnaam_Textbox = new System.Windows.Forms.TextBox();
            this.gebruikersnaam_label = new System.Windows.Forms.Label();
            this.spelmodus_comboBox = new System.Windows.Forms.ComboBox();
            this.spelmodus_label = new System.Windows.Forms.Label();
            this.ipAdress_label = new System.Windows.Forms.Label();
            this.ipAdress_textbox = new System.Windows.Forms.TextBox();
            this.startbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gebruikersnaam_Textbox
            // 
            this.gebruikersnaam_Textbox.Location = new System.Drawing.Point(41, 51);
            this.gebruikersnaam_Textbox.Name = "gebruikersnaam_Textbox";
            this.gebruikersnaam_Textbox.Size = new System.Drawing.Size(173, 20);
            this.gebruikersnaam_Textbox.TabIndex = 0;
            this.gebruikersnaam_Textbox.TextChanged += new System.EventHandler(this.gebruikersnaam_Textbox_TextChanged);
            // 
            // gebruikersnaam_label
            // 
            this.gebruikersnaam_label.AutoSize = true;
            this.gebruikersnaam_label.Location = new System.Drawing.Point(41, 32);
            this.gebruikersnaam_label.Name = "gebruikersnaam_label";
            this.gebruikersnaam_label.Size = new System.Drawing.Size(84, 13);
            this.gebruikersnaam_label.TabIndex = 1;
            this.gebruikersnaam_label.Text = "Gebruikersnaam";
            this.gebruikersnaam_label.Click += new System.EventHandler(this.label1_Click);
            // 
            // spelmodus_comboBox
            // 
            this.spelmodus_comboBox.FormattingEnabled = true;
            this.spelmodus_comboBox.Location = new System.Drawing.Point(41, 102);
            this.spelmodus_comboBox.Name = "spelmodus_comboBox";
            this.spelmodus_comboBox.Size = new System.Drawing.Size(173, 21);
            this.spelmodus_comboBox.TabIndex = 2;
            this.spelmodus_comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // spelmodus_label
            // 
            this.spelmodus_label.AutoSize = true;
            this.spelmodus_label.Location = new System.Drawing.Point(41, 83);
            this.spelmodus_label.Name = "spelmodus_label";
            this.spelmodus_label.Size = new System.Drawing.Size(59, 13);
            this.spelmodus_label.TabIndex = 3;
            this.spelmodus_label.Text = "Spelmodus";
            this.spelmodus_label.Click += new System.EventHandler(this.label2_Click);
            // 
            // ipAdress_label
            // 
            this.ipAdress_label.AutoSize = true;
            this.ipAdress_label.Location = new System.Drawing.Point(41, 136);
            this.ipAdress_label.Name = "ipAdress_label";
            this.ipAdress_label.Size = new System.Drawing.Size(80, 13);
            this.ipAdress_label.TabIndex = 4;
            this.ipAdress_label.Text = "Server IP-adres";
            // 
            // ipAdress_textbox
            // 
            this.ipAdress_textbox.Location = new System.Drawing.Point(41, 153);
            this.ipAdress_textbox.Name = "ipAdress_textbox";
            this.ipAdress_textbox.Size = new System.Drawing.Size(173, 20);
            this.ipAdress_textbox.TabIndex = 5;
            this.ipAdress_textbox.Text = "localhost";
            this.ipAdress_textbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ipAdress_textbox_MouseClick);
            this.ipAdress_textbox.TextChanged += new System.EventHandler(this.ipAdress_textbox_TextChanged);
            // 
            // startbutton
            // 
            this.startbutton.Location = new System.Drawing.Point(41, 182);
            this.startbutton.Name = "startbutton";
            this.startbutton.Size = new System.Drawing.Size(75, 23);
            this.startbutton.TabIndex = 6;
            this.startbutton.Text = "Start!";
            this.startbutton.UseVisualStyleBackColor = true;
            this.startbutton.Click += new System.EventHandler(this.startbutton_Click);
            // 
            // ClientStartupForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 217);
            this.Controls.Add(this.startbutton);
            this.Controls.Add(this.ipAdress_textbox);
            this.Controls.Add(this.ipAdress_label);
            this.Controls.Add(this.spelmodus_label);
            this.Controls.Add(this.spelmodus_comboBox);
            this.Controls.Add(this.gebruikersnaam_label);
            this.Controls.Add(this.gebruikersnaam_Textbox);
            this.Name = "ClientStartupForm";
            this.Text = "ClientStartup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox gebruikersnaam_Textbox;
        private System.Windows.Forms.Label gebruikersnaam_label;
        private System.Windows.Forms.ComboBox spelmodus_comboBox;
        private System.Windows.Forms.Label spelmodus_label;
        private System.Windows.Forms.Label ipAdress_label;
        private System.Windows.Forms.TextBox ipAdress_textbox;
        private System.Windows.Forms.Button startbutton;
    }
}