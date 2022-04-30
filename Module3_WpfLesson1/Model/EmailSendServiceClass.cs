using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Win32;


namespace Module3_WpfLesson1
{
    public class EmailSendServiceClass
    {
        public static void SMTPClient(string To, string subject, string message)
        {
            // отправитель - устанавливаем адрес и отображаемое в письме имя
            MailAddress from = new MailAddress(Config.senderAdress, Config.senderName);
            // кому отправляем
            MailAddress to = new MailAddress(To);
            // создаем объект сообщения
            MailMessage m = new MailMessage(from, to);
            // тема письма
            m.Subject = subject;
            // текст письма
            m.Body = message;
            // письмо представляет код html
            m.IsBodyHtml = true;

            //string attach = GetAttachement();
            //try
            //{
            //    if (attach != "")
            //        m.Attachments.Add(new Attachment(attach));
            //}
            //catch (Exception)
            //{
            //    Error er = new Error();
            //    er.ShowDialog();
            //}

            // адрес smtp-сервера и порт, с которого будем отправлять письмо
            SmtpClient smtp = new SmtpClient(Config.senderAdress, Config.smtpPort);
            // логин и пароль
            smtp.Credentials = new NetworkCredential(Config.senderAdress, Config.password);
            smtp.EnableSsl = true;
            try
            {
                smtp.Send(m);
                SendEndWindow sew = new SendEndWindow();
                sew.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Невозможно отправить письмо. Ошибка: {ex.ToString()}.");
            }

            Console.Read();

        }

        /// <summary>
        /// Метод позволяет выбрать файл для отправки почтой
        /// </summary>
        /// <returns>путь к файлу</returns>
        public static string GetAttachement()
        {
            string filePath = "";
            OpenFileDialog opd = new OpenFileDialog();
            if(opd.ShowDialog() == true)
            {
                filePath = opd.FileName;
            }
            return filePath;
        }

        public static void Log(string message)
        {
            string str = $"{DateTime.Now.ToLongTimeString()}:{message}";
            System.Diagnostics.Debug.WriteLine(str);
            System.IO.File.WriteAllText("log.txt", str);
        }

        /// <summary>
        /// Возвращает перечень адресов почты через свойство Senders
        /// </summary>
        public static class VariablesClass
        {
            public static Dictionary<string, string> Senders
            {
                get { return dicSenders; }
            }

            private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "greedimka@gmail.com",PasswordClass.getPassword("1234l;i") },
            { "sok74@yandex.ru",PasswordClass.getPassword(";liq34tjk") }
        };
        }
    }
}
