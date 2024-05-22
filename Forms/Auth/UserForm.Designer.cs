namespace ChatBot.Forms
{
    partial class UserForm
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
            panelDesktop = new System.Windows.Forms.Panel();
            labelWelcome = new System.Windows.Forms.Label();
            panelMenu = new System.Windows.Forms.Panel();
            buttonMyAccount = new System.Windows.Forms.Button();
            buttonHistory = new System.Windows.Forms.Button();
            buttonChat = new System.Windows.Forms.Button();
            panelDesktop.SuspendLayout();
            panelMenu.SuspendLayout();
            SuspendLayout();
            // 
            // panelDesktop
            // 
            panelDesktop.Controls.Add(labelWelcome);
            panelDesktop.Location = new System.Drawing.Point(198, 0);
            panelDesktop.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new System.Drawing.Size(740, 519);
            panelDesktop.TabIndex = 0;
            panelDesktop.Paint += panelDesktop_Paint;
            // 
            // labelWelcome
            // 
            labelWelcome.AutoSize = true;
            labelWelcome.Font = new System.Drawing.Font("Segoe UI", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            labelWelcome.Location = new System.Drawing.Point(139, 173);
            labelWelcome.Name = "labelWelcome";
            labelWelcome.Size = new System.Drawing.Size(471, 128);
            labelWelcome.TabIndex = 0;
            labelWelcome.Text = "Welcome";
            // 
            // panelMenu
            // 
            panelMenu.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            panelMenu.BackColor = System.Drawing.Color.FromArgb(73, 80, 87);
            panelMenu.Controls.Add(buttonMyAccount);
            panelMenu.Controls.Add(buttonHistory);
            panelMenu.Controls.Add(buttonChat);
            panelMenu.Location = new System.Drawing.Point(0, 0);
            panelMenu.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new System.Drawing.Size(198, 519);
            panelMenu.TabIndex = 1;
            // 
            // buttonMyAccount
            // 
            buttonMyAccount.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonMyAccount.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonMyAccount.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            buttonMyAccount.ForeColor = System.Drawing.Color.White;
            buttonMyAccount.Location = new System.Drawing.Point(4, 110);
            buttonMyAccount.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonMyAccount.Name = "buttonMyAccount";
            buttonMyAccount.Size = new System.Drawing.Size(191, 46);
            buttonMyAccount.TabIndex = 2;
            buttonMyAccount.Text = "My Account";
            buttonMyAccount.UseVisualStyleBackColor = true;
            buttonMyAccount.Click += buttonMyAccount_Click;
            // 
            // buttonHistory
            // 
            buttonHistory.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonHistory.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            buttonHistory.ForeColor = System.Drawing.Color.White;
            buttonHistory.Location = new System.Drawing.Point(4, 57);
            buttonHistory.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonHistory.Name = "buttonHistory";
            buttonHistory.Size = new System.Drawing.Size(191, 46);
            buttonHistory.TabIndex = 1;
            buttonHistory.Text = "History";
            buttonHistory.UseVisualStyleBackColor = true;
            buttonHistory.Click += buttonHistory_Click;
            // 
            // buttonChat
            // 
            buttonChat.Cursor = System.Windows.Forms.Cursors.Hand;
            buttonChat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            buttonChat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            buttonChat.ForeColor = System.Drawing.Color.White;
            buttonChat.Location = new System.Drawing.Point(4, 3);
            buttonChat.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            buttonChat.Name = "buttonChat";
            buttonChat.Size = new System.Drawing.Size(191, 46);
            buttonChat.TabIndex = 0;
            buttonChat.Text = "Chat";
            buttonChat.UseVisualStyleBackColor = true;
            buttonChat.Click += buttonChat_Click;
            // 
            // UserForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(panelMenu);
            Controls.Add(panelDesktop);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UserForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "UserForm";
            Load += UserForm_Load;
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            panelMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panelDesktop;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button buttonChat;
        private System.Windows.Forms.Button buttonMyAccount;
        private System.Windows.Forms.Button buttonHistory;
        private System.Windows.Forms.Label labelWelcome;
    }
}