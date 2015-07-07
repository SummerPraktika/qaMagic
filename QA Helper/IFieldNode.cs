using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Helper
{
    public interface IFieldNode
    {
        int type();
        string name();
        string pathToFile();
        string dateFormat();
        long from();
        long to();
        DateTime dfrom();
        DateTime dto();
        long start();
        long step();

        //void FieldNode(int type, string name, string pathToFile);
        //void FieldNode(int type, string name, long from, long to);
        //void FieldNode(int type, string name, string dateFormat, DateTime dfrom, DateTime dto);
        //void FieldNode(string name, int type, long start, long step);
        string getRndString();
        long getRndNumber();
        long getSequenceNumber();
        string getRndDate();
        string getSequentialString(int index);

    }
}
