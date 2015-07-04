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
        string pathToFile = "";
        public static int editable = 0;
        Color defaultColor = SystemColors.Control;

        private int locationX = 0, locationY = 0, deltaY = 32; // Исходные параметры для кнопок - в панели слева
        private List<Button> FieldBtn = new List<Button>(); // массив всех кнопок
        private List<Button> ParametresBtn = new List<Button>();
        private List<Button> DeleteBtn = new List<Button>();
        int tBtn = 0; //текущий номер кнопки 
        int clickedBtnIndex = -1; //номер нажатой кнопки, -1 - не нажата

        public Form1()
        {
            InitializeComponent();
            toolTip1.SetToolTip(addButton, "Добавить поле");
        }


        private void defaultButtons()
        {
            foreach (Button b in FieldBtn)
            {
                b.BackColor = defaultColor;
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            clickedBtnIndex = -1;
            this.addInfo.Text = "Добавление поля";
            this.applyFieldButton.Text = "Добавить поле";
            setDefaultParameters();
            defaultButtons();
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
            if (nodes.Count == 0)
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
                                    st += a.getRndString().ToString() + ((a == nodes[nodes.Count - 1]) ? " " : divider);//  вызов функции печати для поля со строками
                                }
                                if (a.type == 1)
                                {
                                    st += a.getRndNumber().ToString() + ((a == nodes[nodes.Count - 1]) ? " " : divider); // вызов функции печати для поля c рандомным числом из промежутка
                                }
                                if (a.type == 2)
                                {
                                    st += a.getRndDate() + ((a == nodes[nodes.Count - 1]) ? " " : divider); // вызов функции печати для поля дат
                                }
                                if (a.type == 3)
                                {
                                    st += a.getSequenceNumber().ToString() + ((a == nodes[nodes.Count - 1]) ? " " : divider); // вызов функции печати для поля c Шагом
                                }
                                if (a.type == 4)
                                {
                                    st += a.getSequentialString(i).ToString() + ((a == nodes[nodes.Count - 1]) ? " " : divider);//  вызов функции печати для поля со строками
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
            MessageBox.Show("Генерация выполнена");
        }

         void errorMessage(string text)
         {
             MessageDialog form = new MessageDialog();
             form.errorTxt.Text = text;
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

        private void NewButton() // добавление новой кнопки
        {  //MAGIC
            Button newFieldBtn = new Button();
            newFieldBtn.Size = new Size(164, 32);

            Button parametres = new Button();
            parametres.Size = new Size(32, 32);

            Button delete = new Button();
            delete.Size = new Size(32, 32);

            
            int newLocationY;
            if (tBtn == 0)
                newLocationY = locationY;
            else
            {
                int maxY = FieldBtn[tBtn - 1].Location.Y;
                newLocationY = maxY + deltaY;
            }

            newFieldBtn.Location = new Point(locationX, newLocationY);
            newFieldBtn.Visible = true;
            newFieldBtn.Text = nameTxt.Text;
            newFieldBtn.Font = new Font("Segoe UI", 8);
            newFieldBtn.BackColor = defaultColor;

            parametres.Location = new Point(locationX + 164, newLocationY);
            parametres.Visible = true;
            parametres.Font = new Font("Segoe UI", 8);
            parametres.BackgroundImage = Properties.Resources._1435861155_edit;
            parametres.BackgroundImageLayout = ImageLayout.Center;

            delete.Location = new Point(locationX + 196, newLocationY);
            delete.Visible = true;
            delete.Font = new Font("Segoe UI", 8);
            delete.BackgroundImage = Properties.Resources._1435861214_remove_sign;
            delete.BackgroundImageLayout = ImageLayout.Center;

            LeftPanel.Controls.Add(newFieldBtn);
            LeftPanel.Controls.Add(parametres);
            LeftPanel.Controls.Add(delete);

            //newFieldBtn.Click += new System.EventHandler(this.newFieldBtn_Click);
            parametres.Click += new System.EventHandler(this.parametres_Click);
            delete.Click += new System.EventHandler(this.delete_Click);

            FieldBtn.Add(newFieldBtn);
            ParametresBtn.Add(parametres);
            DeleteBtn.Add(delete);
            tBtn++;
        }

        private void delete_Click(object sender, EventArgs e)
        {
            commonAddPanel.Visible = false;
            aboutText.Visible = true;

            defaultButtons();
            int index = 0;
            foreach (Button b in DeleteBtn)
            {
                if (b == sender)
                    clickedBtnIndex = index;
                index++;
            }
            FieldBtn[clickedBtnIndex].Dispose();
            FieldBtn.RemoveAt(clickedBtnIndex);
            ParametresBtn[clickedBtnIndex].Dispose();
            ParametresBtn.RemoveAt(clickedBtnIndex);
            DeleteBtn[clickedBtnIndex].Dispose();
            DeleteBtn.RemoveAt(clickedBtnIndex);
            nodes.RemoveAt(clickedBtnIndex);
            for (int i = clickedBtnIndex; i < FieldBtn.Count; i++)
            {
                FieldBtn[i].Location = new Point(FieldBtn[i].Location.X, FieldBtn[i].Location.Y - deltaY);
                ParametresBtn[i].Location = new Point(ParametresBtn[i].Location.X, ParametresBtn[i].Location.Y - deltaY);
                DeleteBtn[i].Location = new Point(DeleteBtn[i].Location.X, DeleteBtn[i].Location.Y - deltaY);
            }
            tBtn--;
        }


        private void parametres_Click(object sender, EventArgs e) // Клик по кнопке на панели слева
        {
            commonAddPanel.Visible = true;
            aboutText.Visible = false;
            this.addInfo.Text = "Изменение поля";
            this.applyFieldButton.Text = "Изменить поле";
            int index = 0;
            foreach (Button b in FieldBtn)
            {
                b.BackColor = Color.Azure;
            }
            foreach (Button b in ParametresBtn)
            {
                if (b == sender)
                    clickedBtnIndex = index;
                index++;
            }
            FieldBtn[clickedBtnIndex].BackColor = Color.Aqua;

            //FieldUpBtn.Enabled = true; // Кнопки перемещения поля вверх / вниз
            //FieldDownBtn.Enabled = true;
            //if (clickedBtnIndex == 0)
            //    FieldUpBtn.Enabled = false;
            //if (clickedBtnIndex == tBtn - 1)
            //    FieldDownBtn.Enabled = false;
            FieldNode node = nodes[clickedBtnIndex];

            if (node.type == 0)
            {
                typeBox.SelectedIndex = 0;
                nameTxt.Text = node.name;
                fd.FileName = node.pathToFile;
            }
            else if (node.type == 1)
            {
                typeBox.SelectedIndex = 1;
                nameTxt.Text = node.name;
                rangeFromTxt.Text = node.from.ToString();
                rangeToTxt.Text = node.to.ToString();
               
            }
            else if (node.type == 2)
            {
                typeBox.SelectedIndex = 2;
                nameTxt.Text = node.name;
                dateFormatCbox.SelectedItem = node.dateFormat.ToString();
                datePickerFrom.Value = node.dfrom;
                datePickerTo.Value = node.dto;
              
            }
            else if (node.type == 3)
            {
                typeBox.SelectedIndex = 3;
                nameTxt.Text = node.name;
                seqFromTxt.Text = node.start.ToString();
                seqStepTxt.Text = node.step.ToString();
                
            }
            else if (node.type == 4)
            {
                typeBox.SelectedIndex = 4;
                nameTxt.Text = node.name;
                fd.FileName = node.pathToFile;
            }
        }

        private void applyFieldButton_Click(object sender, EventArgs e)
        {
            string fieldName = this.nameTxt.Text.ToString();
            fieldName = fieldName.ToString().Trim();
            if (fieldName == "")
            {
                this.nameTxt.Text = "Безымянное";
            }
            if (fieldName.Contains(" "))
            {
                this.nameTxt.Text = this.nameTxt.Text.Replace(" ", "_");
            }

            if (this.typeBox.SelectedIndex == 0)
            {
                if (fd.FileName == "")
                {
                    errorMessage("Не выбран файл со строками!");
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 1)
            {
                this.rangeFromTxt.Text = this.rangeFromTxt.Text.Trim();
                this.rangeToTxt.Text = this.rangeToTxt.Text.Trim();
                if (this.rangeFromTxt.Text == "" || this.rangeToTxt.Text == "")
                {
                    errorMessage("Заполните все поля!");
                    return;
                }

                long a, b;
                try
                {
                    a = long.Parse(rangeFromTxt.Text);
                    b = long.Parse(rangeToTxt.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат ввода");
                    return;
                }
                if (a > b)
                {
                    MessageBox.Show("Начало диапазона не должно быть больше конца диапазона");
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 2)
            {
                if (datePickerFrom.Value > datePickerTo.Value)
                {
                    MessageBox.Show("Начало диапазона дат не должно быть больше конца диапазона дат");
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 3)
            {
                this.seqFromTxt.Text = this.seqFromTxt.Text.Trim();
                this.seqStepTxt.Text = this.seqStepTxt.Text.Trim();
                if (this.seqFromTxt.Text == "" || this.seqStepTxt.Text == "")
                {
                    errorMessage("Заполните все поля!");
                    return;
                }
                long a, b;
                try
                {
                    a = long.Parse(seqFromTxt.Text);
                    b = long.Parse(seqStepTxt.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат ввода");
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 4)
            {
                if (fd.FileName == "")
                {
                    errorMessage("Не выбран файл со строками!");
                    return;
                }
            }
            
            if (clickedBtnIndex == -1) // если мы добавляем поле
                NewButton();
            else
                FieldBtn[clickedBtnIndex].BackColor = defaultColor;
            saveField(); // сохраняем изменения в FieldNode
            commonAddPanel.Visible = false;
            aboutText.Visible = true;

        }

        private void saveField()
        {
            if (clickedBtnIndex != -1)
                FieldBtn[clickedBtnIndex].Text = nameTxt.Text;
            if (this.typeBox.SelectedIndex == 0)
            {
                int type = 0;
                string name = this.nameTxt.Text;
                string pathToFile = fd.FileName;
                if (clickedBtnIndex == -1)
                    nodes.Add(new FieldNode(type, name, pathToFile));
                else
                    nodes[clickedBtnIndex] = new FieldNode(type, name, pathToFile);
                
            }
            else if (this.typeBox.SelectedIndex == 1)
            {
                int type = 1;
                string name = this.nameTxt.Text;
                long from = long.Parse(this.rangeFromTxt.Text.Trim());
                long to = long.Parse(this.rangeToTxt.Text.Trim());
                if (clickedBtnIndex == -1)
                    nodes.Add(new FieldNode(type, name, from, to));
                else
                    nodes[clickedBtnIndex] = new FieldNode(type, name, from, to);
            }
            else if (this.typeBox.SelectedIndex == 2)
            {
                int type = 2;
                string name = this.nameTxt.Text;
                string dateFormat = this.dateFormatCbox.SelectedItem.ToString();
                DateTime dfrom = this.datePickerFrom.Value;
                DateTime dto = this.datePickerTo.Value;
                if (clickedBtnIndex == -1)
                    nodes.Add(new FieldNode(type, name, dateFormat, dfrom, dto));
                else
                    nodes[clickedBtnIndex] = new FieldNode(type, name, dateFormat, dfrom, dto);
            }
            else if (this.typeBox.SelectedIndex == 3)
            {
                int type = 3;
                string name = this.nameTxt.Text;
                long start = long.Parse(this.seqFromTxt.Text.Trim());
                long step = long.Parse(this.seqStepTxt.Text.Trim());
                if (clickedBtnIndex == -1)
                    nodes.Add(new FieldNode(name, type, start, step));
                else
                    nodes[clickedBtnIndex] = new FieldNode(name, type, start, step);
            }
            else if (this.typeBox.SelectedIndex == 4)
            {
                
                int type = 4;
                string name = this.nameTxt.Text;
                string pathToFile = fd.FileName;
                if (clickedBtnIndex == -1)
                    nodes.Add(new FieldNode(type, name, pathToFile));
                else
                    nodes[clickedBtnIndex] = new FieldNode(type, name, pathToFile);
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = fd.ShowDialog();
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
