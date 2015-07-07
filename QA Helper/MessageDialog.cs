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
            this.Close();
        }

        public string NameT
        {
            get { return filename; }
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            textBox1.Visible = false;
            label1.Visible = false;
            continueButton.Location = new Point(43, 68);
            if (type == 0)
            {
                textBox1.Visible = true; 
                label1.Visible = true;
                continueButton.Location = new Point(88, 68);
                this.Text = "Сохранение шаблона";
            }
            
            
        }
       

        

    }
}
