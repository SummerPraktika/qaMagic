using System.Windows.Forms;
namespace QA_Helper
{
    partial class settingsForm
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
            this.formatBox = new System.Windows.Forms.ComboBox();
            this.encodingBox = new System.Windows.Forms.ComboBox();
            this.delimeterBox = new System.Windows.Forms.ComboBox();
            this.recordsCountTxt = new System.Windows.Forms.TextBox();
            this.formatLbl = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.encodingLbl = new System.Windows.Forms.Label();
            this.delimeterLbl = new System.Windows.Forms.Label();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // formatBox
            // 
            this.formatBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.formatBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formatBox.FormattingEnabled = true;
            this.formatBox.Items.AddRange(new object[] {
            "CSV"});
            this.formatBox.Location = new System.Drawing.Point(119, 9);
            this.formatBox.Name = "formatBox";
            this.formatBox.Size = new System.Drawing.Size(121, 21);
            this.formatBox.TabIndex = 14;
            // 
            // encodingBox
            // 
            this.encodingBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.encodingBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encodingBox.FormattingEnabled = true;
            this.encodingBox.Items.AddRange(new object[] {
            "UTF-8",
            "UTF-16",
            "Unicode",
            "windows-1251"});
            this.encodingBox.Location = new System.Drawing.Point(119, 63);
            this.encodingBox.Name = "encodingBox";
            this.encodingBox.Size = new System.Drawing.Size(121, 21);
            this.encodingBox.TabIndex = 13;
            // 
            // delimeterBox
            // 
            this.delimeterBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.delimeterBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delimeterBox.FormattingEnabled = true;
            this.delimeterBox.Items.AddRange(new object[] {
            "Точка",
            "Запятая",
            "Точка с запятой",
            "Пробел",
            "Табуляция"});
            this.delimeterBox.Location = new System.Drawing.Point(119, 36);
            this.delimeterBox.Name = "delimeterBox";
            this.delimeterBox.Size = new System.Drawing.Size(121, 21);
            this.delimeterBox.TabIndex = 12;
            // 
            // recordsCountTxt
            // 
            this.recordsCountTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recordsCountTxt.Location = new System.Drawing.Point(119, 90);
            this.recordsCountTxt.Name = "recordsCountTxt";
            this.recordsCountTxt.Size = new System.Drawing.Size(121, 22);
            this.recordsCountTxt.TabIndex = 11;
            this.recordsCountTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValidate);
            // 
            // formatLbl
            // 
            this.formatLbl.AutoSize = true;
            this.formatLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.formatLbl.Location = new System.Drawing.Point(12, 13);
            this.formatLbl.Name = "formatLbl";
            this.formatLbl.Size = new System.Drawing.Size(54, 17);
            this.formatLbl.TabIndex = 6;
            this.formatLbl.Text = "Формат";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Кол-во записей";
            // 
            // encodingLbl
            // 
            this.encodingLbl.AutoSize = true;
            this.encodingLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encodingLbl.Location = new System.Drawing.Point(12, 67);
            this.encodingLbl.Name = "encodingLbl";
            this.encodingLbl.Size = new System.Drawing.Size(74, 17);
            this.encodingLbl.TabIndex = 8;
            this.encodingLbl.Text = "Кодировка";
            // 
            // delimeterLbl
            // 
            this.delimeterLbl.AutoSize = true;
            this.delimeterLbl.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.delimeterLbl.Location = new System.Drawing.Point(12, 40);
            this.delimeterLbl.Name = "delimeterLbl";
            this.delimeterLbl.Size = new System.Drawing.Size(82, 17);
            this.delimeterLbl.TabIndex = 9;
            this.delimeterLbl.Text = "Разделитель";
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Location = new System.Drawing.Point(50, 121);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(139, 23);
            this.saveSettingsButton.TabIndex = 10;
            this.saveSettingsButton.Text = "Сохранить настройки";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // settingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(253, 153);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.delimeterLbl);
            this.Controls.Add(this.encodingLbl);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.formatLbl);
            this.Controls.Add(this.recordsCountTxt);
            this.Controls.Add(this.delimeterBox);
            this.Controls.Add(this.encodingBox);
            this.Controls.Add(this.formatBox);
            this.Name = "settingsForm";
            this.Text = "Настройки";
            this.Load += new System.EventHandler(this.settingsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox formatBox;
        private System.Windows.Forms.ComboBox encodingBox;
        private System.Windows.Forms.ComboBox delimeterBox;
        private System.Windows.Forms.TextBox recordsCountTxt;
        private System.Windows.Forms.Label formatLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label encodingLbl;
        private System.Windows.Forms.Label delimeterLbl;
        private System.Windows.Forms.Button saveSettingsButton;
    }
}