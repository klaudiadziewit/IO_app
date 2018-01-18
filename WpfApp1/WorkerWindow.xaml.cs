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
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            WorkerSend workerSend = new WorkerSend();
            workerSend.Show();
            this.Close();
        }

        private void button4_Click(object sender, RoutedEventArgs e)
        {
            string workerID = textBox1.Text;
            string query = "SELECT imie, nazwisko FROM pracownicy WHERE ID LIKE '%" + workerID + "%' ";

            //Open connection
            if (MainWindow.connect.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    textBox2.Text = dataReader["imie"] + "" + " " + dataReader["nazwisko"] + "";
                    // textBox1.Text =  dataReader["nazwisko"] + "";
                    //  dataReader["ID"] + ""
                }
                //close Data Reader
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

            string query = "SELECT imie, nazwisko FROM klienci WHERE ID LIKE '%" + clientID + "%' ";

            //Open connection
            if (MainWindow.connect.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    textBox4.Text = dataReader["imie"] + "" + " " + dataReader["nazwisko"] + "";
                    // textBox1.Text =  dataReader["nazwisko"] + "";
                    //  dataReader["ID"] + ""
                }
                //close Data Reader
                dataReader.Close();

                MainWindow.connect.CloseConnection();
            }
            else
            {
            }
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
