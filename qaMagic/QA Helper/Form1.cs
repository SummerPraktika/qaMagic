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

namespace QA_Helper
{
    public partial class Form1 : Form
    {
        public static List<FieldNode> nodes = new List<FieldNode>();
        string mode = "add";
        FieldNode node;
        string pathToFile = "";
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
            this.commonAddPanel.Show(); // Отобразить панель добавления поля
           
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
            catch (ArgumentException)
            {
                errorMessage("Выберите путь сохранения в опциях!");
                return;
            }
            catch (FileLoadException) { }
            MessageBox.Show("Генерация выполнена");
        }

        private void generateButton_Click(object sender, EventArgs e)
        {
            //nodes.Add(new FieldNode(this, "sdfsdf", 3, 1, 2));
            generate();
        }

        private void settingButton_Click(object sender, EventArgs e) // Отображает окошко с настройками
        {
            settingsForm form = new settingsForm();
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            form.Show(this);
        }

        private void applyFieldButton_Click(object sender, EventArgs e) // Добавляет поле в tableLayoutPanel и сохраняет параметры для поля
        {
            if (this.typeBox.SelectedIndex == 0)
            {
                if (pathToFile != "")
                {
                    node = new FieldNode(this, 0, this.nameTxt.Text, pathToFile);
                    this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount); // Добавление в конец tableLayoutPanel в 1 колонку
                    this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);  // Добавление в конец tableLayoutPanel во 2 колонку
                    this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);  // Добавление в конец tableLayoutPanel в 3 колонку
                    node.fieldButton.Text = this.nameTxt.Text;
                    nodes.Add(node);

                    this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                }
                else
                {
                    errorMessage("Не выбран файл со строками!");
                }
            }
            else if (this.typeBox.SelectedIndex == 1)
            {
                node = new FieldNode(this, 1, this.nameTxt.Text, Int32.Parse(this.rangeFromTxt.Text), Int32.Parse(this.rangeToTxt.Text));
                this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                node.fieldButton.Text = this.nameTxt.Text;
                nodes.Add(node);

                this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
            }
            else if (this.typeBox.SelectedIndex == 2)
            {
                node = new FieldNode(this, 2, this.nameTxt.Text, this.dateFormatCbox.SelectedItem.ToString(), this.datePickerFrom.Value, this.datePickerTo.Value);
                this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                node.fieldButton.Text = this.nameTxt.Text;
                nodes.Add(node);

                this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
            }
            else if (this.typeBox.SelectedIndex == 3)
            {
                node = new FieldNode(this, this.nameTxt.Text, 3, Int32.Parse(this.seqFromTxt.Text), Int32.Parse(this.seqStepTxt.Text));
                this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                node.fieldButton.Text = this.nameTxt.Text;
                nodes.Add(node);

                this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;

            }
            else if (this.typeBox.SelectedIndex == 4) 
            {
                if (pathToFile != "")
                {
                    node = new FieldNode(this, 4, this.nameTxt.Text, pathToFile);
                    this.tableLayoutPanel.Controls.Add(node.fieldButton, 0, this.tableLayoutPanel.RowCount);
                    this.tableLayoutPanel.Controls.Add(node.editButton, 1, this.tableLayoutPanel.RowCount);
                    this.tableLayoutPanel.Controls.Add(node.deleteButton, 2, this.tableLayoutPanel.RowCount);
                    node.fieldButton.Text = this.nameTxt.Text;
                    nodes.Add(node);

                    this.tableLayoutPanel.RowCount = this.tableLayoutPanel.RowCount + 1;
                }
                else
                {
                    errorMessage("Не выбран файл со строками!");
                }
            }
        }

        private void chooseButton_Click(object sender, EventArgs e) // Отображает окошко выбора файла
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

        private void typeBox_SelectedIndexChanged(object sender, EventArgs e) // Скрывает и показывает нужные элементы в соответствии с выбранным типом
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

        void errorMessage(string text)
        {
            MessageDialog form = new MessageDialog();
            form.errorLabel.Text = text;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            form.Show(this);
        }
    }
}
