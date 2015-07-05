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
        public MessageDialog(string filename)
        {
            InitializeComponent();
            this.filename = filename;
        }

        public MessageDialog()
        {
            InitializeComponent();
        }

        private void continueButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MessageDialog_Load(object sender, EventArgs e)
        {
            if (filename != "")
            {
                this.Size = new Size(this.Size.Width + 100, this.Size.Height);
                errorTxt.Location = new Point(errorTxt.Location.X + 50, errorTxt.Location.Y);
                Button openBtn = new Button();
                openBtn.Size = new Size(95, 23);
                openBtn.Location = new Point(145, 62);
                openBtn.Visible = true;
                openBtn.Text = "Открыть файл";
                openBtn.Font = new Font("Segoe UI", 8);
                this.Controls.Add(openBtn);
                openBtn.Click += new System.EventHandler(this.openBtn_Click);
            }
        }

        private void openBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (filename != "")
                {
                    System.Diagnostics.Process.Start("explorer", filename);
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
