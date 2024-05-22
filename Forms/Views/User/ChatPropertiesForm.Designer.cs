namespace ChatBot.Forms.Views.User
{
    partial class ChatPropertiesForm
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
            labelTitle = new System.Windows.Forms.Label();
            textBoxTitle = new System.Windows.Forms.TextBox();
            comboBoxCategory = new System.Windows.Forms.ComboBox();
            labelCategory = new System.Windows.Forms.Label();
            buttonOK = new System.Windows.Forms.Button();
            buttonCancel = new System.Windows.Forms.Button();
            SuspendLayout();
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Location = new System.Drawing.Point(54, 37);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new System.Drawing.Size(29, 15);
            labelTitle.TabIndex = 0;
            labelTitle.Text = "Title";
            // 
            // textBoxTitle
            // 
            textBoxTitle.Location = new System.Drawing.Point(54, 55);
            textBoxTitle.Name = "textBoxTitle";
            textBoxTitle.Size = new System.Drawing.Size(234, 23);
            textBoxTitle.TabIndex = 1;
            // 
            // comboBoxCategory
            // 
            comboBoxCategory.FormattingEnabled = true;
            comboBoxCategory.Location = new System.Drawing.Point(54, 121);
            comboBoxCategory.Name = "comboBoxCategory";
            comboBoxCategory.Size = new System.Drawing.Size(234, 23);
            comboBoxCategory.TabIndex = 2;
            // 
            // labelCategory
            // 
            labelCategory.AutoSize = true;
            labelCategory.Location = new System.Drawing.Point(54, 103);
            labelCategory.Name = "labelCategory";
            labelCategory.Size = new System.Drawing.Size(55, 15);
            labelCategory.TabIndex = 3;
            labelCategory.Text = "Category";
            // 
            // buttonOK
            // 
            buttonOK.Location = new System.Drawing.Point(176, 178);
            buttonOK.Name = "buttonOK";
            buttonOK.Size = new System.Drawing.Size(112, 23);
            buttonOK.TabIndex = 4;
            buttonOK.Text = "OK";
            buttonOK.UseVisualStyleBackColor = true;
            buttonOK.Click += buttonOK_Click;
            // 
            // buttonCancel
            // 
            buttonCancel.Location = new System.Drawing.Point(54, 178);
            buttonCancel.Name = "buttonCancel";
            buttonCancel.Size = new System.Drawing.Size(112, 23);
            buttonCancel.TabIndex = 5;
            buttonCancel.Text = "Cancel";
            buttonCancel.UseVisualStyleBackColor = true;
            buttonCancel.Click += buttonCancel_Click;
            // 
            // ChatPropertiesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(341, 240);
            Controls.Add(buttonCancel);
            Controls.Add(buttonOK);
            Controls.Add(labelCategory);
            Controls.Add(comboBoxCategory);
            Controls.Add(textBoxTitle);
            Controls.Add(labelTitle);
            Name = "ChatPropertiesForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "ChatPropertiesForm";
            Load += ChatPropertiesForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.ComboBox comboBoxCategory;
        private System.Windows.Forms.Label labelCategory;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
    }
}