using MySql.Data.MySqlClient;
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
        public static string clientID;
        public WorkerWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void acceptRegistration(object sender, RoutedEventArgs e)
        {
            WorkerSendChooseForm workerSendChooseForm = new WorkerSendChooseForm();
            workerSendChooseForm.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string workerID = textBox1.Text;
            string query = $"SELECT imie, nazwisko FROM pracownicy WHERE ID = '{workerID}' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    textBox2.Text = dataReader["imie"] + "" + " " + dataReader["nazwisko"] + "";
                }
                dataReader.Close();

                MainWindow.connect.CloseConnection();
            }
            else
            {              
            }
        }

        private void button3_Click(object sender, RoutedEventArgs e)
        {
            clientID = textBox3.Text;
            string query = $"SELECT imie, nazwisko FROM klienci WHERE ID = '{clientID}' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    textBox4.Text = dataReader["imie"] + "" + " " + dataReader["nazwisko"] + "";
                }
                dataReader.Close();
                MainWindow.connect.CloseConnection();
            }
            else
            {
            }
        }

        private void sendBackRegistration(object sender, RoutedEventArgs e)
        {
            WorkerChange workerChange = new WorkerChange();
            workerChange.Show();
            this.Close();
        }

        private void cancelRegistration(object sender, RoutedEventArgs e)
        {
            WorkerDelete workerDelete = new WorkerDelete();
            workerDelete.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startingWindow startingWindow = new startingWindow();
            startingWindow.Show();
            this.Close();
        }
    }
}
