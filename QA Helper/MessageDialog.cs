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
                continueButton.Location = new Point(43, 68);
                this.Text = "Сохранение шаблона";
            }
            
            if (filename != "")
            {
                this.Size = new Size(this.Size.Width + 100, this.Size.Height);
                errorTxt.Location = new Point(errorTxt.Location.X + 50, errorTxt.Location.Y);
                Button openBtn = new Button();
                openBtn.Size = new Size(95, 23);
                openBtn.Location = new Point(145, 68);
                openBtn.Visible = true;
                openBtn.Text = "Открыть файл";
                openBtn.Font = new Font("Segoe UI", 8);
                this.Controls.Add(openBtn);
                openBtn.Click += new System.EventHandler(this.openBtn_Click);
                this.Text = "Готово";
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename != "")
                {
                    System.Diagnostics.Process.Start("notepad", filename);
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
