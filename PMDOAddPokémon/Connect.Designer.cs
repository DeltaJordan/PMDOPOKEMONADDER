namespace PMDOAddPokémon
{
    partial class Connect
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
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbDBName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.growLabel4 = new GrowLabel();
            this.glblDBName = new GrowLabel();
            this.glblPass = new GrowLabel();
            this.glblUser = new GrowLabel();
            this.glblPort = new GrowLabel();
            this.glblIP = new GrowLabel();
            this.glHeader = new GrowLabel();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(136, 48);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(177, 20);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "localhost";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(136, 73);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(177, 20);
            this.tbPort.TabIndex = 1;
            this.tbPort.Text = "3306";
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(136, 99);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(177, 20);
            this.tbUser.TabIndex = 2;
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(136, 126);
            this.tbPass.Name = "tbPass";
            this.tbPass.Size = new System.Drawing.Size(177, 20);
            this.tbPass.TabIndex = 3;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // tbDBName
            // 
            this.tbDBName.Location = new System.Drawing.Point(136, 155);
            this.tbDBName.Name = "tbDBName";
            this.tbDBName.Size = new System.Drawing.Size(177, 20);
            this.tbDBName.TabIndex = 4;
            this.tbDBName.Text = "pmu_data";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 203);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 5;
            this.button1.Text = "Connect!";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // growLabel4
            // 
            this.growLabel4.AutoSize = true;
            this.growLabel4.Location = new System.Drawing.Point(192, 239);
            this.growLabel4.Name = "growLabel4";
            this.growLabel4.Size = new System.Drawing.Size(121, 13);
            this.growLabel4.TabIndex = 3;
            this.growLabel4.Text = "© 2016 JordantheBuizel";
            // 
            // glblDBName
            // 
            this.glblDBName.AutoSize = true;
            this.glblDBName.Location = new System.Drawing.Point(17, 158);
            this.glblDBName.Name = "glblDBName";
            this.glblDBName.Size = new System.Drawing.Size(113, 13);
            this.glblDBName.TabIndex = 2;
            this.glblDBName.Text = "Data Database Name:";
            // 
            // glblPass
            // 
            this.glblPass.AutoSize = true;
            this.glblPass.Location = new System.Drawing.Point(36, 129);
            this.glblPass.Name = "glblPass";
            this.glblPass.Size = new System.Drawing.Size(94, 13);
            this.glblPass.TabIndex = 2;
            this.glblPass.Text = "MySQL Password:";
            // 
            // glblUser
            // 
            this.glblUser.AutoSize = true;
            this.glblUser.Location = new System.Drawing.Point(34, 102);
            this.glblUser.Name = "glblUser";
            this.glblUser.Size = new System.Drawing.Size(96, 13);
            this.glblUser.TabIndex = 2;
            this.glblUser.Text = "MySQL Username:";
            // 
            // glblPort
            // 
            this.glblPort.AutoSize = true;
            this.glblPort.Location = new System.Drawing.Point(63, 76);
            this.glblPort.Name = "glblPort";
            this.glblPort.Size = new System.Drawing.Size(67, 13);
            this.glblPort.TabIndex = 2;
            this.glblPort.Text = "MySQL Port:";
            // 
            // glblIP
            // 
            this.glblIP.AutoSize = true;
            this.glblIP.Location = new System.Drawing.Point(73, 51);
            this.glblIP.Name = "glblIP";
            this.glblIP.Size = new System.Drawing.Size(57, 13);
            this.glblIP.TabIndex = 2;
            this.glblIP.Text = "MySQL Ip:";
            // 
            // glHeader
            // 
            this.glHeader.Location = new System.Drawing.Point(12, 9);
            this.glHeader.Name = "glHeader";
            this.glHeader.Size = new System.Drawing.Size(300, 26);
            this.glHeader.TabIndex = 1;
            this.glHeader.Text = "Welcome! Before we start adding Pokémon to the MySql Server, we need some info.";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.Location = new System.Drawing.Point(160, 203);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Visible = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(0, 239);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Debug";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Connect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(325, 261);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbDBName);
            this.Controls.Add(this.tbPass);
            this.Controls.Add(this.tbUser);
            this.Controls.Add(this.tbPort);
            this.Controls.Add(this.tbIP);
            this.Controls.Add(this.growLabel4);
            this.Controls.Add(this.glblDBName);
            this.Controls.Add(this.glblPass);
            this.Controls.Add(this.glblUser);
            this.Controls.Add(this.glblPort);
            this.Controls.Add(this.glblIP);
            this.Controls.Add(this.glHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Connect";
            this.Text = "Add Pokémon";
            this.Load += new System.EventHandler(this.AddPoke_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GrowLabel glHeader;
        private GrowLabel glblIP;
        private GrowLabel glblPort;
        private GrowLabel glblDBName;
        private GrowLabel growLabel4;
        private GrowLabel glblUser;
        private GrowLabel glblPass;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbDBName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button button2;
    }
}

