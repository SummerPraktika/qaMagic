using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Resources;

namespace QA_Helper
{
    public class FieldNodeString : FieldNode
    {
        //public List<string> data = new List<string>();
                
        Random rand = new Random();
        string[] standartListArray = new string[] { "Фамилии", "Имена", "Отчества", "Города", "Телефоны", "E-mail" };
        public FieldNodeString(int type, string name, string pathToFile)
        {
            this.type = type;
            this.name = name;
            this.pathToFile = pathToFile;
            if (!standartListArray.Contains(pathToFile))
                setData();
            else
                setStandartData();
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

            string[] res = resFile.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            this.data.AddRange(res);

        }

        public override string getRndString()
        {
            return this.data.ElementAt(rand.Next(0, this.data.Count));
        }
        public override string getSequentialString(int index)
        {
            return this.data.ElementAt(index % data.Count);
        }
        public override long getSequenceNumber()
        {
            
            return 0;
        }
        public override string getRndDate()
        {

            
            return "";
        }
        public override long getRndNumber()
        {
            return 0;
        }
    }
}
