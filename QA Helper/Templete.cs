using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
//using System.Data.SQLite;
using System.Data.Entity;
using System.Data.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace QA_Helper
{
    public class Templete
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Tmp { get; set; }
    }
    public class MyDBContext : DbContext
    {
        public MyDBContext(): base("DBTemplete16")
        {
        }
        public DbSet<Templete> Templetes { get; set; }
    }
    
    
}
