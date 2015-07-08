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
//using System.Data.SQLite;
using System.Data.Entity;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

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
        private int locationXT = 0, locationYT = 0, deltaYT = 32; // Исходные параметры для кнопок - в панели шаблонов
        private List<Button> FieldBtn = new List<Button>(); // массив всех кнопок
        private List<Button> ParametresBtn = new List<Button>();
        private List<Button> DeleteBtn = new List<Button>();
        int tBtn = 0; //текущий номер кнопки 
        int clickedBtnIndex = -1; //номер нажатой кнопки, -1 - не нажата
        string[] standartListArray = new string[] { "Фамилии", "Имена", "Отчества", "Города", "Телефоны", "E-mail" };

        private Boolean isDragging = false;
        int delta = 32, draggableIndex, replaceableY, upperBound;

        private int unnamedIndex = 1;

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
                Message mess = new Message(this, "Oшибка", "Генерация отменена", MessageBoxIcon.Warning);
                mess.switchMessage();
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

                Message mess = new Message(this, "Oшибка", "Создайте хотя бы одно поле !", MessageBoxIcon.Warning);
                mess.switchMessage();
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
            catch (Exception) {
                Message mess = new Message(this, "Oшибка", "Файл не доступен для записи", MessageBoxIcon.Warning);
                mess.switchMessage();
                
            }
            Message mes1 = new Message(this, "Успех", "Открыть сгенерированный файл ?", pathSaveFile);
            mes1.switchMessage();
        }

        //void errorMessage(string text)
        // {
        //     Message mess = new Message(this, "Oшибка", "Что-то пошло не так :(",MessageBoxIcon.Warning);
        //     mess.switchMessage();
        //     //MessageDialog form = new MessageDialog();
        //     //form.errorTxt.Text = text;
        //     //form.Text = "Ошибка";
        //     //form.StartPosition = FormStartPosition.Manual;
        //     //form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
        //     //form.Show(this);
        // }

        //void simpleMessage(string text, string filename)
        // {

             
        //     //MessageDialog form = new MessageDialog(filename);
        //     //form.errorTxt.Text = text;
        //     //form.Text = "Успех";
        //     //form.StartPosition = FormStartPosition.Manual;
        //     //form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
        //     //form.Show(this);
        // }

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

            fitScrollBar();

            if (nodes.Count == 0)
            {
                this.tooltip.Text = "Добавьте поля для генерирования записей";
            }
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

           
            FieldNode node = nodes[clickedBtnIndex];

            if (node.type == 0)
            {
                typeBox.SelectedIndex = 0;
                nameTxt.Text = node.name;
                if (!standartListArray.Contains(node.pathToFile))
                {
                    fd.FileName = node.pathToFile;
                    //chooseLabel.Text = node.pathToFile.Substring(node.pathToFile.LastIndexOf("\\") + 1);
                    chooseLabel.Text = node.pathToFile;
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
                    //chooseLabel.Text = node.pathToFile.Substring(node.pathToFile.LastIndexOf("\\") + 1);
                    chooseLabel.Text = node.pathToFile;
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
                this.nameTxt.Text = "Безымянное_" + unnamedIndex;
                unnamedIndex++;
            }
            if (fieldName.Contains(" "))
            {
                this.nameTxt.Text = this.nameTxt.Text.Replace(" ", "_");
            }

            if (this.typeBox.SelectedIndex == 0)
            {
                if (fd.FileName == "" && standartList.SelectedIndex == 0)
                {
                    Message mess = new Message(this, "Oшибка", "Не выбран файл со строками или стандартный список!", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
                if (fd.FileName != "" && standartList.SelectedIndex != 0)
                {
                    Message mess = new Message(this, "Oшибка", "Выберите либо файл со строками, либо стандартный список!", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 1)
            {
                this.rangeFromTxt.Text = this.rangeFromTxt.Text.Trim();
                this.rangeToTxt.Text = this.rangeToTxt.Text.Trim();
                if (this.rangeFromTxt.Text == "" || this.rangeToTxt.Text == "")
                {
                    Message mess = new Message(this, "Oшибка", "Заполните все поля!", MessageBoxIcon.Warning);
                    mess.switchMessage();
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
                    Message mess = new Message(this, "Oшибка", "Неверный формат ввода", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
                if (a > b)
                {
                    Message mess = new Message(this, "Oшибка", "Начало диапазона не должно быть больше конца диапазона", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 2)
            {
                if (datePickerFrom.Value > datePickerTo.Value)
                {
                    Message mess = new Message(this, "Oшибка", "Начало диапазона дат не должно быть больше конца диапазона дат", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 3)
            {
                this.seqFromTxt.Text = this.seqFromTxt.Text.Trim();
                this.seqStepTxt.Text = this.seqStepTxt.Text.Trim();
                if (this.seqFromTxt.Text == "" || this.seqStepTxt.Text == "")
                {
                    Message mess = new Message(this, "Oшибка", "Заполните все поля!", MessageBoxIcon.Warning);
                    mess.switchMessage();
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
                    Message mess = new Message(this, "Oшибка", "Неверный формат ввода", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
            }
            else if (this.typeBox.SelectedIndex == 4)
            {
                if (fd.FileName == "" && standartList.SelectedIndex == 0)
                {
                    Message mess = new Message(this, "Oшибка", "Не выбран файл со строками или стандартный список!", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
                if (fd.FileName != "" && standartList.SelectedIndex != 0)
                {
                    Message mess = new Message(this, "Oшибка", "Выберите либо файл со строками, либо стандартный список!", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
            }


            if (clickedBtnIndex == -1) // если мы добавляем поле
                NewButton();
            else
            {
                FieldBtn[clickedBtnIndex].BackColor = defaultColor;
            }
            saveField(); // сохраняем изменения в FieldNode
            commonAddPanel.Visible = false;
            aboutText.Visible = true;
            fd.FileName = "";

            fitScrollBar();

            if (nodes.Count > 0)
            {
                this.tooltip.Text = "Нажмите \"Генерировать\" или используйте \"Настройки\" для изменения формата выходного файла";
            }
        }

        private void fitScrollBar()
        {
            if (this.LeftPanel.VerticalScroll.Visible)
            {
                LeftPanel.Size = new Size(250, 314);
            }
            else
            {
                LeftPanel.Size = new Size(230, 314);
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
                chooseLabel.Text = fd.FileName + "";
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
            if (val.Length > 1)
            {
                if (val.ElementAt(0) == '0' && val.ElementAt(1) == '0')
                {
                    val = val.Remove(1);
                    ((TextBox)sender).Text = val;
                }
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

        // Drag and Drop Functions
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
            int index = FieldBtn.IndexOf((Button)sender);

            FieldBtn[index].Location = new Point(FieldBtn[index].Location.X, replaceableY);
            ParametresBtn[index].Location = new Point(ParametresBtn[index].Location.X, replaceableY);
            DeleteBtn[index].Location = new Point(DeleteBtn[index].Location.X, replaceableY);
        }
        void btn_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            replaceableY = FieldBtn[FieldBtn.IndexOf((Button)sender)].Location.Y;
            int index = FieldBtn.IndexOf((Button)sender);
            draggableToFront(index);
        }

        void draggableToFront(int index)
        {
            for (int i = 0; i < FieldBtn.Count; i++)
            {
                LeftPanel.Controls.SetChildIndex(FieldBtn[i], i + 2);
                LeftPanel.Controls.SetChildIndex(ParametresBtn[i], i + 2);
                LeftPanel.Controls.SetChildIndex(DeleteBtn[i], i + 2);
            }
            LeftPanel.Controls.SetChildIndex(FieldBtn[index], 0);
            LeftPanel.Controls.SetChildIndex(ParametresBtn[index], 0);
            LeftPanel.Controls.SetChildIndex(DeleteBtn[index], 0);
        }

        void replaceButtons(Button draggable)
        {
            draggableIndex = FieldBtn.IndexOf(draggable);
            int draggableY = draggable.Location.Y;

            int minDist1 = draggableIndex > 0 ? Math.Abs(draggable.Location.Y - FieldBtn[draggableIndex - 1].Location.Y) : 999;
            int minDist2 = draggableIndex < FieldBtn.Count - 1 ? Math.Abs(draggable.Location.Y - FieldBtn[draggableIndex + 1].Location.Y) : 999;

            if (minDist1 < minDist2)
            {
                if (draggableY <= FieldBtn[draggableIndex - 1].Location.Y)
                {
                    replaceableY = FieldBtn[draggableIndex - 1].Location.Y;
                    FieldBtn[draggableIndex - 1].Location = new Point(FieldBtn[draggableIndex - 1].Location.X, FieldBtn[draggableIndex - 1].Location.Y + delta);
                    ParametresBtn[draggableIndex - 1].Location = new Point(ParametresBtn[draggableIndex - 1].Location.X, ParametresBtn[draggableIndex - 1].Location.Y + delta);
                    DeleteBtn[draggableIndex - 1].Location = new Point(DeleteBtn[draggableIndex - 1].Location.X, DeleteBtn[draggableIndex - 1].Location.Y + delta);
                    swapButtons(draggableIndex, draggableIndex - 1);
                }
            }
            else if (minDist1 > minDist2)
            {
                if (draggableY > FieldBtn[draggableIndex + 1].Location.Y)
                {
                    replaceableY = FieldBtn[draggableIndex + 1].Location.Y;
                    FieldBtn[draggableIndex + 1].Location = new Point(FieldBtn[draggableIndex + 1].Location.X, FieldBtn[draggableIndex + 1].Location.Y - delta);
                    ParametresBtn[draggableIndex + 1].Location = new Point(ParametresBtn[draggableIndex + 1].Location.X, ParametresBtn[draggableIndex + 1].Location.Y - delta);
                    DeleteBtn[draggableIndex + 1].Location = new Point(DeleteBtn[draggableIndex + 1].Location.X, DeleteBtn[draggableIndex + 1].Location.Y - delta);
                    swapButtons(draggableIndex, draggableIndex + 1);
                }
            }
        }

        void swapButtons(int draggableIndex, int replaceableIndex)
        {
            Button temp1 = FieldBtn[draggableIndex];
            Button temp2 = ParametresBtn[draggableIndex];
            Button temp3 = DeleteBtn[draggableIndex];

            FieldBtn[draggableIndex] = FieldBtn[replaceableIndex];
            ParametresBtn[draggableIndex] = ParametresBtn[replaceableIndex];
            DeleteBtn[draggableIndex] = DeleteBtn[replaceableIndex];

            FieldBtn[replaceableIndex] = temp1;
            ParametresBtn[replaceableIndex] = temp2;
            DeleteBtn[replaceableIndex] = temp3;

            FieldNode temp = nodes[draggableIndex];
            nodes[draggableIndex] = nodes[replaceableIndex];
            nodes[replaceableIndex] = temp;
        }
        // End Drag and Drop functions

        private void button1_Click(object sender, EventArgs e)
        {
            //сохранение шаблона
            //StreamWriter sr = new StreamWriter(@"test.txt");
            if (nodes.Count == 0)
            {
                Message mess = new Message(this, "Ошибка", "Добавьте хотя бы одно поле", MessageBoxIcon.Warning);
                mess.switchMessage();
                return;
            }

            MessageDialog md = new MessageDialog(0);
            md.StartPosition = FormStartPosition.Manual;
            md.Location = new Point(this.Location.X + (this.Width - md.Width) / 2, this.Location.Y + (this.Height - md.Height) / 2);
            md.ShowDialog();
            string nameT = md.NameT;
            string result_str = "";
            if (nameT.Trim() == "")// исправлен баг  с некорректным именем
            {
                Message mess = new Message(this, "Oшибка", "Введите корректное имя шаблона!", MessageBoxIcon.Warning);
                mess.switchMessage();
                return;
            }
            foreach (FieldNode a in nodes)
            {
                result_str += a.type.ToString() + ";";
                if (a.type == 0)
                {
                    result_str += a.name + ";";
                    if (a.pathToFile != "")
                    {
                        result_str += a.pathToFile.ToString() + ";";
                    }
                    else
                    {
                        result_str += standartList.SelectedItem.ToString() + ";";
                    }
                }
                if (a.type == 1)
                {
                    result_str += a.name + ";";
                    result_str += a.from.ToString() + ";";
                    result_str += a.to.ToString() + ";";
                }
                if(a.type == 2)
                {
                    result_str += a.name + ";";
                    result_str += a.dateFormat.ToString() + ";";
                    result_str += a.dfrom.ToString() + ";";
                    result_str += a.dto.ToString() + ";";
                }
                if(a.type == 3)
                {
                    result_str += a.name.ToString() + ";";
                    result_str += long.Parse(this.seqFromTxt.Text.Trim()) + ";";
                    result_str += long.Parse(this.seqStepTxt.Text.Trim()) + ";";
                }
                if (a.type == 4)
                {
                    result_str += a.name + ";";
                    if (a.pathToFile != "")
                        result_str += a.pathToFile.ToString() + ";";
                    else
                        result_str += standartList.SelectedValue.ToString() + ";";
                }
                result_str += "_";
            }
            using (var db = new MyDBContext())
            {
                var find = db.Templates.FirstOrDefault(x => x.Name == nameT);
                if (find != null)
                {
                    Message mess = new Message(this, "Oшибка!", "Такое имя шаблона уже существует!", MessageBoxIcon.Warning);
                    mess.switchMessage();
                    return;
                }
                db.Templates.Add(new Template { Name = nameT, Tmp = result_str });
                db.SaveChanges();
            }
            Message mes1 = new Message(this, "Успех", "Шаблон сохранен", MessageBoxIcon.Warning);
            mes1.switchMessage();
           
        }

        int kolVo = 0;
        Point location = new Point(0, 0);
        List<Button> TemplateBtnArray = new List<Button>();
        List<Button> DeleteBtnArray = new List<Button>();
        Form f2;
        Panel leftPanelT;
        int clickedBtnIndexT = -1;

        private void button2_Click(object sender, EventArgs e)
        {
            //обозреватель шаблонов
            int i = 0;
            TemplateBtnArray.Clear();
            DeleteBtnArray.Clear();
            f2 = new Form();
            f2.Text = "Шаблоны";
            f2.MinimizeBox = false;
            f2.MaximizeBox = false;
            f2.Size = new Size(260, 430);
            f2.FormBorderStyle = FormBorderStyle.FixedDialog;
            f2.StartPosition = FormStartPosition.Manual;
            f2.Location = new Point(this.Location.X + (this.Width - f2.Width) / 2, this.Location.Y + (this.Height - f2.Height) / 2);

            Label lblT = new Label();
            lblT.Location = new Point(25, 10);
            lblT.Size = new Size(198, 30);
            lblT.Text = "Список шаблонов :";
            lblT.Font = new Font("Segoe UI", 12);
            f2.Controls.Add(lblT);

            leftPanelT = new Panel();
            leftPanelT.AutoScroll = true;
            leftPanelT.Size = new Size(198, 300);
            leftPanelT.Location = new Point(25, 50);
            leftPanelT.BorderStyle = BorderStyle.FixedSingle;
            leftPanelT.Visible = true;
            f2.Controls.Add(leftPanelT);

            Button saveT = new Button();

            saveT.Location = new Point(23, 355);
            saveT.Size = new Size(98, 30);
            saveT.Font = new Font("Segoe UI", 8);
            saveT.Text = "Продолжить";
            saveT.Click += new System.EventHandler(this.saveT_Click);
            f2.Controls.Add(saveT);

            Button cancelT = new Button();
            cancelT.Location = new Point(127, 355);
            cancelT.Size = new Size(98, 30);
            cancelT.Font = new Font("Segoe UI", 8);
            cancelT.Text = "Отмена";
            cancelT.Click += new System.EventHandler(this.cancelT_Click);
            f2.Controls.Add(cancelT);

            using (var db = new MyDBContext())
            {
                foreach (var templete in db.Templates)
                {
                    Button TemplateBtnT = new Button();
                    TemplateBtnT.Size = new Size(164, 32);

                    Button deleteBtnT = new Button();
                    deleteBtnT.Size = new Size(32, 32);

                    int newLocationY;
                    if (TemplateBtnArray.Count == 0)
                        newLocationY = locationYT;
                    else
                    {

                        int maxY = TemplateBtnArray[TemplateBtnArray.Count - 1].Location.Y;
                        newLocationY = maxY + deltaYT;
                    }

                    TemplateBtnT.Location = new Point(locationXT, newLocationY);
                    TemplateBtnT.Visible = true;
                    TemplateBtnT.Text = templete.Name;
                    TemplateBtnT.Font = new Font("Segoe UI", 8);
                    TemplateBtnT.BackColor = defaultColor;
                    TemplateBtnT.Name = templete.Id.ToString();
                    

                    deleteBtnT.Location = new Point(locationXT + 164, newLocationY);
                    deleteBtnT.Visible = true;
                    deleteBtnT.Font = new Font("Segoe UI", 8);
                    deleteBtnT.BackgroundImage = Properties.Resources._1435861214_remove_sign;
                    deleteBtnT.BackgroundImageLayout = ImageLayout.Center;
                    deleteBtnT.Name = templete.Id.ToString();

                    TemplateBtnT.Click += new System.EventHandler(this.TemplateBtnT_Click);
                    deleteBtnT.Click += new System.EventHandler(this.deleteBtnT_Click);

                    TemplateBtnArray.Add(TemplateBtnT);
                    DeleteBtnArray.Add(deleteBtnT);

                    leftPanelT.Controls.Add(TemplateBtnT);
                    leftPanelT.Controls.Add(deleteBtnT);
                    i++;
                }
            }
            f2.Show();
        }
        

        private void cancelT_Click(object sender, EventArgs e)
        {
            f2.Close();
        }

        private void saveT_Click(object sender, EventArgs e)
        {
            if (clickedBtnIndexT == -1)
            {
                Message mess = new Message(this, "Oшибка", "Выберите шаблон!", MessageBoxIcon.Warning);
                mess.switchMessage();
                return;
            }
            nodes.Clear();
            foreach (Button b in FieldBtn)
                LeftPanel.Controls.Remove(b);
            foreach (Button b in ParametresBtn)
                LeftPanel.Controls.Remove(b);
            foreach (Button b in DeleteBtn)
                LeftPanel.Controls.Remove(b);
            FieldBtn.Clear();
            ParametresBtn.Clear();
            DeleteBtn.Clear();
            tBtn = 0;
            if (tBtn == -1)
            {
                Message mess = new Message(this, "Oшибка", "Выберите шаблон!", MessageBoxIcon.Warning);
                mess.switchMessage();
                return;
            }
            string f = "";
            try
            {

                 f = TemplateBtnArray[clickedBtnIndexT].Name.ToString();
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран шаблон ");
            }
            using (var db = new MyDBContext())
            {
                var find = from templ in db.Templates
                           where templ.Id.ToString() == f
                           select templ;
                if (find != null)
                {
                    foreach (var t in find)
                    {
                        string[] record = t.Tmp.Split(new Char[] { '_' });
                        foreach (var r in record)
                        {
                            FieldNode fn = null;
                            string[] pole = r.Split(new Char[] { ';' });
                            if (pole[0] == "0")
                            {
                                fn = new FieldNode(Int32.Parse(pole[0]), pole[1], pole[2]);
                            }
                            if (pole[0] == "1")
                            {
                                fn = new FieldNode(Int32.Parse(pole[0]), pole[1], long.Parse(pole[2]), long.Parse(pole[3]));
                            }
                            if (pole[0] == "2")
                            {
                                DateTime from = new DateTime();
                                DateTime to = new DateTime();
                                DateTime.TryParse(pole[3], out from);
                                DateTime.TryParse(pole[4], out to);
                                fn = new FieldNode(Int32.Parse(pole[0]), pole[1], pole[2], from, to);
                            }
                            if (pole[0] == "3")
                            {
                                fn = new FieldNode(pole[1], Int32.Parse(pole[0]), long.Parse(pole[2]), long.Parse(pole[3]));
                            }
                            if (pole[0] == "4")
                            {
                                fn = new FieldNode(Int32.Parse(pole[0]), pole[1], pole[2]);
                            }
                            if (fn != null)
                            {
                                nodes.Add(fn);
                                nameTxt.Text = fn.name;
                                NewButton();
                            }
                        }
                        //foreach(var n in nodes)
                        //  MessageBox.Show(n.type.ToString() + " : " + n.name.ToString());
                        //MessageBox.Show(t.Tmp);
                    }
                }
            }

            f2.Close();
        }

        private void deleteBtnT_Click(object sender, EventArgs e)
        {
            int id = int.Parse((sender as Button).Name.ToString());
            using (var db = new MyDBContext())
            {
                var del = db.Templates.SingleOrDefault(x => x.Id == id);
                if (del != null)
                {
                    db.Templates.Remove(del);
                    db.SaveChanges();
                }
            }
            int i = 0;
            foreach (Button b in DeleteBtnArray)
            {
                if (sender == b)
                {
                    leftPanelT.Controls.Remove(TemplateBtnArray[i]);
                    TemplateBtnArray[i].Dispose();
                    TemplateBtnArray.RemoveAt(i);
                    
                    leftPanelT.Controls.Remove(DeleteBtnArray[i]);
                    DeleteBtnArray[i].Dispose();
                    DeleteBtnArray.RemoveAt(i);

                    for (int j = i; j < TemplateBtnArray.Count; j++)
                    {
                        TemplateBtnArray[j].Location = new Point(TemplateBtnArray[j].Location.X, TemplateBtnArray[j].Location.Y - deltaY);
                        DeleteBtnArray[j].Location = new Point(DeleteBtnArray[j].Location.X, DeleteBtnArray[j].Location.Y - deltaY);
                    }
                    break;
                }
                i++;
            }
        }

        private void TemplateBtnT_Click(object sender, EventArgs e)
        {
            foreach (Button b in TemplateBtnArray)
            {
                b.BackColor = defaultColor;
            }
            int i = 0;
            foreach (Button b in TemplateBtnArray) {
                if (sender == b)
                {
                    clickedBtnIndexT = i;
                    b.BackColor = Color.Aqua;
                    break;
                }
                i++;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Message mess = new Message(this, "Подтверждение", "Вы действительно хотите выйти?", e);
            mess.switchMessage();

        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.commonAddPanel.Hide();
            defaultButtons();
        }
       


       

       
    }
}
