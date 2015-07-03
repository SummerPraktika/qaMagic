using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QA_Helper
{
    public class FieldNode
    {
        Form1 form;
        public Button fieldButton = new Button();
        public Button editButton = new Button();
        public Button deleteButton = new Button();

        List<string> data = new List<string>();
        public int type;
        public string name;
        public string pathToFile;
        public string dateFormat;
        public int from, to;
        public DateTime dfrom, dto;
        public int start, step;
        Random rand = new Random();

        public FieldNode(Form1 form, int type, string name, string pathToFile)
        {
            initButtons();
            this.form = form;

            this.type = type;
            this.name = name;
            this.pathToFile = pathToFile;
            setData();
        }

        public FieldNode(Form1 form, string name, int type, string pathToFile)
        {
            initButtons();
            this.form = form;

            this.type = type;
            this.name = name;
            this.pathToFile = pathToFile;
            setData();
        }

        public FieldNode(Form1 form, int type, string name, int from, int to)
        {
            initButtons();
            this.form = form;

            this.type = type;
            this.name = name;
            this.from = from;
            this.to = to;
        }

        public FieldNode(Form1 form, int type, string name, string dateFormat, DateTime dfrom, DateTime dto)
        {
            initButtons();
            this.form = form;

            this.type = type;
            this.name = name;
            this.dateFormat = dateFormat;
            this.dfrom = dfrom;
            this.dto = dto;
        }

        public FieldNode(Form1 form, string name, int type, int start, int step)
        {
            initButtons();
            this.form = form;

            this.type = type;
            this.name = name;
            this.start = start;
            this.step = step;
        }

        void setData()
        {
            string line;

            using (StreamReader file = new StreamReader(pathToFile, Encoding.Default))
            {
                while ((line = file.ReadLine()) != null)
                {
                    this.data.Add(line);
                }
            }
        }

        public string getRndString()
        {
            return this.data.ElementAt(rand.Next(0, this.data.Count));
        }

        public int getRndNumber()
        {
            return rand.Next(from, to);
        }

        public int getSequenceNumber()
        {
            int number = this.start;
            this.start = this.start + this.step;
            return number;
        }

        public string getRndDate()
        {

            long ticks = dfrom.Ticks;
            DateTime date = new DateTime(ticks).AddDays(rand.Next(0, (this.dto.Year - this.dfrom.Year) * 365 + this.dto.Year != this.dfrom.Year ? (365 - this.dfrom.DayOfYear) + this.dto.DayOfYear : this.dto.DayOfYear - this.dfrom.DayOfYear));

            return leadToFormat(date);
        }

        string leadToFormat(DateTime date)
        {
            string[] formats = { "dd.MM.yyyy", "MM.dd.yyyy", "dd.MM.yy", "MM.dd.yy", "yyyy.MM.dd", "yyyy.dd.MM", "yy.MM.dd", "yy.dd.MM" };

            foreach (string format in formats)
            {
                if (format.ToLower() == this.dateFormat.ToLower())
                {
                    return date.ToString(format);
                }
            }
            return date.ToString("dd.MM.yyyy");
        }



        public string getSequentialString(int index)
        {
            return this.data.ElementAt(index);
        }

        void initButtons()
        {
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = global::QA_Helper.Properties.Resources._1435861214_remove_sign2;
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.deleteButton.Location = new System.Drawing.Point(196, 0);
            this.deleteButton.Margin = new System.Windows.Forms.Padding(0);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(32, 32);
            this.deleteButton.TabIndex = 2;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(deleteButton_Click);
            // 
            // fieldButton
            // 
            this.fieldButton.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.fieldButton.Location = new System.Drawing.Point(0, 0);
            this.fieldButton.Margin = new System.Windows.Forms.Padding(0);
            this.fieldButton.Name = "fieldButton";
            this.fieldButton.Size = new System.Drawing.Size(164, 32);
            this.fieldButton.TabIndex = 1;
            this.fieldButton.Text = "Безымянное";
            this.fieldButton.UseVisualStyleBackColor = true;
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = global::QA_Helper.Properties.Resources._1435861155_edit;
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.editButton.Location = new System.Drawing.Point(164, 0);
            this.editButton.Margin = new System.Windows.Forms.Padding(0);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(32, 32);
            this.editButton.TabIndex = 0;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(editButton_Click);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            int row = form.tableLayoutPanel.GetRow((Button)sender);

            for (int i = 0; i < form.tableLayoutPanel.ColumnCount; i++)
            {
                Control c = form.tableLayoutPanel.GetControlFromPosition(i, row);
                form.tableLayoutPanel.Controls.Remove(c);
                c.Dispose();
            }

            form.tableLayoutPanel.RowCount--;

            form.tableLayoutPanel.ResumeLayout(false);
            form.tableLayoutPanel.PerformLayout();

            for (int i = row; i < Form1.nodes.Count() - 1; i++)
            {
                Form1.nodes[i] = Form1.nodes[i + 1];
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {

        }
    }
}
