using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;

namespace QA_Helper
{
    public partial class Form1 : Form
    {
        public static List<FieldNode> nodes = new List<FieldNode>();
        public static string mode = "add";
        FieldNode node;
        string pathToFile = "";
        public static int editable = 0;

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(addButton, "Добавить поле");
        }

        private void tableLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void addButton_Click(object sender, EventArgs e)
        {
            mode = "add";
            this.addInfo.Text = "Добавление поля";
            this.applyFieldButton.Text = "Добавить поле";
            setDefaultParameters();

            this.commonAddPanel.Show();
           
        }

 void generate()
        {
            SaveFileDialog sd = new SaveFileDialog();
            DialogResult result = sd.ShowDialog();
            string pathSaveFile;
            if (result.ToString() == "OK")
            {
                pathSaveFile = sd.FileName;
            }
            else
            {
                pathSaveFile = "";
                errorMessage("Генерация отменена");
                return;
            }

            string st = "";
            string divider = settingsForm.getSetting("delimeter");
            string encoding = settingsForm.getSetting("encoding");
            string countLines = settingsForm.getSetting("recordsCount");

            switch (divider)
            {
                case "Точка":
                    divider = ".";
                    break;
                case "Запятая":
                    divider = ",";
                    break;
                case "Пробел":
                    divider = " ";
                    break;
                case "Точка с запятой":
                    divider = ";";
                    break;
                case "Табуляция":
                    divider = "\t";
                    break;
                default:
                    divider = ";";
                    break;
            }
            if (encoding == "")
                encoding = "UTF-8";
            if (countLines == "")
                countLines = "10";
            if (nodes[0] == null)
            {
                errorMessage("Создайте хотя бы одно поле");
                return;
            }
            try
            {
                using (FileStream fs = new FileStream(pathSaveFile, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.GetEncoding(encoding)))
                    {
                        for (int i = 0; i < int.Parse(countLines); i++)
                        {

                            foreach (FieldNode a in nodes)
                            {
                                if (a == null)
                                    break;
                                if (a.type == 0)
                                {
                                    st += a.getRndString().ToString() + divider;//  вызов функции печати для поля со строками
                                }
                                if (a.type == 1)
                                {
                                    st += a.getRndNumber().ToString() + divider; // вызов функции печати для поля c рандомным числом из промежутка
                                }
                                if (a.type == 2)
                                {
                                    st += a.getRndDate() + divider; // вызов функции печати для поля дат
                                }
                                if (a.type == 3)
                                {
                                    st += a.getSequenceNumber().ToString() + divider; // вызов функции печати для поля c Шагом
                                }
                                if (a.type == 4)
                                {
                                    st += a.getSequentialString(i).ToString() + divider;//  вызов функции печати для поля со строками
                                }
                            }
                            st += "\n";
                            writer.Write(st);
                            st = "";
                        }

                    }
                }
            }
            catch (FileLoadException) { }
            simpleMessage("Генерация выполнена");
        }

        void errorMessage(string text)
        {
            MessageDialog form = new MessageDialog();
            form.errorTxt.Text = text;
            form.Text = "Ошибка";
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            form.Show(this);
        }

        void simpleMessage(string text)
        {
            MessageDialog form = new MessageDialog();
            form.errorTxt.Text = text;
            form.Text = "Успех";
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            form.Show(this);
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //nodes.Add(new FieldNode(this, "sdfsdf", 3, 1, 2));
            generate();
        }

        private void settingButton_Click(object sender, EventArgs e)
        {
            settingsForm form = new settingsForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            form.Show(this);
        }

        private void applyFieldButton_Click(object sender, EventArgs e)
        {
            string fieldName = this.nameTxt.Text.ToString();
            fieldName = fieldName.ToString().Trim();
            if (fieldName == "")
            {
                fieldName = "Безымянное";
            }
            if (fieldName.Contains(" "))
            {
                fieldName = fieldName.Replace(" ", "_");
            }

            if (mode == "add")
            {
                if (this.typeBox.SelectedIndex == 0)
                {
                    if (pathToFile != "")
                    {
                        node = new FieldNode(this, 0, fieldName, pathToFile);
                        this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                        node.fieldButton.Text = fieldName;
                        nodes.Add(node);

                        this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                    }
                    else
                    {
                        MessageDialog form = new MessageDialog();
                        form.errorTxt.Text = "Не выбран файл со строками!";
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
                        form.Show(this);
                    }
                }
                else if (this.typeBox.SelectedIndex == 1)
                {
                    if (this.rangeFromTxt.Text == "" || this.rangeToTxt.Text == "")
                    {
                        errorMessage("Заполните все поля!");
                    }
                    else
                    {
                        node = new FieldNode(this, 1, fieldName, Int32.Parse(this.rangeFromTxt.Text), Int32.Parse(this.rangeToTxt.Text));
                        this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                        node.fieldButton.Text = fieldName;
                        nodes.Add(node);

                        this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                    }
                }
                else if (this.typeBox.SelectedIndex == 2)
                {
                    node = new FieldNode(this, 2, fieldName, this.dateFormatCbox.SelectedItem.ToString(), this.datePickerFrom.Value, this.datePickerTo.Value);
                    this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                    this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                    this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                    node.fieldButton.Text = fieldName;
                    nodes.Add(node);

                    this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                }
                else if (this.typeBox.SelectedIndex == 3)
                {
                    if (this.seqFromTxt.Text == "" || this.seqStepTxt.Text == "")
                    {
                        errorMessage("Заполните все поля!");
                    }
                    else
                    {
                        node = new FieldNode(this, fieldName, 3, Int32.Parse(this.seqFromTxt.Text), Int32.Parse(this.seqStepTxt.Text));
                        this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                        node.fieldButton.Text = fieldName;
                        nodes.Add(node);

                        this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                    }

                }
                else if (this.typeBox.SelectedIndex == 4)
                {
                    if (pathToFile != "")
                    {
                        node = new FieldNode(this, 4, fieldName, pathToFile);
                        this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                        this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                        node.fieldButton.Text = fieldName;
                        nodes.Add(node);

                        this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                    }
                    else
                    {
                        MessageDialog form = new MessageDialog();
                        form.errorTxt.Text = "Не выбран файл со строками!";
                        form.StartPosition = FormStartPosition.Manual;
                        form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
                        form.Show(this);
                    }
                }

                if (this.tableLayoutPanel.RowCount > 1)
                {
                    this.tooltip.Text = "Нажмите кнопку генерации";
                }
            }
            else
            {
                FieldNode node = nodes.ElementAt(editable-1);
                OpenFileDialog fbd = new OpenFileDialog();

                if (this.typeBox.SelectedIndex == 0)
                {
                    node.type = 0;
                    node.name = fieldName;
                    node.fieldButton.Text = fieldName;

                    DialogResult result = fbd.ShowDialog();
                    if (result.ToString() == "OK")
                        pathToFile = fbd.FileName;
                    else
                        pathToFile = "";

                    node.pathToFile = pathToFile;
                }
                else if (this.typeBox.SelectedIndex == 1)
                {
                    node.type = 1;
                    node.name = fieldName;
                    node.fieldButton.Text = fieldName;
                    node.from = Int32.Parse(this.rangeFromTxt.Text);
                    node.to = Int32.Parse(this.rangeToTxt.Text);
                }
                else if (this.typeBox.SelectedIndex == 2)
                {
                    node.type = 2;
                    node.name = fieldName;
                    node.fieldButton.Text = fieldName;
                    node.dateFormat = this.dateFormatCbox.SelectedItem.ToString();
                    node.dfrom = this.datePickerFrom.Value;
                    node.dto = this.datePickerTo.Value;
                }
                else if (this.typeBox.SelectedIndex == 3)
                {
                    node.type = 3;
                    node.name = fieldName;
                    node.fieldButton.Text = fieldName;
                    node.start = Int32.Parse(this.seqFromTxt.Text);
                    node.step = Int32.Parse(this.seqStepTxt.Text);
                }
                else if (this.typeBox.SelectedIndex == 4)
                {
                    node.type = 4;
                    node.name = fieldName;
                    node.fieldButton.Text = fieldName;

                    DialogResult result = fbd.ShowDialog();
                    if (result.ToString() == "OK")
                        pathToFile = fbd.FileName;
                    else
                        pathToFile = "";

                    node.pathToFile = this.pathToFile;
                }
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fbd = new OpenFileDialog();
            DialogResult result = fbd.ShowDialog();
            if (result.ToString() == "OK")
            {
                pathToFile = fbd.FileName;
            }
            else
            {
                pathToFile = "";
            }
        }

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            clearParametersPanel();

            ComboBox cbox = (ComboBox)sender;
            if (cbox.SelectedIndex == 0)
            {
                this.chooseButton.Visible = true;
                this.chooseLabel.Visible = true;
            }
            else if (cbox.SelectedIndex == 1)
            {
                this.rangeLbl.Visible = true;
                this.rangeFromTxt.Visible = true;
                this.rangeToTxt.Visible = true;
            }
            else if (cbox.SelectedIndex == 2)
            {
                this.dateFormatLbl.Visible = true;
                this.dateFormatCbox.Visible = true;
                this.datePariodLbl.Visible = true;
                this.datePickerFrom.Visible = true;
                this.datePickerTo.Visible = true;
            }
            else if (cbox.SelectedIndex == 3)
            {
                this.seqFromLbl.Visible = true;
                this.seqStepLbl.Visible = true;
                this.seqFromTxt.Visible = true;
                this.seqStepTxt.Visible = true;
            }
            else if (cbox.SelectedIndex == 4)
            {
                this.chooseButton.Visible = true;
                this.chooseLabel.Visible = true;
            }
        }

        private void numValidate(object sender, EventArgs e)
        {
            string val = ((TextBox)sender).Text;
            try
            {
                long a = long.Parse(val);
            }
            catch (FormatException)
            {
                val = Regex.Replace(val, @"[^0-9]", "");
                ((TextBox)sender).Text = val;
            }
        }

        void clearParametersPanel()
        {
            this.chooseButton.Visible = false;
            this.chooseLabel.Visible = false;

            this.rangeLbl.Visible = false;
            this.rangeFromTxt.Visible = false;
            this.rangeToTxt.Visible = false;

            this.seqFromLbl.Visible = false;
            this.seqStepLbl.Visible = false;
            this.seqFromTxt.Visible = false;
            this.seqStepTxt.Visible = false;

            this.dateFormatLbl.Visible = false;
            this.dateFormatCbox.Visible = false;
            this.datePariodLbl.Visible = false;
            this.datePickerFrom.Visible = false;
            this.datePickerTo.Visible = false;
        }

        void setDefaultParameters()
        {
            this.typeBox.SelectedIndex = 0;
            this.nameTxt.Text = "Безымянное";

            this.rangeFromTxt.Text = "1";
            this.rangeToTxt.Text = "10";

            this.seqFromTxt.Text = "1";
            this.seqStepTxt.Text = "1";

            this.dateFormatCbox.SelectedIndex = 0;
            this.datePickerFrom.Value = DateTime.Now;
            this.datePickerTo.Value = DateTime.Now;
        }
    }
}
