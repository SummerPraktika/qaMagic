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

        List<string> data = new List<string>();
        public int type;
        public string name;
        public string pathToFile;
        public string dateFormat;
        public int from, to;
        public DateTime dfrom, dto;
        public int start, step;
        Random rand = new Random();

        public FieldNode(int type, string name, string pathToFile)
        {
            this.type = type;
            this.name = name;
            this.pathToFile = pathToFile;
            setData();
        }

        public FieldNode(string name, int type, string pathToFile)
        {
            this.type = type;
            this.name = name;
            this.pathToFile = pathToFile;
            setData();
        }

        public FieldNode(int type, string name, int from, int to)
        {
            this.type = type;
            this.name = name;
            this.from = from;
            this.to = to;
        }

        public FieldNode(int type, string name, string dateFormat, DateTime dfrom, DateTime dto)
        {
            this.type = type;
            this.name = name;
            this.dateFormat = dateFormat;
            this.dfrom = dfrom;
            this.dto = dto;
        }

        public FieldNode(string name, int type, int start, int step)
        {
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
    }
}
