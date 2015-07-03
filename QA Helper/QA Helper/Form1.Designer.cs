using System.Drawing;
using System.Windows.Forms;
namespace QA_Helper
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.tooltip = new System.Windows.Forms.ToolStripStatusLabel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.settingButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fieldButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aboutText = new System.Windows.Forms.TextBox();
            this.commonAddPanel = new System.Windows.Forms.Panel();
            this.applyFieldButton = new System.Windows.Forms.Button();
            this.chooseButton = new System.Windows.Forms.Button();
            this.chooseLabel = new System.Windows.Forms.Label();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.addInfo = new System.Windows.Forms.Label();
            this.rangeLbl = new System.Windows.Forms.Label();
            this.rangeFromTxt = new System.Windows.Forms.TextBox();
            this.rangeToTxt = new System.Windows.Forms.TextBox();
            this.seqFromLbl = new System.Windows.Forms.Label();
            this.seqFromTxt = new System.Windows.Forms.TextBox();
            this.seqStepTxt = new System.Windows.Forms.TextBox();
            this.seqStepLbl = new System.Windows.Forms.Label();
            this.tableLayoutPanel = new QA_Helper.TablePanel();
            this.dateFormatCbox = new System.Windows.Forms.ComboBox();
            this.dateFormatLbl = new System.Windows.Forms.Label();
            this.datePariodLbl = new System.Windows.Forms.Label();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.statusStrip.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.commonAddPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltip});
            this.statusStrip.Location = new System.Drawing.Point(0, 447);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(662, 22);
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tooltip
            // 
            this.tooltip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tooltip.Margin = new System.Windows.Forms.Padding(190, 3, 0, 2);
            this.tooltip.Name = "tooltip";
            this.tooltip.Size = new System.Drawing.Size(244, 17);
            this.tooltip.Text = "Добавьте поля для генерирования записей";
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.generateButton);
            this.controlPanel.Controls.Add(this.addButton);
            this.controlPanel.Controls.Add(this.settingButton);
            this.controlPanel.Location = new System.Drawing.Point(16, 396);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(228, 38);
            this.controlPanel.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(54, 1);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(120, 34);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Генерировать";
            this.generateButton.UseVisualStyleBackColor = true;
            this.generateButton.Click += new System.EventHandler(this.generateButton_Click);
            // 
            // addButton
            // 
            this.addButton.BackgroundImage = global::QA_Helper.Properties.Resources._1435861250_plus_sign;
            this.addButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.addButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addButton.Location = new System.Drawing.Point(3, 1);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(34, 34);
            this.addButton.TabIndex = 1;
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // settingButton
            // 
            this.settingButton.BackgroundImage = global::QA_Helper.Properties.Resources._1435861266_gears;
            this.settingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingButton.Location = new System.Drawing.Point(189, 1);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(34, 34);
            this.settingButton.TabIndex = 0;
            this.settingButton.UseVisualStyleBackColor = true;
            this.settingButton.Click += new System.EventHandler(this.settingButton_Click);
            // 
            // fieldButton
            // 
            this.fieldButton.Location = new System.Drawing.Point(0, 0);
            this.fieldButton.Name = "fieldButton";
            this.fieldButton.Size = new System.Drawing.Size(75, 23);
            this.fieldButton.TabIndex = 0;
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(0, 0);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 0;
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(0, 0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 0;
            // 
            // welcomePanel
            // 
            this.welcomePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.welcomePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.welcomePanel.Controls.Add(this.pictureBox1);
            this.welcomePanel.Controls.Add(this.aboutText);
            this.welcomePanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomePanel.Location = new System.Drawing.Point(259, 12);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(391, 422);
            this.welcomePanel.TabIndex = 2;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QA_Helper.Properties.Resources._3;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(391, 224);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // aboutText
            // 
            this.aboutText.BackColor = System.Drawing.SystemColors.Control;
            this.aboutText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutText.Location = new System.Drawing.Point(-1, 230);
            this.aboutText.Multiline = true;
            this.aboutText.Name = "aboutText";
            this.aboutText.ReadOnly = true;
            this.aboutText.Size = new System.Drawing.Size(387, 170);
            this.aboutText.TabIndex = 0;
            this.aboutText.Text = "    Приложение QA Helper позволяет генерировать входные данные в виде строки, чис" +
    "ел из диапазона, даты, числовой последовательности для тестирования и отладки др" +
    "угих приложений.";
            this.aboutText.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // commonAddPanel
            // 
            this.commonAddPanel.Controls.Add(this.datePickerTo);
            this.commonAddPanel.Controls.Add(this.datePickerFrom);
            this.commonAddPanel.Controls.Add(this.datePariodLbl);
            this.commonAddPanel.Controls.Add(this.dateFormatLbl);
            this.commonAddPanel.Controls.Add(this.dateFormatCbox);
            this.commonAddPanel.Controls.Add(this.seqStepLbl);
            this.commonAddPanel.Controls.Add(this.seqStepTxt);
            this.commonAddPanel.Controls.Add(this.seqFromTxt);
            this.commonAddPanel.Controls.Add(this.seqFromLbl);
            this.commonAddPanel.Controls.Add(this.rangeToTxt);
            this.commonAddPanel.Controls.Add(this.rangeFromTxt);
            this.commonAddPanel.Controls.Add(this.rangeLbl);
            this.commonAddPanel.Controls.Add(this.applyFieldButton);
            this.commonAddPanel.Controls.Add(this.chooseButton);
            this.commonAddPanel.Controls.Add(this.chooseLabel);
            this.commonAddPanel.Controls.Add(this.nameTxt);
            this.commonAddPanel.Controls.Add(this.nameLbl);
            this.commonAddPanel.Controls.Add(this.typeLbl);
            this.commonAddPanel.Controls.Add(this.typeBox);
            this.commonAddPanel.Controls.Add(this.addInfo);
            this.commonAddPanel.Location = new System.Drawing.Point(263, 236);
            this.commonAddPanel.Name = "commonAddPanel";
            this.commonAddPanel.Size = new System.Drawing.Size(383, 194);
            this.commonAddPanel.TabIndex = 2;
            this.commonAddPanel.Visible = false;
            // 
            // applyFieldButton
            // 
            this.applyFieldButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyFieldButton.Location = new System.Drawing.Point(133, 162);
            this.applyFieldButton.Name = "applyFieldButton";
            this.applyFieldButton.Size = new System.Drawing.Size(109, 23);
            this.applyFieldButton.TabIndex = 9;
            this.applyFieldButton.Text = "Добавить поле";
            this.applyFieldButton.UseVisualStyleBackColor = true;
            this.applyFieldButton.Click += new System.EventHandler(this.applyFieldButton_Click);
            // 
            // chooseButton
            // 
            this.chooseButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseButton.Location = new System.Drawing.Point(210, 119);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(98, 23);
            this.chooseButton.TabIndex = 6;
            this.chooseButton.Text = "Открыть файл";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // chooseLabel
            // 
            this.chooseLabel.AutoSize = true;
            this.chooseLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseLabel.Location = new System.Drawing.Point(87, 124);
            this.chooseLabel.Name = "chooseLabel";
            this.chooseLabel.Size = new System.Drawing.Size(117, 13);
            this.chooseLabel.TabIndex = 5;
            this.chooseLabel.Text = "Выбрать файл строк";
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(110, 68);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(175, 22);
            this.nameTxt.TabIndex = 7;
            this.nameTxt.Text = "Безымянное";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(33, 71);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(58, 13);
            this.nameLbl.TabIndex = 3;
            this.nameLbl.Text = "Имя поля";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLbl.Location = new System.Drawing.Point(33, 44);
            this.typeLbl.Name = "typeLbl";
            this.typeLbl.Size = new System.Drawing.Size(55, 13);
            this.typeLbl.TabIndex = 2;
            this.typeLbl.Text = "Тип поля";
            // 
            // typeBox
            // 
            this.typeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.typeBox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeBox.FormattingEnabled = true;
            this.typeBox.Items.AddRange(new object[] {
            "Случайные строки",
            "Числа из диапазона",
            "Дата",
            "Числовая последовательность",
            "Последовательные строки"});
            this.typeBox.Location = new System.Drawing.Point(110, 41);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(175, 21);
            this.typeBox.TabIndex = 10;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // addInfo
            // 
            this.addInfo.AutoSize = true;
            this.addInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addInfo.Location = new System.Drawing.Point(129, 7);
            this.addInfo.Name = "addInfo";
            this.addInfo.Size = new System.Drawing.Size(135, 21);
            this.addInfo.TabIndex = 0;
            this.addInfo.Text = "Добавление поля";
            this.addInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // rangeLbl
            // 
            this.rangeLbl.AutoSize = true;
            this.rangeLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeLbl.Location = new System.Drawing.Point(78, 124);
            this.rangeLbl.Name = "rangeLbl";
            this.rangeLbl.Size = new System.Drawing.Size(60, 13);
            this.rangeLbl.TabIndex = 11;
            this.rangeLbl.Text = "Диапазон";
            this.rangeLbl.Visible = false;
            // 
            // rangeFromTxt
            // 
            this.rangeFromTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rangeFromTxt.Location = new System.Drawing.Point(153, 120);
            this.rangeFromTxt.Name = "rangeFromTxt";
            this.rangeFromTxt.Size = new System.Drawing.Size(37, 22);
            this.rangeFromTxt.TabIndex = 12;
            this.rangeFromTxt.Text = "1";
            this.rangeFromTxt.Visible = false;
            // 
            // rangeToTxt
            // 
            this.rangeToTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rangeToTxt.Location = new System.Drawing.Point(205, 120);
            this.rangeToTxt.Name = "rangeToTxt";
            this.rangeToTxt.Size = new System.Drawing.Size(37, 22);
            this.rangeToTxt.TabIndex = 13;
            this.rangeToTxt.Text = "10";
            this.rangeToTxt.Visible = false;
            // 
            // seqFromLbl
            // 
            this.seqFromLbl.AutoSize = true;
            this.seqFromLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seqFromLbl.Location = new System.Drawing.Point(115, 124);
            this.seqFromLbl.Name = "seqFromLbl";
            this.seqFromLbl.Size = new System.Drawing.Size(21, 13);
            this.seqFromLbl.TabIndex = 14;
            this.seqFromLbl.Text = "От";
            this.seqFromLbl.Visible = false;
            // 
            // seqFromTxt
            // 
            this.seqFromTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqFromTxt.Location = new System.Drawing.Point(142, 120);
            this.seqFromTxt.Name = "seqFromTxt";
            this.seqFromTxt.Size = new System.Drawing.Size(37, 22);
            this.seqFromTxt.TabIndex = 15;
            this.seqFromTxt.Text = "1";
            this.seqFromTxt.Visible = false;
            // 
            // seqStepTxt
            // 
            this.seqStepTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqStepTxt.Location = new System.Drawing.Point(218, 120);
            this.seqStepTxt.Name = "seqStepTxt";
            this.seqStepTxt.Size = new System.Drawing.Size(37, 22);
            this.seqStepTxt.TabIndex = 16;
            this.seqStepTxt.Text = "1";
            this.seqStepTxt.Visible = false;
            // 
            // seqStepLbl
            // 
            this.seqStepLbl.AutoSize = true;
            this.seqStepLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqStepLbl.Location = new System.Drawing.Point(185, 124);
            this.seqStepLbl.Name = "seqStepLbl";
            this.seqStepLbl.Size = new System.Drawing.Size(29, 13);
            this.seqStepLbl.TabIndex = 17;
            this.seqStepLbl.Text = "Шаг";
            this.seqStepLbl.Visible = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.BackColor = System.Drawing.Color.White;
            this.tableLayoutPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tableLayoutPanel.ColumnCount = 3;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.tableLayoutPanel.Location = new System.Drawing.Point(16, 12);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel.Size = new System.Drawing.Size(228, 383);
            this.tableLayoutPanel.TabIndex = 3;
            this.tableLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel_Paint);
            // 
            // dateFormatCbox
            // 
            this.dateFormatCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateFormatCbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFormatCbox.FormattingEnabled = true;
            this.dateFormatCbox.Items.AddRange(new object[] {
            "MM.DD.YYYY",
            "DD.MM.YYYY"});
            this.dateFormatCbox.Location = new System.Drawing.Point(110, 101);
            this.dateFormatCbox.Name = "dateFormatCbox";
            this.dateFormatCbox.Size = new System.Drawing.Size(175, 21);
            this.dateFormatCbox.TabIndex = 18;
            this.dateFormatCbox.Visible = false;
            // 
            // dateFormatLbl
            // 
            this.dateFormatLbl.AutoSize = true;
            this.dateFormatLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFormatLbl.Location = new System.Drawing.Point(33, 104);
            this.dateFormatLbl.Name = "dateFormatLbl";
            this.dateFormatLbl.Size = new System.Drawing.Size(75, 13);
            this.dateFormatLbl.TabIndex = 19;
            this.dateFormatLbl.Text = "Формат даты";
            this.dateFormatLbl.Visible = false;
            // 
            // datePariodLbl
            // 
            this.datePariodLbl.AutoSize = true;
            this.datePariodLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePariodLbl.Location = new System.Drawing.Point(33, 142);
            this.datePariodLbl.Name = "datePariodLbl";
            this.datePariodLbl.Size = new System.Drawing.Size(48, 13);
            this.datePariodLbl.TabIndex = 20;
            this.datePariodLbl.Text = "Период";
            this.datePariodLbl.Visible = false;
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerFrom.Location = new System.Drawing.Point(110, 136);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(80, 20);
            this.datePickerFrom.TabIndex = 21;
            this.datePickerFrom.Visible = false;
            // 
            // datePickerTo
            // 
            this.datePickerTo.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerTo.Location = new System.Drawing.Point(205, 135);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(80, 20);
            this.datePickerTo.TabIndex = 22;
            this.datePickerTo.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 469);
            this.Controls.Add(this.commonAddPanel);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.welcomePanel);
            this.Controls.Add(this.statusStrip);
            this.Name = "Form1";
            this.Text = "QA Helper";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.commonAddPanel.ResumeLayout(false);
            this.commonAddPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel tooltip;
        private System.Windows.Forms.Panel welcomePanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.Button settingButton;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.Button generateButton;
        private System.Windows.Forms.TextBox aboutText;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button fieldButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button deleteButton;
        public TablePanel tableLayoutPanel;
        private PictureBox pictureBox1;
        private Panel commonAddPanel;
        private Button chooseButton;
        private Label chooseLabel;
        private TextBox nameTxt;
        private Label nameLbl;
        private Label typeLbl;
        private ComboBox typeBox;
        private Label addInfo;
        private Button applyFieldButton;
        private TextBox rangeToTxt;
        private TextBox rangeFromTxt;
        private Label rangeLbl;
        private Label seqStepLbl;
        private TextBox seqStepTxt;
        private TextBox seqFromTxt;
        private Label seqFromLbl;
        private DateTimePicker datePickerTo;
        private DateTimePicker datePickerFrom;
        private Label datePariodLbl;
        private Label dateFormatLbl;
        private ComboBox dateFormatCbox;
    }
}

