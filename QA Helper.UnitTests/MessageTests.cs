using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using NUnit.Framework;
using NUnit.Extensions.Forms;
using System.Text;
using QA_Helper;
using System.ComponentModel;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace QA_Helper.UnitTests
{
    [TestFixture]
    public class MessageTests : NUnitFormTest
    {
        MessageDialog form = new MessageDialog();

        [Test]
        [ExpectedException(typeof(NoSuchControlException))]
        public void noSuchButtonStringTest()
        {
            form = new MessageDialog();
            form.Show();
            ButtonTester b = new ButtonTester("openBtn");
            b.Click();
        }

        [Test]
        public void nullTypeTest()
        {
            form = new MessageDialog();
            Assert.AreEqual(form.Text, "Сохранение шаблона");
        }
    }
}
