namespace qaMagic
{
    partial class mainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LeftPanel = new System.Windows.Forms.Panel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.InfoL = new System.Windows.Forms.Label();
            this.NameL = new System.Windows.Forms.Label();
            this.RightPanel = new System.Windows.Forms.Panel();
            this.ParametresPanel = new System.Windows.Forms.Panel();
            this.ParDelBtn = new System.Windows.Forms.Button();
            this.ParNameL = new System.Windows.Forms.Label();
            this.ParNameTB = new System.Windows.Forms.TextBox();
            this.ParTypeL = new System.Windows.Forms.Label();
            this.ParCB = new System.Windows.Forms.ComboBox();
            this.StringPanel = new System.Windows.Forms.Panel();
            this.ParStringL = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SeqPanel = new System.Windows.Forms.Panel();
            this.ParSeqStep = new System.Windows.Forms.TextBox();
            this.ParSequence2L = new System.Windows.Forms.Label();
            this.ParSeqFrom = new System.Windows.Forms.TextBox();
            this.ParSequenceL = new System.Windows.Forms.Label();
            this.RangePanel = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.ParRangeTo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ParRangeFrom = new System.Windows.Forms.TextBox();
            this.ParRangeL = new System.Windows.Forms.Label();
            this.DatePanel = new System.Windows.Forms.Panel();
            this.ParDateCB = new System.Windows.Forms.ComboBox();
            this.ParDateFormatL = new System.Windows.Forms.Label();
            this.ParOKBtn = new System.Windows.Forms.Button();
            this.OptionsPanel = new System.Windows.Forms.Panel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.OptOKBtn = new System.Windows.Forms.Button();
            this.OptPathBtn = new System.Windows.Forms.Button();
            this.OptEncodeCB = new System.Windows.Forms.ComboBox();
            this.OptDivCB = new System.Windows.Forms.ComboBox();
            this.OptFormatCB = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DescriptionL = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.GenerateBtn = new System.Windows.Forms.Button();
            this.OptionsBtn = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.ParDateFrom = new System.Windows.Forms.TextBox();
            this.ParDateTo = new System.Windows.Forms.TextBox();
            this.LeftPanel.SuspendLayout();
            this.TopPanel.SuspendLayout();
            this.RightPanel.SuspendLayout();
            this.ParametresPanel.SuspendLayout();
            this.StringPanel.SuspendLayout();
            this.SeqPanel.SuspendLayout();
            this.RangePanel.SuspendLayout();
            this.DatePanel.SuspendLayout();
            this.OptionsPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // LeftPanel
            // 
            this.LeftPanel.AutoScroll = true;
            this.LeftPanel.Controls.Add(this.AddBtn);
            this.LeftPanel.Location = new System.Drawing.Point(12, 94);
            this.LeftPanel.Name = "LeftPanel";
            this.LeftPanel.Size = new System.Drawing.Size(401, 576);
            this.LeftPanel.TabIndex = 0;
            // 
            // AddBtn
            // 
            this.AddBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.AddBtn.Location = new System.Drawing.Point(20, 25);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(350, 40);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "Добавить...";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // TopPanel
            // 
            this.TopPanel.BackColor = System.Drawing.Color.LightCyan;
            this.TopPanel.Controls.Add(this.label7);
            this.TopPanel.Controls.Add(this.InfoL);
            this.TopPanel.Controls.Add(this.NameL);
            this.TopPanel.ForeColor = System.Drawing.Color.IndianRed;
            this.TopPanel.Location = new System.Drawing.Point(14, 10);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1266, 75);
            this.TopPanel.TabIndex = 1;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(178, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(1129, 25);
            this.label7.TabIndex = 3;
            this.label7.Text = "ВНИМАНИЕ РАЗРАБОТЧИКАМ!!!! ПАНЕЛИ НЕ ПЕРЕДВИГАТЬ ВО ИЗБЕЖАНИЕ ИХ НЕВЕРНОГО НАЛОЖЕ" +
    "НИЯ";
            this.label7.Visible = false;
            // 
            // InfoL
            // 
            this.InfoL.AutoSize = true;
            this.InfoL.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoL.ForeColor = System.Drawing.Color.Black;
            this.InfoL.Location = new System.Drawing.Point(743, 18);
            this.InfoL.Name = "InfoL";
            this.InfoL.Size = new System.Drawing.Size(188, 45);
            this.InfoL.TabIndex = 1;
            this.InfoL.Text = "Параметры";
            // 
            // NameL
            // 
            this.NameL.AutoSize = true;
            this.NameL.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.NameL.Location = new System.Drawing.Point(36, 17);
            this.NameL.Name = "NameL";
            this.NameL.Size = new System.Drawing.Size(127, 40);
            this.NameL.TabIndex = 0;
            this.NameL.Text = "qaMagic";
            // 
            // RightPanel
            // 
            this.RightPanel.Controls.Add(this.ParametresPanel);
            this.RightPanel.Controls.Add(this.OptionsPanel);
            this.RightPanel.Controls.Add(this.DescriptionL);
            this.RightPanel.Location = new System.Drawing.Point(443, 94);
            this.RightPanel.Name = "RightPanel";
            this.RightPanel.Size = new System.Drawing.Size(820, 484);
            this.RightPanel.TabIndex = 2;
            // 
            // ParametresPanel
            // 
            this.ParametresPanel.Controls.Add(this.StringPanel);
            this.ParametresPanel.Controls.Add(this.RangePanel);
            this.ParametresPanel.Controls.Add(this.SeqPanel);
            this.ParametresPanel.Controls.Add(this.DatePanel);
            this.ParametresPanel.Controls.Add(this.ParDelBtn);
            this.ParametresPanel.Controls.Add(this.ParNameL);
            this.ParametresPanel.Controls.Add(this.ParNameTB);
            this.ParametresPanel.Controls.Add(this.ParTypeL);
            this.ParametresPanel.Controls.Add(this.ParCB);
            this.ParametresPanel.Controls.Add(this.ParOKBtn);
            this.ParametresPanel.Location = new System.Drawing.Point(57, 38);
            this.ParametresPanel.Name = "ParametresPanel";
            this.ParametresPanel.Size = new System.Drawing.Size(711, 364);
            this.ParametresPanel.TabIndex = 0;
            this.ParametresPanel.Visible = false;
            // 
            // ParDelBtn
            // 
            this.ParDelBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParDelBtn.Location = new System.Drawing.Point(24, 321);
            this.ParDelBtn.Name = "ParDelBtn";
            this.ParDelBtn.Size = new System.Drawing.Size(123, 40);
            this.ParDelBtn.TabIndex = 5;
            this.ParDelBtn.Text = "Удалить";
            this.ParDelBtn.UseVisualStyleBackColor = true;
            this.ParDelBtn.Visible = false;
            this.ParDelBtn.Click += new System.EventHandler(this.ParDelBtn_Click);
            // 
            // ParNameL
            // 
            this.ParNameL.AutoSize = true;
            this.ParNameL.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParNameL.Location = new System.Drawing.Point(84, 93);
            this.ParNameL.Name = "ParNameL";
            this.ParNameL.Size = new System.Drawing.Size(203, 30);
            this.ParNameL.TabIndex = 32;
            this.ParNameL.Text = "Выберите имя поля";
            // 
            // ParNameTB
            // 
            this.ParNameTB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParNameTB.Location = new System.Drawing.Point(309, 93);
            this.ParNameTB.Name = "ParNameTB";
            this.ParNameTB.Size = new System.Drawing.Size(375, 35);
            this.ParNameTB.TabIndex = 31;
            this.ParNameTB.Text = "Name";
            // 
            // ParTypeL
            // 
            this.ParTypeL.AutoSize = true;
            this.ParTypeL.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParTypeL.Location = new System.Drawing.Point(84, 39);
            this.ParTypeL.Name = "ParTypeL";
            this.ParTypeL.Size = new System.Drawing.Size(198, 30);
            this.ParTypeL.TabIndex = 30;
            this.ParTypeL.Text = "Выберите тип поля";
            // 
            // ParCB
            // 
            this.ParCB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParCB.FormattingEnabled = true;
            this.ParCB.Items.AddRange(new object[] {
            "Строки",
            "Числа из диапазона",
            "Даты",
            "Числовая последовательность"});
            this.ParCB.Location = new System.Drawing.Point(309, 36);
            this.ParCB.Name = "ParCB";
            this.ParCB.Size = new System.Drawing.Size(375, 38);
            this.ParCB.TabIndex = 29;
            this.ParCB.SelectedIndexChanged += new System.EventHandler(this.ParCB_SelectedIndexChanged);
            // 
            // StringPanel
            // 
            this.StringPanel.Controls.Add(this.ParStringL);
            this.StringPanel.Controls.Add(this.button1);
            this.StringPanel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.StringPanel.Location = new System.Drawing.Point(46, 179);
            this.StringPanel.Name = "StringPanel";
            this.StringPanel.Size = new System.Drawing.Size(514, 106);
            this.StringPanel.TabIndex = 24;
            this.StringPanel.Visible = false;
            // 
            // ParStringL
            // 
            this.ParStringL.AutoSize = true;
            this.ParStringL.Location = new System.Drawing.Point(17, 38);
            this.ParStringL.Name = "ParStringL";
            this.ParStringL.Size = new System.Drawing.Size(328, 30);
            this.ParStringL.TabIndex = 4;
            this.ParStringL.Text = "Выберите файл с набором строк";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(366, 31);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(129, 45);
            this.button1.TabIndex = 3;
            this.button1.Text = "Открыть файл";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SeqPanel
            // 
            this.SeqPanel.Controls.Add(this.ParSeqStep);
            this.SeqPanel.Controls.Add(this.ParSequence2L);
            this.SeqPanel.Controls.Add(this.ParSeqFrom);
            this.SeqPanel.Controls.Add(this.ParSequenceL);
            this.SeqPanel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SeqPanel.Location = new System.Drawing.Point(71, 159);
            this.SeqPanel.Name = "SeqPanel";
            this.SeqPanel.Size = new System.Drawing.Size(546, 129);
            this.SeqPanel.TabIndex = 25;
            this.SeqPanel.Visible = false;
            // 
            // ParSeqStep
            // 
            this.ParSeqStep.Location = new System.Drawing.Point(265, 78);
            this.ParSeqStep.Name = "ParSeqStep";
            this.ParSeqStep.Size = new System.Drawing.Size(150, 35);
            this.ParSeqStep.TabIndex = 9;
            // 
            // ParSequence2L
            // 
            this.ParSequence2L.AutoSize = true;
            this.ParSequence2L.Location = new System.Drawing.Point(57, 78);
            this.ParSequence2L.Name = "ParSequence2L";
            this.ParSequence2L.Size = new System.Drawing.Size(92, 30);
            this.ParSequence2L.TabIndex = 1;
            this.ParSequence2L.Text = "с шагом";
            // 
            // ParSeqFrom
            // 
            this.ParSeqFrom.Location = new System.Drawing.Point(265, 20);
            this.ParSeqFrom.Name = "ParSeqFrom";
            this.ParSeqFrom.Size = new System.Drawing.Size(150, 35);
            this.ParSeqFrom.TabIndex = 8;
            // 
            // ParSequenceL
            // 
            this.ParSequenceL.AutoSize = true;
            this.ParSequenceL.Location = new System.Drawing.Point(8, 23);
            this.ParSequenceL.Name = "ParSequenceL";
            this.ParSequenceL.Size = new System.Drawing.Size(240, 30);
            this.ParSequenceL.TabIndex = 0;
            this.ParSequenceL.Text = "Последовательность от";
            // 
            // RangePanel
            // 
            this.RangePanel.Controls.Add(this.label3);
            this.RangePanel.Controls.Add(this.ParRangeTo);
            this.RangePanel.Controls.Add(this.label1);
            this.RangePanel.Controls.Add(this.ParRangeFrom);
            this.RangePanel.Controls.Add(this.ParRangeL);
            this.RangePanel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RangePanel.Location = new System.Drawing.Point(86, 156);
            this.RangePanel.Name = "RangePanel";
            this.RangePanel.Size = new System.Drawing.Size(583, 151);
            this.RangePanel.TabIndex = 26;
            this.RangePanel.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(156, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 30);
            this.label3.TabIndex = 7;
            this.label3.Text = "От";
            // 
            // ParRangeTo
            // 
            this.ParRangeTo.Location = new System.Drawing.Point(215, 94);
            this.ParRangeTo.Name = "ParRangeTo";
            this.ParRangeTo.Size = new System.Drawing.Size(160, 35);
            this.ParRangeTo.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(156, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 30);
            this.label1.TabIndex = 6;
            this.label1.Text = "До";
            // 
            // ParRangeFrom
            // 
            this.ParRangeFrom.Location = new System.Drawing.Point(215, 29);
            this.ParRangeFrom.Name = "ParRangeFrom";
            this.ParRangeFrom.Size = new System.Drawing.Size(160, 35);
            this.ParRangeFrom.TabIndex = 4;
            // 
            // ParRangeL
            // 
            this.ParRangeL.AutoSize = true;
            this.ParRangeL.Location = new System.Drawing.Point(18, 32);
            this.ParRangeL.Name = "ParRangeL";
            this.ParRangeL.Size = new System.Drawing.Size(107, 30);
            this.ParRangeL.TabIndex = 0;
            this.ParRangeL.Text = "Диапазон";
            // 
            // DatePanel
            // 
            this.DatePanel.Controls.Add(this.ParDateTo);
            this.DatePanel.Controls.Add(this.ParDateFrom);
            this.DatePanel.Controls.Add(this.label10);
            this.DatePanel.Controls.Add(this.label9);
            this.DatePanel.Controls.Add(this.ParDateCB);
            this.DatePanel.Controls.Add(this.ParDateFormatL);
            this.DatePanel.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DatePanel.Location = new System.Drawing.Point(56, 171);
            this.DatePanel.Name = "DatePanel";
            this.DatePanel.Size = new System.Drawing.Size(471, 136);
            this.DatePanel.TabIndex = 23;
            this.DatePanel.Visible = false;
            // 
            // ParDateCB
            // 
            this.ParDateCB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParDateCB.FormattingEnabled = true;
            this.ParDateCB.Items.AddRange(new object[] {
            "DD.MM.YYYY",
            "MM.DD.YYYY",
            "DD.MM.YY",
            "MM.DD.YY",
            "YYYY.MM.DD",
            "YYYY.DD.MM",
            "YY.MM.DD",
            "YY.DD.MM"});
            this.ParDateCB.Location = new System.Drawing.Point(221, 14);
            this.ParDateCB.Name = "ParDateCB";
            this.ParDateCB.Size = new System.Drawing.Size(184, 38);
            this.ParDateCB.TabIndex = 21;
            // 
            // ParDateFormatL
            // 
            this.ParDateFormatL.AutoSize = true;
            this.ParDateFormatL.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParDateFormatL.Location = new System.Drawing.Point(55, 14);
            this.ParDateFormatL.Name = "ParDateFormatL";
            this.ParDateFormatL.Size = new System.Drawing.Size(139, 30);
            this.ParDateFormatL.TabIndex = 20;
            this.ParDateFormatL.Text = "Формат даты";
            // 
            // ParOKBtn
            // 
            this.ParOKBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ParOKBtn.Location = new System.Drawing.Point(575, 313);
            this.ParOKBtn.Name = "ParOKBtn";
            this.ParOKBtn.Size = new System.Drawing.Size(124, 48);
            this.ParOKBtn.TabIndex = 20;
            this.ParOKBtn.Text = "ОК";
            this.ParOKBtn.UseVisualStyleBackColor = true;
            this.ParOKBtn.Click += new System.EventHandler(this.ParOKBtn_Click);
            // 
            // OptionsPanel
            // 
            this.OptionsPanel.Controls.Add(this.textBox1);
            this.OptionsPanel.Controls.Add(this.label8);
            this.OptionsPanel.Controls.Add(this.OptOKBtn);
            this.OptionsPanel.Controls.Add(this.OptPathBtn);
            this.OptionsPanel.Controls.Add(this.OptEncodeCB);
            this.OptionsPanel.Controls.Add(this.OptDivCB);
            this.OptionsPanel.Controls.Add(this.OptFormatCB);
            this.OptionsPanel.Controls.Add(this.label6);
            this.OptionsPanel.Controls.Add(this.label5);
            this.OptionsPanel.Controls.Add(this.label4);
            this.OptionsPanel.Controls.Add(this.label2);
            this.OptionsPanel.Location = new System.Drawing.Point(72, 54);
            this.OptionsPanel.Name = "OptionsPanel";
            this.OptionsPanel.Size = new System.Drawing.Size(708, 408);
            this.OptionsPanel.TabIndex = 2;
            // 
            // textBox1
            // 
            this.textBox1.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox1.Location = new System.Drawing.Point(275, 313);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(170, 35);
            this.textBox1.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(36, 305);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(229, 60);
            this.label8.TabIndex = 9;
            this.label8.Text = "Выберите количество \r\nгенерируемых строк";
            // 
            // OptOKBtn
            // 
            this.OptOKBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptOKBtn.Location = new System.Drawing.Point(588, 340);
            this.OptOKBtn.Name = "OptOKBtn";
            this.OptOKBtn.Size = new System.Drawing.Size(105, 54);
            this.OptOKBtn.TabIndex = 8;
            this.OptOKBtn.Text = "ОК";
            this.OptOKBtn.UseVisualStyleBackColor = true;
            this.OptOKBtn.Click += new System.EventHandler(this.OptOKBtn_Click);
            // 
            // OptPathBtn
            // 
            this.OptPathBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptPathBtn.Location = new System.Drawing.Point(275, 237);
            this.OptPathBtn.Name = "OptPathBtn";
            this.OptPathBtn.Size = new System.Drawing.Size(143, 47);
            this.OptPathBtn.TabIndex = 7;
            this.OptPathBtn.Text = "Выбрать";
            this.OptPathBtn.UseVisualStyleBackColor = true;
            this.OptPathBtn.Click += new System.EventHandler(this.OptPathBtn_Click);
            // 
            // OptEncodeCB
            // 
            this.OptEncodeCB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptEncodeCB.FormattingEnabled = true;
            this.OptEncodeCB.Items.AddRange(new object[] {
            "UTF-8",
            "UTF-16",
            "ANSI",
            "Unicode",
            "CP-1251"});
            this.OptEncodeCB.Location = new System.Drawing.Point(274, 163);
            this.OptEncodeCB.Name = "OptEncodeCB";
            this.OptEncodeCB.Size = new System.Drawing.Size(171, 38);
            this.OptEncodeCB.TabIndex = 6;
            // 
            // OptDivCB
            // 
            this.OptDivCB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptDivCB.FormattingEnabled = true;
            this.OptDivCB.Items.AddRange(new object[] {
            ". точка",
            ", запятая",
            "; точка с запятой",
            " пробел",
            " табуляция"});
            this.OptDivCB.Location = new System.Drawing.Point(275, 104);
            this.OptDivCB.Name = "OptDivCB";
            this.OptDivCB.Size = new System.Drawing.Size(171, 38);
            this.OptDivCB.TabIndex = 5;
            // 
            // OptFormatCB
            // 
            this.OptFormatCB.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptFormatCB.FormattingEnabled = true;
            this.OptFormatCB.Items.AddRange(new object[] {
            "CSV"});
            this.OptFormatCB.Location = new System.Drawing.Point(275, 53);
            this.OptFormatCB.Name = "OptFormatCB";
            this.OptFormatCB.Size = new System.Drawing.Size(171, 38);
            this.OptFormatCB.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(36, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(161, 60);
            this.label6.TabIndex = 3;
            this.label6.Text = "Выберите путь \r\nсохранения";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(36, 166);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(213, 30);
            this.label5.TabIndex = 2;
            this.label5.Text = "Выберите кодировку";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(36, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(232, 30);
            this.label4.TabIndex = 1;
            this.label4.Text = "Выберите разделитель";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(36, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(186, 30);
            this.label2.TabIndex = 0;
            this.label2.Text = "Выберите формат";
            // 
            // DescriptionL
            // 
            this.DescriptionL.AutoSize = true;
            this.DescriptionL.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.DescriptionL.Location = new System.Drawing.Point(58, 12);
            this.DescriptionL.Name = "DescriptionL";
            this.DescriptionL.Size = new System.Drawing.Size(109, 30);
            this.DescriptionL.TabIndex = 1;
            this.DescriptionL.Text = "Описание";
            this.DescriptionL.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightCyan;
            this.panel1.Controls.Add(this.GenerateBtn);
            this.panel1.Controls.Add(this.OptionsBtn);
            this.panel1.Location = new System.Drawing.Point(443, 597);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(837, 88);
            this.panel1.TabIndex = 3;
            // 
            // GenerateBtn
            // 
            this.GenerateBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.GenerateBtn.Location = new System.Drawing.Point(585, 19);
            this.GenerateBtn.Name = "GenerateBtn";
            this.GenerateBtn.Size = new System.Drawing.Size(180, 48);
            this.GenerateBtn.TabIndex = 1;
            this.GenerateBtn.Text = "Генерировать";
            this.GenerateBtn.UseVisualStyleBackColor = true;
            // 
            // OptionsBtn
            // 
            this.OptionsBtn.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.OptionsBtn.Location = new System.Drawing.Point(368, 21);
            this.OptionsBtn.Name = "OptionsBtn";
            this.OptionsBtn.Size = new System.Drawing.Size(131, 46);
            this.OptionsBtn.TabIndex = 0;
            this.OptionsBtn.Text = "Опции";
            this.OptionsBtn.UseVisualStyleBackColor = true;
            this.OptionsBtn.Click += new System.EventHandler(this.OptionsBtn_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Title = "Открыть";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 76);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(231, 30);
            this.label9.TabIndex = 22;
            this.label9.Text = "Диапазон годов дат от";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(341, 76);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 30);
            this.label10.TabIndex = 23;
            this.label10.Text = "до";
            // 
            // ParDateFrom
            // 
            this.ParDateFrom.Location = new System.Drawing.Point(257, 76);
            this.ParDateFrom.Name = "ParDateFrom";
            this.ParDateFrom.Size = new System.Drawing.Size(77, 35);
            this.ParDateFrom.TabIndex = 24;
            // 
            // ParDateTo
            // 
            this.ParDateTo.Location = new System.Drawing.Point(383, 76);
            this.ParDateTo.Name = "ParDateTo";
            this.ParDateTo.Size = new System.Drawing.Size(77, 35);
            this.ParDateTo.TabIndex = 25;
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PowderBlue;
            this.ClientSize = new System.Drawing.Size(1274, 682);
            this.Controls.Add(this.RightPanel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TopPanel);
            this.Controls.Add(this.LeftPanel);
            this.Name = "mainForm";
            this.Text = "qaMagic";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.LeftPanel.ResumeLayout(false);
            this.TopPanel.ResumeLayout(false);
            this.TopPanel.PerformLayout();
            this.RightPanel.ResumeLayout(false);
            this.RightPanel.PerformLayout();
            this.ParametresPanel.ResumeLayout(false);
            this.ParametresPanel.PerformLayout();
            this.StringPanel.ResumeLayout(false);
            this.StringPanel.PerformLayout();
            this.SeqPanel.ResumeLayout(false);
            this.SeqPanel.PerformLayout();
            this.RangePanel.ResumeLayout(false);
            this.RangePanel.PerformLayout();
            this.DatePanel.ResumeLayout(false);
            this.DatePanel.PerformLayout();
            this.OptionsPanel.ResumeLayout(false);
            this.OptionsPanel.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel LeftPanel;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Panel RightPanel;
        private System.Windows.Forms.Label InfoL;
        private System.Windows.Forms.Label NameL;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button GenerateBtn;
        private System.Windows.Forms.Button OptionsBtn;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Panel ParametresPanel;
        private System.Windows.Forms.Button ParOKBtn;
        private System.Windows.Forms.Panel RangePanel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ParRangeTo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ParRangeFrom;
        private System.Windows.Forms.Label ParRangeL;
        private System.Windows.Forms.Panel SeqPanel;
        private System.Windows.Forms.TextBox ParSeqStep;
        private System.Windows.Forms.Label ParSequence2L;
        private System.Windows.Forms.TextBox ParSeqFrom;
        private System.Windows.Forms.Label ParSequenceL;
        private System.Windows.Forms.Panel StringPanel;
        private System.Windows.Forms.Label ParStringL;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel DatePanel;
        private System.Windows.Forms.ComboBox ParDateCB;
        private System.Windows.Forms.Label ParDateFormatL;
        private System.Windows.Forms.Label DescriptionL;
        private System.Windows.Forms.Label ParNameL;
        private System.Windows.Forms.TextBox ParNameTB;
        private System.Windows.Forms.Label ParTypeL;
        private System.Windows.Forms.ComboBox ParCB;
        private System.Windows.Forms.Button ParDelBtn;
        private System.Windows.Forms.Panel OptionsPanel;
        private System.Windows.Forms.Button OptOKBtn;
        private System.Windows.Forms.Button OptPathBtn;
        private System.Windows.Forms.ComboBox OptEncodeCB;
        private System.Windows.Forms.ComboBox OptDivCB;
        private System.Windows.Forms.ComboBox OptFormatCB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox ParDateTo;
        private System.Windows.Forms.TextBox ParDateFrom;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
    }
}

