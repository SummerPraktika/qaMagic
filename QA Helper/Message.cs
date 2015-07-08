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
    class Message
    {

        private Form1 form;
        private string title;
        private string message;
        private MessageBoxIcon icon;
        private FormClosingEventArgs fcea;
        private int type;
        private string filepath;
        /// <summary>
        ///  Конструктор вывод сообщений с кнопкой "ОК"
        /// </summary>
        /// <param name="form"> Форма</param>
        /// <param name="title">заголовок окна</param>
        /// <param name="message">сообщение окна</param>
        /// <param name="icon">иконка сообщения</param>
        public Message(Form1 form, string title, string message, MessageBoxIcon icon)
        {
            this.form = form;
            this.title = title;
            this.message = message;
            this.icon = icon;
            this.type = 0;


        }


        /// <summary>
        ///  Конструктор подтверждение закрытия приложения 
        /// </summary>
        /// <param name="form"> Форма</param>
        /// <param name="title">заголовок окна</param>
        /// <param name="message">сообщение окна</param>
        /// <param name="e">  аргумент события закрытия формы</param>
        public Message(Form1 form, string title, string message, FormClosingEventArgs e)
        {
            this.form = form;
            this.title = title;
            this.message = message;
            this.fcea = e;
            this.type = 1;


        }


        /// <summary>
        ///  Конструктор открытие сгенерированнаого файла 
        /// </summary>
        /// <param name="form"></param>
        /// <param name="titrle"></param>
        /// <param name="message"></param>
        /// <param name="?"></param>
        public Message(Form1 form, string title, string message, string filepath)
        {
            this.form = form;
            this.title = title;
            this.message = message;
            this.filepath = filepath;
            this.type = 2;



        }

        /// <summary>
        /// Метод вызывающий нужные функции для сообщения
        /// </summary>
        public void switchMessage()
        {
            switch (type)
            {
                case 0:
                    this.method1("");
                    break;
                case 1:
                    this.method2();
                    break;
                case 2:
                    this.method3();
                    break;
            }

        }

        /// <summary>
        /// Метод по выводу простого уведомления
        /// 
        /// </summary>
        /// параметр для вывода доп сообщений
        private void method1(string mess)
        {
            if (mess == "")
            {
                using (DialogCenteringService centeringService = new DialogCenteringService(form))
                {
                    var dg = MessageBox.Show(form,  message,title, MessageBoxButtons.OK, icon);

                }
            }
            else
            {
                using (DialogCenteringService centeringService = new DialogCenteringService(form))
                {
                    var dg = MessageBox.Show(form, mess, title, MessageBoxButtons.OK, icon);

                }

            }
        }
        /// <summary>
        /// Meтод вызывающий закрытие  приложения
        /// </summary>
        private void method2()
        {
            using (DialogCenteringService centeringService = new DialogCenteringService(form)) // center message box
            {
                var dg = MessageBox.Show(form, message, title, MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    return;
                }
                else
                {
                    fcea.Cancel = true;
                }
            }
        }

        /// <summary>
        /// метод вызывающий чтение файла
        /// </summary>
        private void method3()
        {
            using (DialogCenteringService centeringService = new DialogCenteringService(form)) // center message box
            {
                var dg = MessageBox.Show(form, message, title, MessageBoxButtons.YesNo);
                if (dg == DialogResult.Yes)
                {
                    try
                    {
                        if (filepath != "")
                        {
                            System.Diagnostics.Process.Start("notepad", filepath);
                        }
                        else
                        {
                            this.method1("Cгенерируйте файл!");
                        }


                    }
                    catch (Win32Exception)
                    {
                        this.method1("Невозможно открыть");
                    }
                    catch (ObjectDisposedException) { }
                    catch (FileNotFoundException)
                    {
                        this.method1("Cгенерируйте файл!");
                    }
                }



            }
        }
    }
        
}
