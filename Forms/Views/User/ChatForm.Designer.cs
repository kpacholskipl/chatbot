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
            labelChat = new System.Windows.Forms.Label();
            panel1 = new System.Windows.Forms.Panel();
            textBoxMessages = new System.Windows.Forms.TextBox();
            panel1.SuspendLayout();
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
            buttonSend.Click += buttonSend_Click;
            // 
            // textBoxPrompt
            // 
            textBoxPrompt.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxPrompt.Location = new System.Drawing.Point(43, 475);
            textBoxPrompt.Name = "textBoxPrompt";
            textBoxPrompt.Size = new System.Drawing.Size(691, 23);
            textBoxPrompt.TabIndex = 2;
            // 
            // labelChat
            // 
            labelChat.AutoSize = true;
            labelChat.Location = new System.Drawing.Point(43, 37);
            labelChat.Name = "labelChat";
            labelChat.Size = new System.Drawing.Size(32, 15);
            labelChat.TabIndex = 4;
            labelChat.Text = "Chat";
            // 
            // panel1
            // 
            panel1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            panel1.AutoScroll = true;
            panel1.Controls.Add(textBoxMessages);
            panel1.Location = new System.Drawing.Point(43, 55);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(878, 414);
            panel1.TabIndex = 5;
            // 
            // textBoxMessages
            // 
            textBoxMessages.AcceptsReturn = true;
            textBoxMessages.AcceptsTab = true;
            textBoxMessages.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            textBoxMessages.Location = new System.Drawing.Point(3, 3);
            textBoxMessages.Multiline = true;
            textBoxMessages.Name = "textBoxMessages";
            textBoxMessages.ReadOnly = true;
            textBoxMessages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            textBoxMessages.Size = new System.Drawing.Size(849, 392);
            textBoxMessages.TabIndex = 0;
            // 
            // ChatForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(933, 519);
            Controls.Add(panel1);
            Controls.Add(labelChat);
            Controls.Add(textBoxPrompt);
            Controls.Add(buttonSend);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "ChatForm";
            Text = "ChatForm";
            //Load += ChatForm_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.TextBox textBoxPrompt;
        private System.Windows.Forms.Label labelChat;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxMessages;
    }
}