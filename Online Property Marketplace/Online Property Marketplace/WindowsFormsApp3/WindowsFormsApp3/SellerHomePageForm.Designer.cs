namespace WindowsFormsApp3
{
    partial class SellerHomePageForm
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
            this.lblTotal = new System.Windows.Forms.Label();
            this.lblActive = new System.Windows.Forms.Label();
            this.lblSold = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.gotoaddbutton = new System.Windows.Forms.Button();
            this.logoutbutton = new System.Windows.Forms.Button();
            this.viewpropertybutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btnviewmessage = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnSellerGuide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTotal
            // 
            this.lblTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotal.BackColor = System.Drawing.Color.Transparent;
            this.lblTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotal.Location = new System.Drawing.Point(904, 218);
            this.lblTotal.Name = "lblTotal";
            this.lblTotal.Size = new System.Drawing.Size(106, 37);
            this.lblTotal.TabIndex = 0;
            this.lblTotal.Text = "label1";
            this.lblTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTotal.Click += new System.EventHandler(this.lblTotal_Click);
            // 
            // lblActive
            // 
            this.lblActive.BackColor = System.Drawing.Color.Transparent;
            this.lblActive.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblActive.Location = new System.Drawing.Point(904, 362);
            this.lblActive.Name = "lblActive";
            this.lblActive.Size = new System.Drawing.Size(108, 37);
            this.lblActive.TabIndex = 1;
            this.lblActive.Text = "label2";
            this.lblActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSold
            // 
            this.lblSold.BackColor = System.Drawing.Color.Transparent;
            this.lblSold.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSold.Location = new System.Drawing.Point(904, 506);
            this.lblSold.Name = "lblSold";
            this.lblSold.Size = new System.Drawing.Size(108, 37);
            this.lblSold.TabIndex = 2;
            this.lblSold.Text = "label3";
            this.lblSold.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.SystemColors.WindowText;
            this.listView1.BackgroundImage = global::WindowsFormsApp3.Properties.Resources.SH;
            this.listView1.BackgroundImageTiled = true;
            this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listView1.ForeColor = System.Drawing.Color.White;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(132, 132);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(662, 453);
            this.listView1.TabIndex = 3;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(887, 170);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 24);
            this.label1.TabIndex = 4;
            this.label1.Text = "Total Property";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(882, 314);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Active Property";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(887, 459);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(136, 24);
            this.label3.TabIndex = 6;
            this.label3.Text = "Property Sold";
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
            this.label6.Location = new System.Drawing.Point(886, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Quick Stats";
            // 
            // gotoaddbutton
            // 
            this.gotoaddbutton.BackColor = System.Drawing.Color.Transparent;
            this.gotoaddbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gotoaddbutton.FlatAppearance.BorderSize = 0;
            this.gotoaddbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.gotoaddbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.gotoaddbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotoaddbutton.Location = new System.Drawing.Point(32, 333);
            this.gotoaddbutton.Name = "gotoaddbutton";
            this.gotoaddbutton.Size = new System.Drawing.Size(38, 34);
            this.gotoaddbutton.TabIndex = 31;
            this.gotoaddbutton.UseVisualStyleBackColor = false;
            this.gotoaddbutton.Click += new System.EventHandler(this.gotoaddbutton_Click);
            // 
            // logoutbutton
            // 
            this.logoutbutton.BackColor = System.Drawing.Color.Transparent;
            this.logoutbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutbutton.FlatAppearance.BorderSize = 0;
            this.logoutbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.logoutbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.logoutbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutbutton.Location = new System.Drawing.Point(32, 595);
            this.logoutbutton.Name = "logoutbutton";
            this.logoutbutton.Size = new System.Drawing.Size(38, 34);
            this.logoutbutton.TabIndex = 32;
            this.logoutbutton.UseVisualStyleBackColor = false;
            this.logoutbutton.Click += new System.EventHandler(this.logoutbutton_Click);
            // 
            // viewpropertybutton
            // 
            this.viewpropertybutton.BackColor = System.Drawing.Color.Transparent;
            this.viewpropertybutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.viewpropertybutton.FlatAppearance.BorderSize = 0;
            this.viewpropertybutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.viewpropertybutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.viewpropertybutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewpropertybutton.Location = new System.Drawing.Point(31, 401);
            this.viewpropertybutton.Name = "viewpropertybutton";
            this.viewpropertybutton.Size = new System.Drawing.Size(38, 23);
            this.viewpropertybutton.TabIndex = 33;
            this.viewpropertybutton.UseVisualStyleBackColor = false;
            this.viewpropertybutton.Click += new System.EventHandler(this.viewpropertybutton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(30, 34);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 34);
            this.button1.TabIndex = 34;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft YaHei UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.Window;
            this.label4.Location = new System.Drawing.Point(126, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(517, 31);
            this.label4.TabIndex = 35;
            this.label4.Text = "Welcome to Online Property Marketplace";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft YaHei UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.Window;
            this.label5.Location = new System.Drawing.Point(128, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(521, 22);
            this.label5.TabIndex = 36;
            this.label5.Text = "Find your dream property to buy or rent. Easy, fast, and secure";
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.Transparent;
            this.button2.Location = new System.Drawing.Point(1022, 65);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 41);
            this.button2.TabIndex = 37;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnviewmessage
            // 
            this.btnviewmessage.BackColor = System.Drawing.Color.Transparent;
            this.btnviewmessage.FlatAppearance.BorderSize = 0;
            this.btnviewmessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnviewmessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnviewmessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewmessage.Location = new System.Drawing.Point(30, 452);
            this.btnviewmessage.Name = "btnviewmessage";
            this.btnviewmessage.Size = new System.Drawing.Size(40, 31);
            this.btnviewmessage.TabIndex = 38;
            this.btnviewmessage.UseVisualStyleBackColor = false;
            this.btnviewmessage.Click += new System.EventHandler(this.btnviewmessage_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.Transparent;
            this.btnHistory.FlatAppearance.BorderSize = 0;
            this.btnHistory.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnHistory.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.Location = new System.Drawing.Point(33, 517);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(37, 35);
            this.btnHistory.TabIndex = 39;
            this.btnHistory.UseVisualStyleBackColor = false;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnSellerGuide
            // 
            this.btnSellerGuide.BackColor = System.Drawing.Color.Transparent;
            this.btnSellerGuide.FlatAppearance.BorderSize = 0;
            this.btnSellerGuide.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnSellerGuide.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnSellerGuide.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSellerGuide.Location = new System.Drawing.Point(853, 71);
            this.btnSellerGuide.Name = "btnSellerGuide";
            this.btnSellerGuide.Size = new System.Drawing.Size(37, 35);
            this.btnSellerGuide.TabIndex = 40;
            this.btnSellerGuide.UseVisualStyleBackColor = false;
            this.btnSellerGuide.Click += new System.EventHandler(this.button3_Click);
            // 
            // SellerHomePageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp3.Properties.Resources.seller_home;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 655);
            this.Controls.Add(this.btnSellerGuide);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnviewmessage);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.viewpropertybutton);
            this.Controls.Add(this.logoutbutton);
            this.Controls.Add(this.gotoaddbutton);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lblSold);
            this.Controls.Add(this.lblActive);
            this.Controls.Add(this.lblTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SellerHomePageForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerHomePageForm";
            this.Load += new System.EventHandler(this.SellerHomePageForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTotal;
        private System.Windows.Forms.Label lblActive;
        private System.Windows.Forms.Label lblSold;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button gotoaddbutton;
        private System.Windows.Forms.Button logoutbutton;
        private System.Windows.Forms.Button viewpropertybutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnviewmessage;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnSellerGuide;
    }
}