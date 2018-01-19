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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy WorkerSendChooseForm.xaml
    /// </summary>
    public partial class WorkerSendChooseForm : Window
    {
        public static string clientFormID;
        public WorkerSendChooseForm()
        {
            InitializeComponent();


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clientFormID = textBox1.Text;
            if (true)
            {
                WorkerSend workerSend = new WorkerSend();
                workerSend.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie ma takiego zgłoszenia. Proszę wpisać poprawny numer");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
           
        }
    }
}
