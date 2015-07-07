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
        private List<FieldNode> fileNode = new List<FieldNode>(); //- массив параметров, НУЖЕН КЛАСС ПАРАМЕТРОВ, конструкторы ниже
        private Button[] leftBtn = new Button[60]; // массив всех кнопок
        int tBtn = 0; //текущий номер кнопки 
        int clickedBtnIndex = -1; //номер нажатой кнопки, -1 - не нажата

        public mainForm()
        {
            InitializeComponent();
            nothingShow();
        }

        private void AddBtn_Click(object sender, EventArgs e) // Клик Добавить кнопку
        {
            
            ParCB.SelectedIndex = 0;

            showParametresPanel();
            parametresShow();

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
        }

        private void ParOKBtn_Click(object sender, EventArgs e) // Клик ОК в панели Параметров
        {
            if (ParCB.SelectedIndex == 0)
            {
                //FieldNode fieldNode.Add(FieldNode(int type, string filename));
            }
            if (ParCB.SelectedIndex == 1)
            {
                //FieldNode fieldNode.Add(FieldNode(int type, int from, int to));
            }
            if (ParCB.SelectedIndex == 2)
            {
                //FieldNode fieldNode.Add(FieldNode(int type, string dateformat));
            }
            if (ParCB.SelectedIndex == 3)
            {
               // fileNode.Add( new FieldNode("asd", 3, 100, 1)); - работает
            }
            clearParametresPanel();
            nothingShow();
            if (clickedBtnIndex == -1) // если мы добавляем поле
                NewButton();
            else                       // если мы изменяем поле
            {
                //МЕНЯЕМ ПАРАМЕТРЫ ПОЛЯ В FileNode[]

            }

        }

        private void button1_Click(object sender, EventArgs e) // открытие диалога выбора файла со строками
        {
            OpenFileDialog fd = new OpenFileDialog();
            fd.ShowDialog();
            string name = fd.FileName;
            MessageBox.Show(name);
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
            LeftPanel.Controls.Add(newFieldBtn);
            newFieldBtn.Click += new System.EventHandler(this.newFieldBtn_Click);
            leftBtn[tBtn++] = newFieldBtn;
        }

        private void newFieldBtn_Click(object sender, EventArgs e) // Клик по кнопке на панели слева
        {
           
            ParametresPanel.Visible = true;
            showParametresPanel();
            //ЗДЕСЬ ПОДСТАВИТЬ ПАРАМЕТРЫ ИЗ FieldNode[]
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

            ParametresPanel.Location = new Point(ParametresPanel.Location.X, 100);
            descriptionShow();
        }

        private void ParDelBtn_Click(object sender, EventArgs e) // Клик по кнопке удаления
        {
            //удаление из массива FieldNode[];
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
            ParametresPanel.Visible = true;
            OptionsPanel.Visible = false;
        }

        private void descriptionShow() // Показ панели описания
        {
            InfoL.Text = "Описание";
            DescriptionL.Visible = true;
            DescriptionL.Text = "Описание...."; // здесь нужно что-то вставлять
            ParDelBtn.Visible = true;
            ParametresPanel.Visible = true;
            OptionsPanel.Visible = false;
        }

        private void optionsShow() // Показ панели опций
        {
            InfoL.Text = "Опции";
            DescriptionL.Visible = false;
            ParDelBtn.Visible = false;
            ParametresPanel.Visible = false;
            OptionsPanel.Visible = true;
        }

        private void nothingShow() // Отключение всех панелей
        {
            InfoL.Text = "";
            DescriptionL.Visible = false;
            ParDelBtn.Visible = false;
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
            SaveFileDialog sd = new SaveFileDialog();
            sd.ShowDialog();
            string name = sd.FileName;
            MessageBox.Show(name);
        }

        private void OptOKBtn_Click(object sender, EventArgs e)
        {
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
            for (int i = 0; i < 10; i++)
                    {
                        
                        foreach (FieldNode a in fileNode)
                        {
                            if (a.type == 0)
                            {
                                st += a.getRndString().ToString() + ";";//  вызов функции печати для поля со строками
                            }
                            if (a.type == 1)
                            {
                              st +=  a.getRndNumber().ToString() + ";"; // вызов функции печати для поля c рандомным числом из промежутка
                            }
                            if (a.type == 2)
                            {
                                st += a.getRndDate() + ";"; // вызов функции печати для поля дат
                            }
                            if (a.type == 3)
                            {
                                st += a.getSequenceNumber().ToString() + ";"; // вызов функции печати для поля c Шагом
                            }
                        }
                        st += "\n";
                        using (FileStream fs = new FileStream("end.csv", FileMode.Create))
                        {
                            using (StreamWriter writer = new StreamWriter(fs, Encoding.Default))
                            {


                                writer.Write(st);
                            }

                        }
                       
            }
        }

        private void RightPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GenerateBtn_Click(object sender, EventArgs e)
        {
            
            fileNode.Add(new FieldNode(1, "asdf", 100, 2000));
            fileNode.Add(new FieldNode("asd", 3, 100, 1));
            fileNode.Add(new FieldNode(1, "asdf", 100, 5000));
            fileNode.Add(new FieldNode(0, "asdf", "name.txt"));
            fileNode.Add(new FieldNode(0, "asdf", "surname.txt"));
            fileNode.Add(new FieldNode(0, "asdf", "secname.txt"));
            fileNode.Add(new FieldNode(2, "asd", "MM.dd.yyyy", new DateTime(1980, 1, 1), new DateTime(2015, 3, 2)));
            Generate();
        }
    }
}
