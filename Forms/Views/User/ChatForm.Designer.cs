namespace ChatBot.Forms.Views.User
{
    partial class ChatForm
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
            buttonSend = new System.Windows.Forms.Button();
            textBoxPrompt = new System.Windows.Forms.TextBox();
            labelMessages = new System.Windows.Forms.Label();
            labelChat = new System.Windows.Forms.Label();
            SuspendLayout();
            // 
            // buttonSend
            // 
            buttonSend.Anchor = System.Windows.Forms.AnchorStyles.Right;
            buttonSend.Location = new System.Drawing.Point(740, 474);
            buttonSend.Name = "buttonSend";
            buttonSend.Size = new System.Drawing.Size(156, 24);
            buttonSend.TabIndex = 1;
            buttonSend.Text = "Send";
            buttonSend.UseVisualStyleBackColor = true;
            // 
            // textBoxPrompt
            // 
            textBoxPrompt.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxPrompt.Location = new System.Drawing.Point(43, 475);
            textBoxPrompt.Name = "textBoxPrompt";
            textBoxPrompt.Size = new System.Drawing.Size(691, 23);
            textBoxPrompt.TabIndex = 2;
            // 
            // labelMessages
            // 
            labelMessages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            labelMessages.BackColor = System.Drawing.SystemColors.ActiveBorder;
            labelMessages.Location = new System.Drawing.Point(43, 41);
            labelMessages.Name = "labelMessages";
            labelMessages.Size = new System.Drawing.Size(853, 416);
            labelMessages.TabIndex = 3;
            // 
            // labelChat
            // 
            labelChat.AutoSize = true;
            labelChat.Location = new System.Drawing.Point(45, 17);
            labelChat.Name = "labelChat";
            labelChat.Size = new System.Drawing.Size(32, 15);
            labelChat.TabIndex = 4;
            labelChat.Text = "Chat";
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(labelChat);
            Controls.Add(labelMessages);
            Controls.Add(textBoxPrompt);
            Controls.Add(buttonSend);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ChatForm";
            Text = "ChatForm";
            Load += ChatForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.Label labelMessages;
        private System.Windows.Forms.Label labelChat;
    }
}