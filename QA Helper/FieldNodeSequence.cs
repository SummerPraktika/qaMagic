using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Helper
{
     public class FieldNodeSequence : FieldNode
    {
       
        Random rand = new Random();

       
        public FieldNodeSequence(string name, int type, long start, long step)
        {
            this.type = type;
            this.name = name;
            this.start = start;
            this.step = step;
        }
        public override long getSequenceNumber()
        {
            long number = this.start;
            this.start = this.start + this.step;
            return number;
        }
        public override string getRndString()
        {
          return  "";
        }
        public override string getSequentialString(int index)
        {
            return "";
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
