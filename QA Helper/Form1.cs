﻿using System;
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
        private Boolean isDragging = false;
        int draggableY, replaceableY, upperBound;
        int replaceableFirst, replaceableSecond = -1;
        Boolean scrollIsVisible = false;

        private int locationX = 0, locationY = 0, deltaY = 32; // Исходные параметры для кнопок - в панели слева
        private List<Button> FieldBtn = new List<Button>(); // массив всех кнопок
        private List<Button> ParametresBtn = new List<Button>();
        private List<Button> DeleteBtn = new List<Button>();
        int tBtn = 0; //текущий номер кнопки 
        int clickedBtnIndex = -1; //номер нажатой кнопки, -1 - не нажата
        string[] standartListArray = new string[] { "Фамилии", "Имена", "Отчества", "Города", "Телефоны", "E-mail" };

        public Form1()
        {
            InitializeComponent();

            this.CenterToScreen();
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
            this.chooseLabel.Text = "Файл не выбран";
            setDefaultParameters();
            defaultButtons();
            this.commonAddPanel.Show();
           
        }

        void generate()
        {
            SaveFileDialog sd = new SaveFileDialog();
            sd.Title = "Сохранение файла";
            sd.Filter = "CSV files|*.csv";
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
            simpleMessage("Генерация выполнена", pathSaveFile);
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

         void simpleMessage(string text, string filename)
         {
             MessageDialog form = new MessageDialog(filename);
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

            newFieldBtn.MouseDown += new MouseEventHandler(btn_MouseDown);
            newFieldBtn.MouseMove += new MouseEventHandler(btn_MouseMove);
            newFieldBtn.MouseUp += new MouseEventHandler(btn_MouseUp);

            toolTip1.SetToolTip(parametres, "Редактировать поле");
            toolTip1.SetToolTip(delete, "Удалить поле");

            FieldBtn.Add(newFieldBtn);
            ParametresBtn.Add(parametres);
            DeleteBtn.Add(delete);

            upperBound = newFieldBtn.Location.Y + 16;
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

            fitButtons();
        }


        private void parametres_Click(object sender, EventArgs e) // Клик по кнопке на панели слева
        {
            commonAddPanel.Visible = true;
            aboutText.Visible = false;
            this.addInfo.Text = "Изменение поля";
            this.applyFieldButton.Text = "Изменить поле";
            int index = 0;
            defaultButtons();
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
                if (!standartListArray.Contains(node.pathToFile))
                {
                    fd.FileName = node.pathToFile;
                    chooseLabel.Text = node.pathToFile.Substring(node.pathToFile.LastIndexOf("\\") + 1);
                }
                else
                {
                    standartList.SelectedItem = node.pathToFile;
                }
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
                if (!standartListArray.Contains(node.pathToFile))
                {
                    fd.FileName = node.pathToFile;
                    chooseLabel.Text = node.pathToFile.Substring(node.pathToFile.LastIndexOf("\\") + 1);
                }
                else
                {
                    standartList.SelectedItem = node.pathToFile;
                }
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
                if (fd.FileName == "" && standartList.SelectedIndex == 0)
                {
                    errorMessage("Не выбран файл со строками или стандартный список!");
                    return;
                }
                if (fd.FileName != "" && standartList.SelectedIndex != 0)
                {
                    errorMessage("Выберите либо файл со строками, либо стандартный список!");
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
                    errorMessage("Неверный формат ввода");
                    return;
                }
                if (a > b)
                {
                    errorMessage("Начало диапазона не должно быть больше конца диапазона");
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 2)
            {
                if (datePickerFrom.Value > datePickerTo.Value)
                {
                    errorMessage("Начало диапазона дат не должно быть больше конца диапазона дат");
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
                    errorMessage("Неверный формат ввода");
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 4)
            {
                if (fd.FileName == "" && standartList.SelectedIndex == 0)
                {
                    errorMessage("Не выбран файл со строками или стандартный список!");
                    return;
                }
                if (fd.FileName != "" && standartList.SelectedIndex != 0)
                {
                    errorMessage("Выберите либо файл со строками, либо стандартный список!");
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
            fd.FileName = "";

            fitButtons();
        }

        private void fitButtons()
        {
            if (this.LeftPanel.VerticalScroll.Visible)
            {
                LeftPanel.Size = new Size(250, 366);
            }
            else
            {
                LeftPanel.Size = new Size(230, 366);
            }
        }

        private void saveField()
        {
            if (clickedBtnIndex != -1)
                FieldBtn[clickedBtnIndex].Text = nameTxt.Text;
            if (this.typeBox.SelectedIndex == 0)
            {
                int type = 0;
                string name = this.nameTxt.Text;
                string pathToFile;
                if (fd.FileName != "")
                {
                    pathToFile = fd.FileName;
                }
                else
                {
                    pathToFile = standartList.SelectedItem.ToString();
                }
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
                string pathToFile;
                if (fd.FileName != "")
                {
                    pathToFile = fd.FileName;
                }
                else
                {
                    pathToFile = standartList.SelectedItem.ToString();
                }
                if (clickedBtnIndex == -1)
                    nodes.Add(new FieldNode(type, name, pathToFile));
                else
                    nodes[clickedBtnIndex] = new FieldNode(type, name, pathToFile);
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            DialogResult result = fd.ShowDialog();
            
            if (result == DialogResult.OK)
            {
                chooseLabel.Text = fd.SafeFileName + "";
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
                this.standartList.Visible = true;
                this.standartListLbl.Visible = true;
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
                this.standartList.Visible = true;
                this.standartListLbl.Visible = true;
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
            this.standartList.Visible = false;
            this.standartListLbl.Visible = false;

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
            standartList.SelectedIndex = 0;
            this.nameTxt.Text = "Безымянное";

            this.rangeFromTxt.Text = "1";
            this.rangeToTxt.Text = "10";

            this.seqFromTxt.Text = "1";
            this.seqStepTxt.Text = "1";

            this.dateFormatCbox.SelectedIndex = 0;
            this.datePickerFrom.Value = DateTime.Now;
            this.datePickerTo.Value = DateTime.Now;
        }

        void btn_MouseMove(object sender, MouseEventArgs e)
        {
            int index = FieldBtn.IndexOf((Button)sender);
            int mouseY = this.PointToClient(Cursor.Position).Y;

            if (isDragging && mouseY > LeftPanel.Location.Y && mouseY < upperBound)
            {
                int a = Cursor.Position.Y;
                FieldBtn[index].Top = e.Y + ((Button)sender).Top;
                ParametresBtn[index].Top = e.Y + ((Button)sender).Top;
                DeleteBtn[index].Top = e.Y + ((Button)sender).Top;

                replaceButtons((Button)sender);
            }
        }

        void btn_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

            if (replaceableFirst > -1)
            {
                FieldBtn[replaceableFirst].Location = new Point(FieldBtn[replaceableFirst].Location.X, replaceableY);
                ParametresBtn[replaceableFirst].Location = new Point(ParametresBtn[replaceableFirst].Location.X, replaceableY);
                DeleteBtn[replaceableFirst].Location = new Point(DeleteBtn[replaceableFirst].Location.X, replaceableY);
                //swapButtons();
            }
            replaceableSecond = -1;
        }
        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            if (FieldBtn.Count > 1)
            {
                isDragging = true;
                draggableY = ((Button)sender).Location.Y;
                replaceableY = draggableY;
                replaceableFirst = FieldBtn.IndexOf((Button)sender);
                replaceableSecond = replaceableFirst;
            }
        }

        void replaceButtons(Button draggable)
        {
            int draggableIndex = FieldBtn.IndexOf(draggable);
            for (int i = 0; i < FieldBtn.Count; i++)
            {
                if (i != draggableIndex)
                {
                    Button field = FieldBtn[i];
                    Button parameters = ParametresBtn[i];
                    Button delete = DeleteBtn[i];
                    int Y = field.Location.Y;

                    if (draggable.Location.Y == Y)
                    {
                        replaceableY = field.Location.Y;
                        field.Location = new Point(field.Location.X, draggableY);
                        parameters.Location = new Point(parameters.Location.X, draggableY);
                        delete.Location = new Point(delete.Location.X, draggableY);
                        draggableY = Y;

                        if (draggableIndex < i)
                        {
                            LeftPanel.VerticalScroll.Value = i;
                        }
                        else
                        {
                            LeftPanel.VerticalScroll.Value = i;
                            if (i == 1)
                            {
                                LeftPanel.VerticalScroll.Value = 0;
                            }
                        }

                        replaceableSecond = replaceableFirst;
                        replaceableFirst = i;

                        swapButtons();
                    }
                    else if (draggable.Location.Y != Y && draggableY != replaceableY)
                    {
                        field.Location = new Point(field.Location.X, replaceableY);
                        parameters.Location = new Point(parameters.Location.X, replaceableY);
                        delete.Location = new Point(delete.Location.X, replaceableY);
                        replaceableY = draggableY;

                        LeftPanel.VerticalScroll.Visible = scrollIsVisible;
                    }
                }
            }
        }

        void swapButtons()
        {
            Button temp1 = FieldBtn[replaceableFirst];
            Button temp2 = ParametresBtn[replaceableFirst];
            Button temp3 = DeleteBtn[replaceableFirst];

            FieldBtn[replaceableFirst] = FieldBtn[replaceableSecond];
            ParametresBtn[replaceableFirst] = ParametresBtn[replaceableSecond];
            DeleteBtn[replaceableFirst] = DeleteBtn[replaceableSecond];

            FieldBtn[replaceableSecond] = temp1;
            ParametresBtn[replaceableSecond] = temp2;
            DeleteBtn[replaceableSecond] = temp3;

            FieldNode temp = nodes[replaceableFirst];
            nodes[replaceableFirst] = nodes[replaceableSecond];
            nodes[replaceableSecond] = temp;
        }
    }
}
