namespace WindowsFormsApp3
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.loginnametextBox = new System.Windows.Forms.TextBox();
            this.loginpasstextBox = new System.Windows.Forms.TextBox();
            this.loginrolecomboBox = new System.Windows.Forms.ComboBox();
            this.loginbutton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.signuplinkLabel = new System.Windows.Forms.LinkLabel();
            this.fplinklabel = new System.Windows.Forms.LinkLabel();
            this.txtPassword = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // loginnametextBox
            // 
            this.loginnametextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginnametextBox.BackColor = System.Drawing.Color.DimGray;
            this.loginnametextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginnametextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginnametextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.loginnametextBox.Location = new System.Drawing.Point(417, 260);
            this.loginnametextBox.Multiline = true;
            this.loginnametextBox.Name = "loginnametextBox";
            this.loginnametextBox.Size = new System.Drawing.Size(305, 25);
            this.loginnametextBox.TabIndex = 1;
            // 
            // loginpasstextBox
            // 
            this.loginpasstextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginpasstextBox.BackColor = System.Drawing.Color.DimGray;
            this.loginpasstextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loginpasstextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginpasstextBox.ForeColor = System.Drawing.SystemColors.Window;
            this.loginpasstextBox.Location = new System.Drawing.Point(417, 319);
            this.loginpasstextBox.Multiline = true;
            this.loginpasstextBox.Name = "loginpasstextBox";
            this.loginpasstextBox.PasswordChar = '*';
            this.loginpasstextBox.Size = new System.Drawing.Size(305, 25);
            this.loginpasstextBox.TabIndex = 2;
            this.loginpasstextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // loginrolecomboBox
            // 
            this.loginrolecomboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginrolecomboBox.BackColor = System.Drawing.Color.DimGray;
            this.loginrolecomboBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginrolecomboBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.loginrolecomboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginrolecomboBox.ForeColor = System.Drawing.Color.White;
            this.loginrolecomboBox.FormattingEnabled = true;
            this.loginrolecomboBox.Location = new System.Drawing.Point(417, 381);
            this.loginrolecomboBox.Name = "loginrolecomboBox";
            this.loginrolecomboBox.Size = new System.Drawing.Size(305, 23);
            this.loginrolecomboBox.TabIndex = 12;
            // 
            // loginbutton
            // 
            this.loginbutton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loginbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.loginbutton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginbutton.Location = new System.Drawing.Point(417, 428);
            this.loginbutton.Name = "loginbutton";
            this.loginbutton.Size = new System.Drawing.Size(305, 27);
            this.loginbutton.TabIndex = 13;
            this.loginbutton.Text = "Login";
            this.loginbutton.UseVisualStyleBackColor = true;
            this.loginbutton.Click += new System.EventHandler(this.loginbutton_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(412, 197);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(70, 25);
            this.label6.TabIndex = 14;
            this.label6.Text = "Login";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(414, 241);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 15);
            this.label1.TabIndex = 15;
            this.label1.Text = "Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(414, 301);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(414, 363);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 15);
            this.label4.TabIndex = 17;
            this.label4.Text = "Role";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(479, 513);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(122, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Don\'t have an account?";
            // 
            // signuplinkLabel
            // 
            this.signuplinkLabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.signuplinkLabel.AutoSize = true;
            this.signuplinkLabel.BackColor = System.Drawing.Color.Transparent;
            this.signuplinkLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.signuplinkLabel.LinkColor = System.Drawing.Color.White;
            this.signuplinkLabel.Location = new System.Drawing.Point(602, 511);
            this.signuplinkLabel.Name = "signuplinkLabel";
            this.signuplinkLabel.Size = new System.Drawing.Size(55, 16);
            this.signuplinkLabel.TabIndex = 19;
            this.signuplinkLabel.TabStop = true;
            this.signuplinkLabel.Text = "Signup";
            this.signuplinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // fplinklabel
            // 
            this.fplinklabel.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.fplinklabel.AutoSize = true;
            this.fplinklabel.BackColor = System.Drawing.Color.Transparent;
            this.fplinklabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fplinklabel.LinkColor = System.Drawing.Color.White;
            this.fplinklabel.Location = new System.Drawing.Point(505, 467);
            this.fplinklabel.Name = "fplinklabel";
            this.fplinklabel.Size = new System.Drawing.Size(132, 16);
            this.fplinklabel.TabIndex = 20;
            this.fplinklabel.TabStop = true;
            this.fplinklabel.Text = "Forget Password?";
            this.fplinklabel.Visible = false;
            this.fplinklabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.fplinklabel_LinkClicked);
            // 
            // txtPassword
            // 
            this.txtPassword.AutoSize = true;
            this.txtPassword.BackColor = System.Drawing.Color.Transparent;
            this.txtPassword.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPassword.Location = new System.Drawing.Point(620, 350);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(102, 17);
            this.txtPassword.TabIndex = 21;
            this.txtPassword.Text = "Show Password";
            this.txtPassword.UseVisualStyleBackColor = false;
            this.txtPassword.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 655);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.fplinklabel);
            this.Controls.Add(this.signuplinkLabel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.loginbutton);
            this.Controls.Add(this.loginrolecomboBox);
            this.Controls.Add(this.loginpasstextBox);
            this.Controls.Add(this.loginnametextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox loginnametextBox;
        private System.Windows.Forms.TextBox loginpasstextBox;
        private System.Windows.Forms.ComboBox loginrolecomboBox;
        private System.Windows.Forms.Button loginbutton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.LinkLabel signuplinkLabel;
        private System.Windows.Forms.LinkLabel fplinklabel;
        private System.Windows.Forms.CheckBox txtPassword;
    }
}