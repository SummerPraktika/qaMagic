﻿using System.Drawing;
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
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.infoButton = new System.Windows.Forms.ToolStripDropDownButton();
            this.developers = new System.Windows.Forms.ToolStripMenuItem();
            this.help = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.generateButton = new System.Windows.Forms.Button();
            this.addButton = new System.Windows.Forms.Button();
            this.settingButton = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.fieldButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.welcomePanel = new System.Windows.Forms.Panel();
            this.commonAddPanel = new System.Windows.Forms.Panel();
            this.cancel = new System.Windows.Forms.Button();
            this.standartListLbl = new System.Windows.Forms.Label();
            this.standartList = new System.Windows.Forms.ComboBox();
            this.datePickerFrom = new System.Windows.Forms.DateTimePicker();
            this.datePariodLbl = new System.Windows.Forms.Label();
            this.dateFormatLbl = new System.Windows.Forms.Label();
            this.chooseLabel = new System.Windows.Forms.Label();
            this.dateFormatCbox = new System.Windows.Forms.ComboBox();
            this.seqFromLbl = new System.Windows.Forms.Label();
            this.rangeFromTxt = new System.Windows.Forms.TextBox();
            this.rangeLbl = new System.Windows.Forms.Label();
            this.applyFieldButton = new System.Windows.Forms.Button();
            this.nameTxt = new System.Windows.Forms.TextBox();
            this.nameLbl = new System.Windows.Forms.Label();
            this.typeLbl = new System.Windows.Forms.Label();
            this.typeBox = new System.Windows.Forms.ComboBox();
            this.addInfo = new System.Windows.Forms.Label();
            this.seqFromTxt = new System.Windows.Forms.TextBox();
            this.datePickerTo = new System.Windows.Forms.DateTimePicker();
            this.seqStepLbl = new System.Windows.Forms.Label();
            this.rangeToTxt = new System.Windows.Forms.TextBox();
            this.seqStepTxt = new System.Windows.Forms.TextBox();
            this.chooseButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.aboutText = new System.Windows.Forms.TextBox();
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.fd = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.statusStrip.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.welcomePanel.SuspendLayout();
            this.commonAddPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tooltip,
            this.progressBar,
            this.infoButton});
            this.statusStrip.Location = new System.Drawing.Point(0, 447);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(662, 22);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // tooltip
            // 
            this.tooltip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tooltip.Margin = new System.Windows.Forms.Padding(3, 3, 0, 2);
            this.tooltip.Name = "tooltip";
            this.tooltip.Size = new System.Drawing.Size(482, 17);
            this.tooltip.Spring = true;
            this.tooltip.Text = "Добавьте поля для генерирования записей";
            // 
            // progressBar
            // 
            this.progressBar.MarqueeAnimationSpeed = 40;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(100, 16);
            this.progressBar.Step = 1;
            this.progressBar.Visible = false;
            // 
            // infoButton
            // 
            this.infoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.infoButton.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.developers,
            this.help});
            this.infoButton.Image = global::QA_Helper.Properties.Resources._1436409850_info;
            this.infoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.infoButton.Name = "infoButton";
            this.infoButton.Size = new System.Drawing.Size(29, 20);
            // 
            // developers
            // 
            this.developers.Name = "developers";
            this.developers.Size = new System.Drawing.Size(149, 22);
            this.developers.Text = "О программе";
            this.developers.Click += new System.EventHandler(this.developers_Click);
            // 
            // help
            // 
            this.help.Name = "help";
            this.help.Size = new System.Drawing.Size(149, 22);
            this.help.Text = "Справка";
            this.help.Click += new System.EventHandler(this.help_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.controlPanel.Controls.Add(this.generateButton);
            this.controlPanel.Controls.Add(this.addButton);
            this.controlPanel.Controls.Add(this.settingButton);
            this.controlPanel.Location = new System.Drawing.Point(8, 396);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(230, 38);
            this.controlPanel.TabIndex = 0;
            // 
            // generateButton
            // 
            this.generateButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.generateButton.Location = new System.Drawing.Point(58, 1);
            this.generateButton.Name = "generateButton";
            this.generateButton.Size = new System.Drawing.Size(113, 34);
            this.generateButton.TabIndex = 2;
            this.generateButton.Text = "Генерировать";
            this.toolTip1.SetToolTip(this.generateButton, "Сгенерировать входные данные");
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
            this.toolTip1.SetToolTip(this.addButton, "Добавить поле");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // settingButton
            // 
            this.settingButton.BackgroundImage = global::QA_Helper.Properties.Resources._1435861266_gears;
            this.settingButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.settingButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.settingButton.Location = new System.Drawing.Point(191, 1);
            this.settingButton.Name = "settingButton";
            this.settingButton.Size = new System.Drawing.Size(34, 34);
            this.settingButton.TabIndex = 0;
            this.toolTip1.SetToolTip(this.settingButton, "Настройки");
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
            this.welcomePanel.Controls.Add(this.commonAddPanel);
            this.welcomePanel.Controls.Add(this.pictureBox1);
            this.welcomePanel.Controls.Add(this.aboutText);
            this.welcomePanel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomePanel.Location = new System.Drawing.Point(259, 12);
            this.welcomePanel.Name = "welcomePanel";
            this.welcomePanel.Size = new System.Drawing.Size(391, 422);
            this.welcomePanel.TabIndex = 2;
            // 
            // commonAddPanel
            // 
            this.commonAddPanel.Controls.Add(this.cancel);
            this.commonAddPanel.Controls.Add(this.standartListLbl);
            this.commonAddPanel.Controls.Add(this.standartList);
            this.commonAddPanel.Controls.Add(this.datePickerFrom);
            this.commonAddPanel.Controls.Add(this.datePariodLbl);
            this.commonAddPanel.Controls.Add(this.dateFormatLbl);
            this.commonAddPanel.Controls.Add(this.chooseLabel);
            this.commonAddPanel.Controls.Add(this.dateFormatCbox);
            this.commonAddPanel.Controls.Add(this.seqFromLbl);
            this.commonAddPanel.Controls.Add(this.rangeFromTxt);
            this.commonAddPanel.Controls.Add(this.rangeLbl);
            this.commonAddPanel.Controls.Add(this.applyFieldButton);
            this.commonAddPanel.Controls.Add(this.nameTxt);
            this.commonAddPanel.Controls.Add(this.nameLbl);
            this.commonAddPanel.Controls.Add(this.typeLbl);
            this.commonAddPanel.Controls.Add(this.typeBox);
            this.commonAddPanel.Controls.Add(this.addInfo);
            this.commonAddPanel.Controls.Add(this.seqFromTxt);
            this.commonAddPanel.Controls.Add(this.datePickerTo);
            this.commonAddPanel.Controls.Add(this.seqStepLbl);
            this.commonAddPanel.Controls.Add(this.rangeToTxt);
            this.commonAddPanel.Controls.Add(this.seqStepTxt);
            this.commonAddPanel.Controls.Add(this.chooseButton);
            this.commonAddPanel.Location = new System.Drawing.Point(3, 188);
            this.commonAddPanel.Name = "commonAddPanel";
            this.commonAddPanel.Size = new System.Drawing.Size(383, 229);
            this.commonAddPanel.TabIndex = 2;
            this.commonAddPanel.Visible = false;
            // 
            // cancel
            // 
            this.cancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cancel.Location = new System.Drawing.Point(242, 194);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(109, 23);
            this.cancel.TabIndex = 27;
            this.cancel.Text = "Отмена";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // standartListLbl
            // 
            this.standartListLbl.AutoSize = true;
            this.standartListLbl.Location = new System.Drawing.Point(29, 115);
            this.standartListLbl.Name = "standartListLbl";
            this.standartListLbl.Size = new System.Drawing.Size(77, 13);
            this.standartListLbl.TabIndex = 26;
            this.standartListLbl.Text = "Стандартные";
            // 
            // standartList
            // 
            this.standartList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.standartList.FormattingEnabled = true;
            this.standartList.Items.AddRange(new object[] {
            "Не выбрано",
            "Фамилии",
            "Имена",
            "Отчества",
            "Города",
            "Телефоны",
            "E-mail"});
            this.standartList.Location = new System.Drawing.Point(122, 117);
            this.standartList.Name = "standartList";
            this.standartList.Size = new System.Drawing.Size(181, 21);
            this.standartList.TabIndex = 25;
            // 
            // datePickerFrom
            // 
            this.datePickerFrom.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerFrom.Location = new System.Drawing.Point(82, 147);
            this.datePickerFrom.Name = "datePickerFrom";
            this.datePickerFrom.Size = new System.Drawing.Size(133, 22);
            this.datePickerFrom.TabIndex = 21;
            this.datePickerFrom.Visible = false;
            // 
            // datePariodLbl
            // 
            this.datePariodLbl.AutoSize = true;
            this.datePariodLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePariodLbl.Location = new System.Drawing.Point(29, 150);
            this.datePariodLbl.Name = "datePariodLbl";
            this.datePariodLbl.Size = new System.Drawing.Size(48, 13);
            this.datePariodLbl.TabIndex = 20;
            this.datePariodLbl.Text = "Период";
            this.datePariodLbl.Visible = false;
            // 
            // dateFormatLbl
            // 
            this.dateFormatLbl.AutoSize = true;
            this.dateFormatLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFormatLbl.Location = new System.Drawing.Point(29, 115);
            this.dateFormatLbl.Name = "dateFormatLbl";
            this.dateFormatLbl.Size = new System.Drawing.Size(75, 13);
            this.dateFormatLbl.TabIndex = 19;
            this.dateFormatLbl.Text = "Формат даты";
            this.dateFormatLbl.Visible = false;
            // 
            // chooseLabel
            // 
            this.chooseLabel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.chooseLabel.Location = new System.Drawing.Point(10, 170);
            this.chooseLabel.Name = "chooseLabel";
            this.chooseLabel.Size = new System.Drawing.Size(377, 21);
            this.chooseLabel.TabIndex = 5;
            this.chooseLabel.Text = "Файл не выбран";
            this.chooseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dateFormatCbox
            // 
            this.dateFormatCbox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dateFormatCbox.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateFormatCbox.FormattingEnabled = true;
            this.dateFormatCbox.Items.AddRange(new object[] {
            "MM.DD.YYYY",
            "DD.MM.YYYY",
            "MM.DD.YY",
            "DD.MM.YY",
            "YYYY.DD.MM",
            "YYYY.MM.DD",
            "YY.DD.MM",
            "YY.MM.DD"});
            this.dateFormatCbox.Location = new System.Drawing.Point(122, 117);
            this.dateFormatCbox.Name = "dateFormatCbox";
            this.dateFormatCbox.Size = new System.Drawing.Size(183, 21);
            this.dateFormatCbox.TabIndex = 23;
            this.dateFormatCbox.Visible = false;
            // 
            // seqFromLbl
            // 
            this.seqFromLbl.AutoSize = true;
            this.seqFromLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.seqFromLbl.Location = new System.Drawing.Point(122, 115);
            this.seqFromLbl.Name = "seqFromLbl";
            this.seqFromLbl.Size = new System.Drawing.Size(47, 13);
            this.seqFromLbl.TabIndex = 14;
            this.seqFromLbl.Text = "Начало";
            this.seqFromLbl.Visible = false;
            // 
            // rangeFromTxt
            // 
            this.rangeFromTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rangeFromTxt.Location = new System.Drawing.Point(133, 140);
            this.rangeFromTxt.MaxLength = 18;
            this.rangeFromTxt.Name = "rangeFromTxt";
            this.rangeFromTxt.Size = new System.Drawing.Size(60, 22);
            this.rangeFromTxt.TabIndex = 12;
            this.rangeFromTxt.Text = "1";
            this.rangeFromTxt.Visible = false;
            this.rangeFromTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValidate);
            // 
            // rangeLbl
            // 
            this.rangeLbl.AutoSize = true;
            this.rangeLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rangeLbl.Location = new System.Drawing.Point(58, 144);
            this.rangeLbl.Name = "rangeLbl";
            this.rangeLbl.Size = new System.Drawing.Size(60, 13);
            this.rangeLbl.TabIndex = 11;
            this.rangeLbl.Text = "Диапазон";
            this.rangeLbl.Visible = false;
            // 
            // applyFieldButton
            // 
            this.applyFieldButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.applyFieldButton.Location = new System.Drawing.Point(106, 194);
            this.applyFieldButton.Name = "applyFieldButton";
            this.applyFieldButton.Size = new System.Drawing.Size(109, 23);
            this.applyFieldButton.TabIndex = 9;
            this.applyFieldButton.Text = "Добавить поле";
            this.applyFieldButton.UseVisualStyleBackColor = true;
            this.applyFieldButton.Click += new System.EventHandler(this.applyFieldButton_Click);
            // 
            // nameTxt
            // 
            this.nameTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameTxt.Location = new System.Drawing.Point(122, 68);
            this.nameTxt.Name = "nameTxt";
            this.nameTxt.Size = new System.Drawing.Size(183, 22);
            this.nameTxt.TabIndex = 7;
            this.nameTxt.Text = "Безымянное";
            // 
            // nameLbl
            // 
            this.nameLbl.AutoSize = true;
            this.nameLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.nameLbl.Location = new System.Drawing.Point(29, 71);
            this.nameLbl.Name = "nameLbl";
            this.nameLbl.Size = new System.Drawing.Size(58, 13);
            this.nameLbl.TabIndex = 3;
            this.nameLbl.Text = "Имя поля";
            // 
            // typeLbl
            // 
            this.typeLbl.AutoSize = true;
            this.typeLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.typeLbl.Location = new System.Drawing.Point(29, 44);
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
            this.typeBox.Location = new System.Drawing.Point(122, 41);
            this.typeBox.Name = "typeBox";
            this.typeBox.Size = new System.Drawing.Size(183, 21);
            this.typeBox.TabIndex = 24;
            this.typeBox.SelectedIndexChanged += new System.EventHandler(this.typeBox_SelectedIndexChanged);
            // 
            // addInfo
            // 
            this.addInfo.AutoSize = true;
            this.addInfo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.addInfo.Location = new System.Drawing.Point(153, 0);
            this.addInfo.Name = "addInfo";
            this.addInfo.Size = new System.Drawing.Size(135, 21);
            this.addInfo.TabIndex = 0;
            this.addInfo.Text = "Добавление поля";
            this.addInfo.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // seqFromTxt
            // 
            this.seqFromTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqFromTxt.Location = new System.Drawing.Point(245, 112);
            this.seqFromTxt.MaxLength = 18;
            this.seqFromTxt.Name = "seqFromTxt";
            this.seqFromTxt.Size = new System.Drawing.Size(60, 22);
            this.seqFromTxt.TabIndex = 15;
            this.seqFromTxt.Text = "1";
            this.seqFromTxt.Visible = false;
            this.seqFromTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValidate);
            // 
            // datePickerTo
            // 
            this.datePickerTo.CalendarFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePickerTo.Location = new System.Drawing.Point(242, 147);
            this.datePickerTo.Name = "datePickerTo";
            this.datePickerTo.Size = new System.Drawing.Size(123, 22);
            this.datePickerTo.TabIndex = 22;
            this.datePickerTo.Visible = false;
            // 
            // seqStepLbl
            // 
            this.seqStepLbl.AutoSize = true;
            this.seqStepLbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqStepLbl.Location = new System.Drawing.Point(122, 147);
            this.seqStepLbl.Name = "seqStepLbl";
            this.seqStepLbl.Size = new System.Drawing.Size(29, 13);
            this.seqStepLbl.TabIndex = 17;
            this.seqStepLbl.Text = "Шаг";
            this.seqStepLbl.Visible = false;
            // 
            // rangeToTxt
            // 
            this.rangeToTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.rangeToTxt.Location = new System.Drawing.Point(242, 140);
            this.rangeToTxt.MaxLength = 18;
            this.rangeToTxt.Name = "rangeToTxt";
            this.rangeToTxt.Size = new System.Drawing.Size(60, 22);
            this.rangeToTxt.TabIndex = 13;
            this.rangeToTxt.Text = "10";
            this.rangeToTxt.Visible = false;
            this.rangeToTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValidate);
            // 
            // seqStepTxt
            // 
            this.seqStepTxt.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.seqStepTxt.Location = new System.Drawing.Point(245, 142);
            this.seqStepTxt.MaxLength = 5;
            this.seqStepTxt.Name = "seqStepTxt";
            this.seqStepTxt.Size = new System.Drawing.Size(60, 22);
            this.seqStepTxt.TabIndex = 16;
            this.seqStepTxt.Text = "1";
            this.seqStepTxt.Visible = false;
            this.seqStepTxt.KeyUp += new System.Windows.Forms.KeyEventHandler(this.numValidate);
            // 
            // chooseButton
            // 
            this.chooseButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chooseButton.Location = new System.Drawing.Point(144, 142);
            this.chooseButton.Name = "chooseButton";
            this.chooseButton.Size = new System.Drawing.Size(115, 23);
            this.chooseButton.TabIndex = 6;
            this.chooseButton.Text = "Открыть файл";
            this.chooseButton.UseVisualStyleBackColor = true;
            this.chooseButton.Click += new System.EventHandler(this.chooseButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::QA_Helper.Properties.Resources._150x150;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(42, -1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(312, 183);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // aboutText
            // 
            this.aboutText.BackColor = System.Drawing.SystemColors.Control;
            this.aboutText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.aboutText.Font = new System.Drawing.Font("Segoe UI Semibold", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.aboutText.Location = new System.Drawing.Point(-1, 201);
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
            // LeftPanel
            // 
            this.LeftPanel.AutoScroll = true;
            this.LeftPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LeftPanel.Location = new System.Drawing.Point(8, 12);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(230, 314);
            this.LeftPanel.TabIndex = 25;
            // 
            // fd
            // 
            this.fd.Filter = "TXT files|*.txt";
            this.fd.Title = "Выбрать файл";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 334);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(230, 25);
            this.button1.TabIndex = 26;
            this.button1.Text = "Сохранить шаблон";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(230, 25);
            this.button2.TabIndex = 27;
            this.button2.Text = "Открыть шаблон";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(662, 469);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.LeftPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.welcomePanel);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "QA Helper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.welcomePanel.ResumeLayout(false);
            this.welcomePanel.PerformLayout();
            this.commonAddPanel.ResumeLayout(false);
            this.commonAddPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;  // Turn on WS_EX_COMPOSITED
                return cp;
            }
        } 

        #endregion

        public System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel tooltip;
        public System.Windows.Forms.Panel welcomePanel;
        public System.Windows.Forms.Panel controlPanel;
        public System.Windows.Forms.Button settingButton;
        public System.Windows.Forms.Button addButton;
        public System.Windows.Forms.Button generateButton;
        public System.Windows.Forms.TextBox aboutText;
        public System.Windows.Forms.ToolTip toolTip1;
        public System.Windows.Forms.Button fieldButton;
        public System.Windows.Forms.Button editButton;
        public System.Windows.Forms.Button deleteButton;
        public PictureBox pictureBox1;
        public Panel commonAddPanel;
        public Button chooseButton;
        public Label chooseLabel;
        public TextBox nameTxt;
        public Label nameLbl;
        public Label typeLbl;
        public ComboBox typeBox;
        public Label addInfo;
        public Button applyFieldButton;
        public TextBox rangeToTxt;
        public TextBox rangeFromTxt;
        public Label rangeLbl;
        public Label seqStepLbl;
        public TextBox seqStepTxt;
        public TextBox seqFromTxt;
        public Label seqFromLbl;
        public DateTimePicker datePickerTo;
        public DateTimePicker datePickerFrom;
        public Label datePariodLbl;
        public Label dateFormatLbl;
        public ComboBox dateFormatCbox;
        private Panel LeftPanel;
        private OpenFileDialog fd;
        private ComboBox standartList;
        private Label standartListLbl;
        private Button button1;
        private Button button2;
        public Button cancel;
        private ToolStripDropDownButton infoButton;
        private ToolStripMenuItem developers;
        private ToolStripMenuItem help;
        private ToolStripProgressBar progressBar;
    }
}

