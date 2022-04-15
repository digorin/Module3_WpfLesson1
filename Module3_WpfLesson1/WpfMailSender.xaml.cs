using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net;
using System.Net.Mail;
using System.IO;
namespace Module3_WpfLesson1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class WpfMailSender : Window
    {
        public WpfMailSender()
        {
            InitializeComponent();
            cbSenderSelect.ItemsSource = VariablesClass.Senders;
            cbSenderSelect.DisplayMemberPath = "Key";
            cbSenderSelect.SelectedValuePath = "Value";
        }


        ///// <summary>
        ///// Класс, который отвечает за работу с базой данных
        ///// </summary>
        //public class DBclass
        //{
        //    private EmailsDataContext emails = new EmailsDataContext();
        //    public IQueryable<Email> Emails
        //    {
        //        get
        //        {
        //            return from c in emails.Emails select c;
        //        }
        //    }

        //}

        //DBclass db = new DBclass();

        //private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        //{
        //    Config.password = passwordBox.Password;
        //    TextRange range = new TextRange(rtbMessage.Document.ContentStart, rtbMessage.Document.ContentEnd);

        //    EmailSendServiceClass.SMTPClient(MailSubjectText.Text, range == null ? "" : range.Text);
        //}

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.ShowDialog(); 
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedItem = tabPlaner;
        }

        private void btnSend_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnSendEmail_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
