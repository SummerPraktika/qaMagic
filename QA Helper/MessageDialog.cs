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
    public partial class MessageDialog : Form
    {
        string filename = "";
        int type = -1;
        public bool cancel = false;
        private bool cancelCheked = false;
        public bool btn_continuy = false;
        public bool closing = false;
        public MessageDialog(string filename)
        {
            InitializeComponent();
            this.filename = filename;
        }
        public MessageDialog(int a)
        {
            InitializeComponent();
            type = a;
        }

        public MessageDialog()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            filename = textBox1.Text;
            if (filename != "")
            {
                cancel = false;
                btn_continuy = true;
                this.Close();
            }
            else
            {
                cancel = false;
                Message mess = new Message(this, "Oшибка", "Введите корректное имя шаблона!", MessageBoxIcon.Warning);
                mess.switchMessage();
                
            }

        }

        public string NameT
        {
            get { return filename; }
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            //continueButton.Location = new Point(43, 68);
            if (type == 0)
            {
                textBox1.Visible = true;
                label1.Visible = true;
                //continueButton.Location = new Point(88, 68);
                this.Text = "Сохранение шаблона";
            }


        }

        private void cancel_Click(object sender, EventArgs e)
        {
            cancel = true;
            cancelCheked = true;
            this.Close();
            return;
        }

        private void MessageDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            closing = true;
            if (cancelCheked)
            {
                Message mess = new Message(this, "Подтверждение", "Вы действительно хотите выйти?", e);
                mess.switchMessage();
            }

        }




    }
}
