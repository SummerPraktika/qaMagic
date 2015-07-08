using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using QA_Helper;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Resources;
using System.Data.Common;

namespace QA_Helper.UnitTests
{
    [TestFixture]
    public class DataBaseTests
    {
        [Test]
        public void connectionTest() // тест на доступ
        {

            using (var db = new MyDBContext())
            {
                db.Templates.Add(new Template { Name = "name", Tmp = "string" });
                db.SaveChanges();
            }
        }

        [Test]
        public void deletionTest() // тест на удаление элемента
        {
            int id = 0;
            using (var db = new MyDBContext())
            {
                db.Templates.Add(new Template { Name = "name", Tmp = "string" });
                db.SaveChanges();
                foreach (var templete in db.Templates)
                {
                    id = templete.Id;
                }
                
            }
            using (var db = new MyDBContext()) {
                var del = db.Templates.SingleOrDefault(x => x.Id == id);
                db.Templates.Remove(del);
                db.SaveChanges();
            }
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))] // тест на удаление пустого элемента
        public void wrongDeletionTest()
        {
            int id = 0;
            using (var db = new MyDBContext())
            {
                var del = db.Templates.SingleOrDefault(x => x.Id == id);
                db.Templates.Remove(del);
                db.SaveChanges();
            }
        }

        [Test]
        public void entryTest() // тест на добавление и хранение
        {
            List<int> ids = new List<int>();
            Random r = new Random();
            int id = -1;
            using (var db = new MyDBContext())
            {
                db.Templates.Add(new Template { Name = "name", Tmp = "string" });
                db.SaveChanges();
                foreach (var templete in db.Templates)
                {
                    if (templete.Name == "name" && templete.Tmp == "string")
                        id = templete.Id;
                }
            }
            Assert.AreNotEqual("-1", id); 
        }

    }
}
