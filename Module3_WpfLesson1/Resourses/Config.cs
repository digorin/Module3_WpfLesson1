using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Module3_WpfLesson1
{
    public static class Config
    {
        //Данные о клиентах
        public static string senderAdress = "greedimka@gmail.com";
        public static string senderName = "Dmitry";
        public static string password = File.ReadAllText($"{System.IO.Directory.GetCurrentDirectory()}/mypass.txt");
        public static string recipientAdress = "digorin@yandex.ru";

        //Данные сервера почты
        public static string smtpSever = "smtp.gmail.com";
        public static int smtpPort = 465;

        //Содаржание письма
        public static string messageSubject = "Тестовое приветствие";
        public static string messageBody = "< h2 > Письмо - тест работы smtp-клиента</h2>";
        public static bool isHtms = true;
    }

    public static class VariablesClass
    {
        public static Dictionary<string,string> Senders
        {
            get { return dicSenders; }
        }

        private static Dictionary<string, string> dicSenders = new Dictionary<string, string>()
        {
            { "79257443993@yandex.ru",PasswordClass.getPassword("1234l;i") },
            { "sok74@yandex.ru",PasswordClass.getPassword(";liq34tjk") }
        };
    }
}
