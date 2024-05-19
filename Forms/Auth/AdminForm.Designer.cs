namespace ChatBot.Forms
{
    partial class AdminForm
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
            this.panelDesktop = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.buttonSubscriptions = new System.Windows.Forms.Button();
            this.buttonCategories = new System.Windows.Forms.Button();
            this.buttonUsers = new System.Windows.Forms.Button();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDesktop
            // 
            this.panelDesktop.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelDesktop.Location = new System.Drawing.Point(193, 0);
            this.panelDesktop.Name = "panelDesktop";
            this.panelDesktop.Size = new System.Drawing.Size(950, 630);
            this.panelDesktop.TabIndex = 0;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(80)))), ((int)(((byte)(87)))));
            this.panelMenu.Controls.Add(this.buttonSubscriptions);
            this.panelMenu.Controls.Add(this.buttonCategories);
            this.panelMenu.Controls.Add(this.buttonUsers);
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(190, 636);
            this.panelMenu.TabIndex = 1;
            // 
            // buttonSubscriptions
            // 
            this.buttonSubscriptions.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonSubscriptions.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSubscriptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonSubscriptions.ForeColor = System.Drawing.Color.White;
            this.buttonSubscriptions.Location = new System.Drawing.Point(3, 95);
            this.buttonSubscriptions.Name = "buttonSubscriptions";
            this.buttonSubscriptions.Size = new System.Drawing.Size(184, 40);
            this.buttonSubscriptions.TabIndex = 2;
            this.buttonSubscriptions.Text = "Subscriptions";
            this.buttonSubscriptions.UseVisualStyleBackColor = true;
            this.buttonSubscriptions.Click += new System.EventHandler(this.buttonSubscriptions_Click);
            // 
            // buttonCategories
            // 
            this.buttonCategories.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonCategories.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCategories.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonCategories.ForeColor = System.Drawing.Color.White;
            this.buttonCategories.Location = new System.Drawing.Point(3, 49);
            this.buttonCategories.Name = "buttonCategories";
            this.buttonCategories.Size = new System.Drawing.Size(184, 40);
            this.buttonCategories.TabIndex = 1;
            this.buttonCategories.Text = "Categories";
            this.buttonCategories.UseVisualStyleBackColor = true;
            this.buttonCategories.Click += new System.EventHandler(this.buttonCategories_Click);
            // 
            // buttonUsers
            // 
            this.buttonUsers.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUsers.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.buttonUsers.ForeColor = System.Drawing.Color.White;
            this.buttonUsers.Location = new System.Drawing.Point(3, 3);
            this.buttonUsers.Name = "buttonUsers";
            this.buttonUsers.Size = new System.Drawing.Size(184, 40);
            this.buttonUsers.TabIndex = 0;
            this.buttonUsers.Text = "Users";
            this.buttonUsers.UseVisualStyleBackColor = true;
            this.buttonUsers.Click += new System.EventHandler(this.buttonUsers_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1146, 636);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelDesktop);
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonUsers;
        private System.Windows.Forms.Button buttonCategories;
        private System.Windows.Forms.Button buttonSubscriptions;
    }
}