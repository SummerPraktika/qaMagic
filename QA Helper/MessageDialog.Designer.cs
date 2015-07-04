namespace QA_Helper
{
    partial class MessageDialog
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
            this.continueButton = new System.Windows.Forms.Button();
            this.errorTxt = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // continueButton
            // 
            this.continueButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.continueButton.Location = new System.Drawing.Point(43, 62);
            this.continueButton.Margin = new System.Windows.Forms.Padding(3, 3, 3, 8);
            this.continueButton.Name = "continueButton";
            this.continueButton.Size = new System.Drawing.Size(95, 23);
            this.continueButton.TabIndex = 1;
            this.continueButton.Text = "Продолжить";
            this.continueButton.UseVisualStyleBackColor = true;
            this.continueButton.Click += new System.EventHandler(this.continueButton_Click);
            // 
            // errorTxt
            // 
            this.errorTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.errorTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorTxt.Location = new System.Drawing.Point(12, 12);
            this.errorTxt.Multiline = true;
            this.errorTxt.Name = "errorTxt";
            this.errorTxt.ReadOnly = true;
            this.errorTxt.Size = new System.Drawing.Size(166, 44);
            this.errorTxt.TabIndex = 2;
            this.errorTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MessageDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(187, 106);
            this.Controls.Add(this.errorTxt);
            this.Controls.Add(this.continueButton);
            this.Name = "MessageDialog";
            this.Text = "Ошибка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button continueButton;
        public System.Windows.Forms.TextBox errorTxt;
    }
}