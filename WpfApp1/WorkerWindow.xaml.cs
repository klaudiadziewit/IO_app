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
    /// Interaction logic for WorkerWindow.xaml
    /// </summary>
    public partial class WorkerWindow : Window
    {
        public WorkerWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WorkerSend workerSend = new WorkerSend();
            workerSend.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {

        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            WorkerChange workerChange = new WorkerChange();
            workerChange.Show();
            this.Close();
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            WorkerDelete workerDelete = new WorkerDelete();
            workerDelete.Show();
            this.Close();
        }
    }
}
