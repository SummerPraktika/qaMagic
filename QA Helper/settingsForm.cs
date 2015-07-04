using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Text.RegularExpressions;

namespace QA_Helper
{
    public partial class settingsForm : Form
    {
        public settingsForm()
        {
            InitializeComponent();
        }

        private void saveSettingsButton_Click(object sender, EventArgs e)
        {
            if (this.recordsCountTxt.Text == "")
            {
                errorMessage("Количество записей должно быть от 1 до 10000");
            }
            else if (Int32.Parse(this.recordsCountTxt.Text) < 1 || Int32.Parse(this.recordsCountTxt.Text) > 10000)
            {
                errorMessage("Количество записей должно быть от 1 до 10000");
            }
            else
            {
                setConfig("format", this.formatBox.Text);
                setConfig("delimeter", this.delimeterBox.Text);
                setConfig("encoding", this.encodingBox.Text);
                setConfig("recordsCount", this.recordsCountTxt.Text);

                this.Close();
            }
        }

        public static void setConfig(String key, String value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Minimal);
        }

        public static string getSetting(string key)
        {
            return ConfigurationManager.OpenExeConfiguration(Application.ExecutablePath).AppSettings.Settings[key].Value;
        }

        private void settingsForm_Load(object sender, EventArgs e)
        {
            formatBox.SelectedItem = getSetting("format");
            delimeterBox.SelectedItem = getSetting("delimeter");
            encodingBox.SelectedItem = getSetting("encoding");
            recordsCountTxt.Text = getSetting("recordsCount");

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

        private void errorMessage(string text)
        {
            MessageDialog form = new MessageDialog();
            form.errorTxt.Text = text;
            form.StartPosition = FormStartPosition.Manual;
            form.Location = new Point(this.Location.X + (this.Width - form.Width) / 2, this.Location.Y + (this.Height - form.Height) / 2);
            form.Show(this);
        }
    }
}
