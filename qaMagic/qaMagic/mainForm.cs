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

namespace qaMagic
{
    public partial class mainForm : Form
    {
        private int locationX = 20, locationY = 25, deltaY = 40; // Исходные параметры для кнопок - в панели слева
        private Button[] leftBtn = new Button[60]; // массив всех кнопок
        int tBtn = 0; //текущий номер кнопки 
        int clickedBtnIndex = -1; //номер нажатой кнопки, -1 - не нажата
        private string filenameOfString;
        private string divider = ".";
        private string OpenFileName = "";
        FieldNode[] node = new FieldNode[100]; // Массив полей

        public mainForm()
        {
            InitializeComponent();
            nothingShow();
            CBDefault();
            
        }

        private void CBDefault()
        {
            OptFormatCB.SelectedIndex = 0;
            OptDivCB.SelectedIndex = 0;
            OptEncodeCB.SelectedIndex = 0;
            OptCountLines.Text = "100";

            ParDateCB.SelectedIndex = 0;
            ParCB.SelectedIndex = 0;
        }

        private void AddBtn_Click(object sender, EventArgs e) // Клик Добавить кнопку
        {
            showParametresPanel();
            parametresShow();

            ParCB.SelectedIndex = 0;
            StringPanel.Visible = true;
            SeqPanel.Visible = false;
            DatePanel.Visible = false;
            RangePanel.Visible = false;
           
            ParametresPanel.Location = new Point(ParametresPanel.Location.X, 40);
            clickedBtnIndex = -1;
            leftButtonsColorClear();
        }


        private void ParCB_SelectedIndexChanged(object sender, EventArgs e) // Изменение ComboBox с параметрами
        {
            if (ParCB.SelectedIndex == 0) // строка
            {
                clearParametresPanel();
                StringPanel.Visible = true;
            }
            if (ParCB.SelectedIndex == 1) // диапазон
            {
                clearParametresPanel();
                RangePanel.Visible = true;
            }
            if (ParCB.SelectedIndex == 2) // дата
            {
                clearParametresPanel();
                DatePanel.Visible = true;
            }
            if (ParCB.SelectedIndex == 3) // последовательность
            {
                clearParametresPanel();
                SeqPanel.Visible = true;
            }
            if (ParCB.SelectedIndex == 4) // строка последовательно
            {
                clearParametresPanel();
                StringPanel.Visible = true;
            }
        }

        private void saveField()
        {
            int index = clickedBtnIndex; // Индекс нажатой кнопки
            string name = ParNameTB.Text;
            if (clickedBtnIndex == -1) // Если добавляем новую кнопку
            {
                index = tBtn - 1;          // то ставим индекс новой кнопки
            }
            if (ParCB.SelectedIndex == 0)
            {
                node[index] = new FieldNode(0, name, filenameOfString);
            }
            if (ParCB.SelectedIndex == 1)
            {
                node[index] = new FieldNode(1, name, int.Parse(ParRangeFrom.Text), int.Parse(ParRangeTo.Text));
            }
            if (ParCB.SelectedIndex == 2)
            {
                node[index] = new FieldNode(2, name, ParDateCB.SelectedItem.ToString(), ParDateFrom.Value, ParDateTo.Value);
            }
            if (ParCB.SelectedIndex == 3)
            {
                node[index] = new FieldNode(name, 3, int.Parse(ParSeqFrom.Text), int.Parse(ParSeqStep.Text));
            }
            if (ParCB.SelectedIndex == 4)
            {
                node[index] = new FieldNode(4, name, filenameOfString);
            }
        }

        private void FieldUpBtn_Click(object sender, EventArgs e)
        {
            FieldUpBtn.Enabled = true; // Кнопки перемещения поля вверх
            FieldDownBtn.Enabled = true;
            FieldNode tmp = node[clickedBtnIndex - 1];
            node[clickedBtnIndex - 1] = node[clickedBtnIndex];
            node[clickedBtnIndex] = tmp;

            string name = leftBtn[clickedBtnIndex - 1].Text;
            leftBtn[clickedBtnIndex - 1].Text = leftBtn[clickedBtnIndex].Text;
            leftBtn[clickedBtnIndex].Text = name;

            leftBtn[clickedBtnIndex - 1].BackColor = Color.Aqua;
            leftBtn[clickedBtnIndex].BackColor = Color.Azure;

            clickedBtnIndex--;

            if (clickedBtnIndex == 0)
                FieldUpBtn.Enabled = false;
        }

        private void FieldDownBtn_Click(object sender, EventArgs e)
        {
            FieldUpBtn.Enabled = true; // Кнопки перемещения поля вниз
            FieldDownBtn.Enabled = true;

            FieldNode tmp = node[clickedBtnIndex + 1];
            node[clickedBtnIndex + 1] = node[clickedBtnIndex];
            node[clickedBtnIndex] = tmp;

            string name = leftBtn[clickedBtnIndex + 1].Text;
            leftBtn[clickedBtnIndex + 1].Text = leftBtn[clickedBtnIndex].Text;
            leftBtn[clickedBtnIndex].Text = name;

            leftBtn[clickedBtnIndex + 1].BackColor = Color.Aqua;
            leftBtn[clickedBtnIndex].BackColor = Color.Azure;

            clickedBtnIndex++;

            if (clickedBtnIndex == tBtn - 1)
                FieldDownBtn.Enabled = false;

        }

        private void newFieldBtn_Click(object sender, EventArgs e) // Клик по кнопке на панели слева
        {
            ParametresPanel.Visible = true;
            showParametresPanel();
            int index = 0;
            foreach (Button b in leftBtn)
            {
                if (b == sender)
                    clickedBtnIndex = index;
                if (b != null)
                    b.BackColor = Color.Azure;
                index++;
            }
            Button temp = (Button)sender;
            temp.BackColor = Color.Aqua;

            FieldUpBtn.Enabled = true; // Кнопки перемещения поля вверх / вниз
            FieldDownBtn.Enabled = true;
            if (clickedBtnIndex == 0)
                FieldUpBtn.Enabled = false;
            if (clickedBtnIndex == tBtn - 1)
                FieldDownBtn.Enabled = false;

            int type = node[clickedBtnIndex].type;
            ParCB.SelectedIndex = type;
            ParNameTB.Text = node[clickedBtnIndex].name;

            if (type == 0) // строка  //ТУТ ПРОИСХОДИТ ЗАПОЛНЕНИЕ ПАРАМЕТРОВ ДЛЯ ИХ ВОЗМОЖНОГО ИЗМЕНЕНИЯ ПОЛЬЗОВАТЕЛЕМ
            {
                clearParametresPanel();
                StringPanel.Visible = true;
                fd.FileName = node[clickedBtnIndex].pathToFile;
            }
            if (type == 1) // диапазон
            {
                clearParametresPanel();
                RangePanel.Visible = true;
                ParRangeFrom.Text = node[clickedBtnIndex].from.ToString();
                ParRangeTo.Text = node[clickedBtnIndex].to.ToString();
            }
            if (type == 2) // дата
            {
                clearParametresPanel();
                DatePanel.Visible = true;
                ParDateCB.SelectedItem = node[clickedBtnIndex].dateFormat;
                ParDateFrom.Value = node[clickedBtnIndex].dfrom;
                ParDateTo.Value = node[clickedBtnIndex].dto;
            }
            if (type == 3) // последовательность
            {
                clearParametresPanel();
                SeqPanel.Visible = true;
                ParSeqFrom.Text = node[clickedBtnIndex].start.ToString();
                ParSeqStep.Text = node[clickedBtnIndex].step.ToString(); 
            }
            if (type == 4) // строка посл
            {
                clearParametresPanel();
                StringPanel.Visible = true;
                fd.FileName = node[clickedBtnIndex].pathToFile;
            }

            ParametresPanel.Location = new Point(ParametresPanel.Location.X, 100);
            descriptionShow();
        }

        private void ParOKBtn_Click(object sender, EventArgs e) // Клик ОК в панели Параметров
        {

            int type = ParCB.SelectedIndex;
            if (ParNameTB.Text == "")
            {
                MessageBox.Show("Введите название поля");
                return;
            }
            if (type == 0) // строка
            {
                if (fd.FileName == "")
                {
                    MessageBox.Show("Выберите файл для генерации");
                    return;
                }
            }
            if (type == 1) // диапазон
            {
                Int64 a = 0, b = 0;
                if (ParRangeFrom.Text == "" || ParRangeFrom.Text == "")
                {
                    MessageBox.Show("Введите значения поля / полей");
                    return;
                }
                try
                {
                    a = Int64.Parse(ParRangeFrom.Text);
                    b = Int64.Parse(ParRangeTo.Text);
                }
                catch (ArgumentNullException)
                {
                    MessageBox.Show("Введите значения поля / полей");
                    return;
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
            if (type == 2) // дата
            {
                if (ParDateFrom.Value > ParDateTo.Value)
                {
                    MessageBox.Show("Начало диапазона дат не должно быть больше конца диапазона дат");
                    return;
                }
            }
            if (type == 3) // последовательность
            {
                Int64 a = 0, b = 0;
                if (ParSeqFrom.Text == "" || ParSeqStep.Text == "")
                {
                    MessageBox.Show("Введите значения поля / полей");
                    return;
                }
                try
                {
                    a = Int64.Parse(ParSeqFrom.Text);
                    b = Int64.Parse(ParSeqStep.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("Неверный формат ввода");
                    return;
                }
            }
            if (type == 4) // строка посл
            {
                if (fd.FileName == "")
                {
                    MessageBox.Show("Выберите файл для генерации");
                    return;
                }
            }
            clearParametresPanel();
            nothingShow();
            if (clickedBtnIndex == -1) // если мы добавляем поле
                NewButton();
            saveField(); // сохраняем изменения в FieldNode
        }

        private void button1_Click(object sender, EventArgs e) // открытие диалога выбора файла со строками
        {
            //OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            string name = fd.FileName;
            filenameOfString = name;
        }

        private void NewButton() // добавление новой кнопки
        {  //MAGIC
            Button newFieldBtn = new Button();
            newFieldBtn.Size = new Size(350, 40);
            int maxY = 0;
            foreach (Button b in leftBtn)
            {
                if (b != null && b.Location.Y > maxY)
                    maxY = b.Location.Y;
                    
            }
            int newLocationY;
            if (tBtn == 0)
                newLocationY = locationY;
            else
                newLocationY = maxY + deltaY;

            newFieldBtn.Location = new Point(locationX, newLocationY);
            AddBtn.Location = new Point(locationX, newLocationY + deltaY);
            newFieldBtn.Visible = true;
            newFieldBtn.Text = ParNameTB.Text;
            newFieldBtn.BackColor = Color.Azure;
            newFieldBtn.Font = new Font("Segoe UI", 12);
            

            LeftPanel.Controls.Add(newFieldBtn);
            newFieldBtn.Click += new System.EventHandler(this.newFieldBtn_Click);
            leftBtn[tBtn++] = newFieldBtn;
        }

        private void ParDelBtn_Click(object sender, EventArgs e) // Клик по кнопке удаления
        {
            
            if (clickedBtnIndex == -1)
                throw new FormatException();

            Button deletedBtn = leftBtn[clickedBtnIndex];
            if (LeftPanel.Controls.Contains(deletedBtn))
            {
                panel1.Controls.Remove(deletedBtn);
                deletedBtn.Dispose();
                leftBtn[clickedBtnIndex] = null;
                tBtn--;
            }
            for (int i = clickedBtnIndex + 1; i < leftBtn.Length; i++)
            {
                leftBtn[i - 1] = leftBtn[i];
                node[i - 1] = node[i];
                if (leftBtn[i] == null)
                    break;
                leftBtn[i - 1].Location = new Point(leftBtn[i - 1].Location.X, leftBtn[i - 1].Location.Y - deltaY);
            }
            AddBtn.Location = new Point(AddBtn.Location.X, AddBtn.Location.Y - deltaY);
            clickedBtnIndex = -1;
            ParametresPanel.Visible = false;
            nothingShow();
        }

        /* ПАНЕЛИ BEGIN */
        private void clearParametresPanel() // Очистка панелей ВЫБОРА параметров
        {
            foreach (Control p in ParametresPanel.Controls)
            {
                if (p is Panel) p.Visible = false;
            }

        }

        private void showParametresPanel() // Показ панелей ВЫБОРА параметров
        {
            foreach (Control p in ParametresPanel.Controls)
            {
                if (p is Panel) p.Visible = true;
            }

        }

        private void parametresShow() // Показ панели параметров
        {
            InfoL.Text = "Параметры";
            DescriptionL.Visible = false;
            ParDelBtn.Visible = false;
            FieldUpBtn.Visible = false;
            FieldDownBtn.Visible = false;
            ParametresPanel.Visible = true;
            OptionsPanel.Visible = false;
        }

        private void descriptionShow() // Показ панели описания
        {
            InfoL.Text = "Описание";
            DescriptionL.Visible = true;
            DescriptionL.Text = "Описание...."; // здесь нужно что-то вставлять
            ParDelBtn.Visible = true;
            FieldUpBtn.Visible = true;
            FieldDownBtn.Visible = true;
            ParametresPanel.Visible = true;
            OptionsPanel.Visible = false;
        }

        private void optionsShow() // Показ панели опций
        {
            InfoL.Text = "Опции";
            DescriptionL.Visible = false;
            ParDelBtn.Visible = false;
            FieldUpBtn.Visible = false;
            FieldDownBtn.Visible = false;
            ParametresPanel.Visible = false;
            OptionsPanel.Visible = true;
        }

        private void nothingShow() // Отключение всех панелей
        {
            InfoL.Text = "";
            DescriptionL.Visible = false;
            ParDelBtn.Visible = false;
            FieldUpBtn.Visible = false;
            FieldDownBtn.Visible = false;
            ParametresPanel.Visible = false;
            OptionsPanel.Visible = false;
        }
        /* ПАНЕЛИ END */
        /* ОПЦИИ BEGIN */
        private void OptionsBtn_Click(object sender, EventArgs e)
        {
            optionsShow();
            leftButtonsColorClear();
        }

        private void OptPathBtn_Click(object sender, EventArgs e)
        {
            //SaveFileDialog sd = new SaveFileDialog();
            sd.ShowDialog();
            OpenFileName = sd.FileName;
            //MessageBox.Show(name);
        }

        private void OptOKBtn_Click(object sender, EventArgs e)
        {
            if (sd.FileName == "")
            {
                MessageBox.Show("Выберите файл для генерации");
                return;
            }
            Int64 a = 0;
            if (OptCountLines.Text == "")
            {
                MessageBox.Show("Введите значения поля - количество генерируемых строк");
                return;
            }
            try
            {
                a = Int64.Parse(OptCountLines.Text);
            }
            catch (FormatException)
            {
                MessageBox.Show("Неверный формат ввода");
                return;
            }
            nothingShow();
        }
        /* ОПЦИИ END */

        private void leftButtonsColorClear() // Сброс цвета кнопок в панели слева
        {
            foreach (Button b in leftBtn)
            {
                if (b != null)
                    b.BackColor = Color.Azure;
            }
        }

        private void Generate() // Показ панели описания
        {
            string st = "";
            if (node[0] == null)
            {
                MessageBox.Show("Выберите хотя бы одно поле");
                return;
            }
            try
            {
                using (FileStream fs = new FileStream(sd.FileName, FileMode.Create))
                {
                    using (StreamWriter writer = new StreamWriter(fs, Encoding.GetEncoding(OptEncodeCB.SelectedItem.ToString())))
                    {
                        for (int i = 0; i < int.Parse(OptCountLines.Text); i++)
                        {

                            foreach (FieldNode a in node)
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
                MessageBox.Show("Выберите путь сохранения в опциях!");
                return;
            }
            catch (FileLoadException) { }
            MessageBox.Show("Генерация выполнена");
        }

        private void OptDivCB_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (OptDivCB.SelectedIndex == 0)
                divider = ".";
            if (OptDivCB.SelectedIndex == 1)
                divider = ",";
            if (OptDivCB.SelectedIndex == 2)
                divider = ";";
            if (OptDivCB.SelectedIndex == 3)
                divider = " ";
            if (OptDivCB.SelectedIndex == 4)
                divider = "\t";
        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            Generate();
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            try
            {
                if (OpenFileName != "")
                {
                    System.Diagnostics.Process.Start("explorer", OpenFileName);
                }
                else 
                {
                    MessageBox.Show("Сгенерируйте файл"); 
                }
                

            }
            catch (Win32Exception) 
            {
                MessageBox.Show("Невозможно открыть");
            }
            catch (ObjectDisposedException) { }
            catch (FileNotFoundException) 
            { 
                MessageBox.Show("Сгенерируйте файл"); 
            }

        }






    }
}
