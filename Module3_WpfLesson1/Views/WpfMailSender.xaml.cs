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
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            About ab = new About();
            ab.ShowDialog(); 
        }

        private void btnClock_Click(object sender, RoutedEventArgs e)
        {
            tabControl1.SelectedItem = tabPlaner;
        }

        private void tscTabSwitcher_btnNextClick(object sender, RoutedEventArgs e)
        {
            if (tabControl1.SelectedIndex != tabControl1.Items.Count - 1)
                tabControl1.SelectedIndex = tabControl1.SelectedIndex + 1;
        }

        private void tscTabSwitcher_btnPreviousClick(object sender, RoutedEventArgs e)
        {
            if (tabControl1.SelectedIndex != 0)
                tabControl1.SelectedIndex = tabControl1.SelectedIndex - 1;
        }
    }

}

