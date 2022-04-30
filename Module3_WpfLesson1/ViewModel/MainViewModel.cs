using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Module3_WpfLesson1.Commands;
using Module3_WpfLesson1.Commands.Base;

namespace Module3_WpfLesson1.ViewModel
{
    internal class MainViewModel
    {
        public MainViewModel()
        {
            ClosingCommand = new RelayCommand(OnClosingCommand, CanClosingCommandExecute);
        }

        public List<string> AdressesTo { get; set; } = EmailSendServiceClass.VariablesClass.Senders.Keys.ToList();

        public string SMTP { get; set; } = "smtp.gmail.com";
        public string To { get; set; } = "Адрес доставки";
        public string Subject { get; set; }
        public string Body { get; set; }

        private bool CheckFromAndTo()
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^[a-z0-9+_.-]+@[a-z0-9.-]+$");
            bool asd = regex.IsMatch(To);
            return asd;
        }

        public ICommand SendMailClick
        {
            get
            {
                return new DelegateCommand(x => EmailSendServiceClass.SMTPClient(To, Subject, Body), x => CheckFromAndTo());
            }
        }

        public ICommand CloseWindowCommand
        {
            get
            {
                return new DelegateCommand(x => Application.Current.Shutdown(), x => true);
            }
        }

        //public ICommand ClosingCommand
        //{
        //    get
        //    {
        //        return new DelegateCommand(x => EmailSendServiceClass.Log("Окно закрывается"));
        //    }
        //}

        public ICommand ClosingCommand { get; }

        private void OnClosingCommand(object o)
        {
            EmailSendServiceClass.Log("Окно закрывается");
        }

        private bool CanClosingCommandExecute(object o) => true;
    }
}
