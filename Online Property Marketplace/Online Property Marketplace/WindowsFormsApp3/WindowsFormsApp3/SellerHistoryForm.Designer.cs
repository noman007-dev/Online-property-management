namespace WindowsFormsApp3
{
    partial class SellerHistoryForm
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
            this.listViewHistory = new System.Windows.Forms.ListView();
            this.btnviewmessage = new System.Windows.Forms.Button();
            this.viewpropertybutton = new System.Windows.Forms.Button();
            this.gotoaddbutton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.logoutbutton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.lblTotalProperties = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // listViewHistory
            // 
            this.listViewHistory.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(75)))), ((int)(((byte)(23)))), ((int)(((byte)(29)))));
            this.listViewHistory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewHistory.ForeColor = System.Drawing.SystemColors.Window;
            this.listViewHistory.HideSelection = false;
            this.listViewHistory.Location = new System.Drawing.Point(396, 86);
            this.listViewHistory.Name = "listViewHistory";
            this.listViewHistory.Size = new System.Drawing.Size(467, 515);
            this.listViewHistory.TabIndex = 0;
            this.listViewHistory.UseCompatibleStateImageBehavior = false;
            this.listViewHistory.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // btnviewmessage
            // 
            this.btnviewmessage.BackColor = System.Drawing.Color.Transparent;
            this.btnviewmessage.FlatAppearance.BorderSize = 0;
            this.btnviewmessage.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.btnviewmessage.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.btnviewmessage.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnviewmessage.Location = new System.Drawing.Point(31, 454);
            this.btnviewmessage.Name = "btnviewmessage";
            this.btnviewmessage.Size = new System.Drawing.Size(40, 31);
            this.btnviewmessage.TabIndex = 39;
            this.btnviewmessage.UseVisualStyleBackColor = false;
            this.btnviewmessage.Click += new System.EventHandler(this.btnviewmessage_Click);
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
            this.viewpropertybutton.TabIndex = 40;
            this.viewpropertybutton.UseVisualStyleBackColor = false;
            this.viewpropertybutton.Click += new System.EventHandler(this.viewpropertybutton_Click);
            // 
            // gotoaddbutton
            // 
            this.gotoaddbutton.BackColor = System.Drawing.Color.Transparent;
            this.gotoaddbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gotoaddbutton.FlatAppearance.BorderSize = 0;
            this.gotoaddbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.gotoaddbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.gotoaddbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.gotoaddbutton.Location = new System.Drawing.Point(33, 334);
            this.gotoaddbutton.Name = "gotoaddbutton";
            this.gotoaddbutton.Size = new System.Drawing.Size(38, 34);
            this.gotoaddbutton.TabIndex = 41;
            this.gotoaddbutton.UseVisualStyleBackColor = false;
            this.gotoaddbutton.Click += new System.EventHandler(this.gotoaddbutton_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Transparent;
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(33, 274);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(38, 33);
            this.button2.TabIndex = 42;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // logoutbutton
            // 
            this.logoutbutton.BackColor = System.Drawing.Color.Transparent;
            this.logoutbutton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.logoutbutton.FlatAppearance.BorderSize = 0;
            this.logoutbutton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.logoutbutton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.logoutbutton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.logoutbutton.Location = new System.Drawing.Point(31, 596);
            this.logoutbutton.Name = "logoutbutton";
            this.logoutbutton.Size = new System.Drawing.Size(38, 34);
            this.logoutbutton.TabIndex = 43;
            this.logoutbutton.UseVisualStyleBackColor = false;
            this.logoutbutton.Click += new System.EventHandler(this.logoutbutton_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(31, 596);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(38, 34);
            this.button1.TabIndex = 44;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(33, 33);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(38, 34);
            this.button3.TabIndex = 45;
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblTotalProperties
            // 
            this.lblTotalProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalProperties.BackColor = System.Drawing.Color.Transparent;
            this.lblTotalProperties.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalProperties.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTotalProperties.Location = new System.Drawing.Point(390, 43);
            this.lblTotalProperties.Name = "lblTotalProperties";
            this.lblTotalProperties.Size = new System.Drawing.Size(152, 40);
            this.lblTotalProperties.TabIndex = 46;
            this.lblTotalProperties.Text = "History:";
            this.lblTotalProperties.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SellerHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::WindowsFormsApp3.Properties.Resources.seller_history;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1141, 655);
            this.Controls.Add(this.lblTotalProperties);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.logoutbutton);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.gotoaddbutton);
            this.Controls.Add(this.viewpropertybutton);
            this.Controls.Add(this.btnviewmessage);
            this.Controls.Add(this.listViewHistory);
            this.Name = "SellerHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SellerHistoryForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewHistory;
        private System.Windows.Forms.Button btnviewmessage;
        private System.Windows.Forms.Button viewpropertybutton;
        private System.Windows.Forms.Button gotoaddbutton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button logoutbutton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label lblTotalProperties;
    }
}