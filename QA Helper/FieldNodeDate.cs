using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QA_Helper
{
    public class FieldNodeDate : FieldNode
    {
            
            
     
        Random rand = new Random();
        public FieldNodeDate(int type, string name, string dateFormat, DateTime dfrom, DateTime dto)
        {
            this.type = type;
            this.name = name;
            this.dateFormat = dateFormat;
            this.dfrom = dfrom;
            this.dto = dto;
        }
         public override string getRndDate()
         {

             long ticks = dfrom.Ticks;
             //DateTime date2 = new DateTime(ticks).AddDays(rand.Next(0, (this.dto.Year - this.dfrom.Year) * 365 + this.dto.Year != this.dfrom.Year ? (365 - this.dfrom.DayOfYear) + this.dto.DayOfYear : this.dto.DayOfYear - this.dfrom.DayOfYear));
             DateTime date = new DateTime(ticks).AddTicks((long)(rand.NextDouble() * (dto.Ticks - dfrom.Ticks)));
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
         public override string getRndString()
         {
             return "";
         }
         public override string getSequentialString(int index)
         {
             return "";
         }
         public override long getRndNumber()
         {
             return 0;
         }
         public override long getSequenceNumber()
         {

             return 0;
         }
        
    }
}
