using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;

namespace QA_Helper
{
    public class FieldNode
    {
        List<string> data = new List<string>();
        public int type;
        public string name;
        public string pathToFile;
        public string dateFormat;
        public long from, to;
        public DateTime dfrom, dto;
        public long start, step;
        Random rand = new Random();
        string[] standartListArray = new string[] { "Фамилии", "Имена", "Отчества", "Города", "Телефоны", "e-mail" };

        public FieldNode(int type, string name, string pathToFile)
        {
            this.type = type;
            this.name = name;
            this.pathToFile = pathToFile;
            if (!standartListArray.Contains(pathToFile))
                setData();
            else
                setStandartData();
        }

        public FieldNode(int type, string name, long from, long to)
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

        public FieldNode(string name, int type, long start, long step)
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

        void setStandartData()
        {
            string resFile = "";

            if (pathToFile == standartListArray[0])
                resFile = Properties.Resources.surnames;
            if (pathToFile == standartListArray[1])
                resFile = Properties.Resources.names;
            if (pathToFile == standartListArray[2])
                resFile = Properties.Resources.middlenames;
            if (pathToFile == standartListArray[3])
                resFile = Properties.Resources.cities;
            if (pathToFile == standartListArray[4])
                resFile = Properties.Resources.phones;
            if (pathToFile == standartListArray[5])
                resFile = Properties.Resources.emails;

            string[] res = resFile.Split(new char[] {'\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            this.data.AddRange(res);

        }

        public string getRndString()
        {
            return this.data.ElementAt(rand.Next(0, this.data.Count));
        }

        public long getRndNumber()
        {
            return (long)(rand.NextDouble() * (to - from) + from);
        }

        public long getSequenceNumber()
        {
            long number = this.start;
            this.start = this.start + this.step;
            return number;
        }

        public string getRndDate()
        {

            long ticks = dfrom.Ticks;
            //DateTime date2 = new DateTime(ticks).AddDays(rand.Next(0, (this.dto.Year - this.dfrom.Year) * 365 + this.dto.Year != this.dfrom.Year ? (365 - this.dfrom.DayOfYear) + this.dto.DayOfYear : this.dto.DayOfYear - this.dfrom.DayOfYear));
            DateTime date = new DateTime(ticks).AddTicks((long) (rand.NextDouble() * (dto.Ticks - dfrom.Ticks)));
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
            return this.data.ElementAt(index % data.Count);
        }
    }
}
