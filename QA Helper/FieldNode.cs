using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Helper
{
    public abstract class  FieldNode
    {
        public int type;
        public string name;
        public string pathToFile;
        public  string dateFormat;
        public  long from;
        public  long to;
        public  DateTime dfrom;
        public  DateTime dto;
        public  long start;
        public  long step;
        public List<string> data = new List<string>();
        public abstract string getRndString();
        public abstract long getRndNumber();
        public abstract long getSequenceNumber();
        public abstract string getRndDate();
        public abstract string getSequentialString(int index);

    }
}
