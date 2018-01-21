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
using MySql.Data.MySqlClient;
namespace WpfApp1
{
    /// <summary>
    /// Logika interakcji dla klasy ClientWindow.xaml
    /// </summary>
    public partial class ClientWindow : Window
    {
        public static string client_id;
        public ClientWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }
     
        private void changingMyRegistration(object sender, RoutedEventArgs e)
        {
            ClientChange clientChange = new ClientChange();
            clientChange.Show();
            this.Close();
        }

        private void deleteRegistration(object sender, RoutedEventArgs e)
        {
            ClientDelete clientDelete = new ClientDelete();
            clientDelete.Show();
            this.Close();
        }

        private void sendRegistration(object sender, RoutedEventArgs e)
        {
            ClientSend clientSend = new ClientSend();
            clientSend.Show();
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        public void button_Click_3(object sender, RoutedEventArgs e)
        {
            client_id = textBox.Text;
            string id = textBox.Text;
            string query = $"SELECT imie, nazwisko FROM klienci WHERE ID = '{id}' ";         

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                 while (dataReader.Read())
                 {
                    textBox1.Text = dataReader["imie"] + "" + " " + dataReader["nazwisko"] + "";
                }

                dataReader.Close();

                MainWindow.connect.CloseConnection();
            }
            else
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            startingWindow startingWindow = new startingWindow();
            startingWindow.Show();
            this.Close();
        }
    }
   }
//}
