using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using QA_Helper;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Resources;
namespace QA_Helper.UnitTests
{
    [TestFixture]
    public class FieldNodeTests
    {
        FieldNode a, b, c, d;
        /// <summary>
        /// Тест FieldNode для  строки
        /// </summary>
        [SetUp ()]
        public void initFieldNodeString()
        {
            a = new FieldNode(0, "name", "Фамилии");

        }
        [Test]
        public void getSequentialStringTest()
        {

            int i = 3;
             string st = "";
            try
            {
                st = a.getSequentialString(i).ToString();
            }
            catch { }
            Assert.That(st, Is.EqualTo("Ярцев "));
        }
        [Test]
        public void getRndStringTest()
        {

            
             string st = "";
            try
            {
                st = a.getRndString().ToString();
            }
            catch { }
            Assert.Contains(st, a.data); // требуется изменение List<string> data на public доступ 
            
        }

        /// <summary>
        /// Тест FieldNode для последовательности
        /// </summary>
        [SetUp()]
        public void initFieldNodeStep()
        {
            b = new FieldNode("name", 2, 1, 1);

        }
        [Test]
        public void getSequenceNumberTest()
        {
            
            string st = "";
            try
            {
                st = b.getSequenceNumber().ToString();
            }
            catch { }
            Assert.That(st, Is.EqualTo("1"));
        }
        [Test]
        public void getSequenceNumberTest2()
        {
            b.getSequenceNumber();
            b.getSequenceNumber();

            string st = "";
            try
            {
                st = b.getSequenceNumber().ToString();
            }
            catch { }
            Assert.That(st, Is.EqualTo("3"));
        }
        /// <summary>
        /// Тест FieldNode для рандомного числа
        /// </summary>
        [SetUp()]
        public void initFieldNodeRand()
        {
            c = new FieldNode( 1 ,"name", 5, 7);

        }
        [Test]
        public void getRndNumberTest()
        {
           
             Assert.IsInstanceOfType(typeof(long), c.getRndNumber());
          //  Assert.That(c.getRndNumber(), Is.TypeOf(long));
        
        }
        [Test]
        public void getRndNumberTest2()
        {
            string st = "";
            bool namber = false;
            try
            {
                st = c.getRndNumber().ToString();
            }
            catch { }
            if ((st == "5") || (st == "6") || (st == "7"))
                namber = true;
            Assert.True(namber);

        }
    

        /// <summary>
        /// Тест FieldNode для даты
        /// </summary>
        [SetUp()]
        public void initFieldNodeDate()
        {
            d = new FieldNode(1, "name", "dd.MM.yyyy", new DateTime(2015, 5, 1), new DateTime(2015, 5, 2));

        }
        [Test]
        public void getRndDateTest()
        {

            string st = "";
            bool date = false;
            try
            {
                st = d.getRndDate().ToString();
            }
            catch { }
            if ((st == "01.05.2015")||(st == "02.05.2015")) 
                date = true;
            Assert.True(date);
            

        }
        

       
    }
}
