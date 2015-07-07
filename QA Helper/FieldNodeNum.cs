using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Helper
{
    public class FieldNodeNum : FieldNode
    {

      
        Random rand = new Random();
        public FieldNodeNum(int type, string name, long from, long to)
        {
            this.type = type;
            this.name = name;
            this.from = from;
            this.to = to;
        }
        public override long getRndNumber()
        {
            return (long)(rand.NextDouble() * (to - from) + from);
        }
        public override string getRndString()
        {
            return "";
        }
        public override string getSequentialString(int index)
        {
            return "";
        }
        public override long getSequenceNumber()
        {

            return 0;
        }
        public override string getRndDate()
        {


            return "";
        }
       
        

    }
}
