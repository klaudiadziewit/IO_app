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
    /// Interaction logic for WorkerDelete.xaml
    /// </summary>
    public partial class WorkerDelete : Window
    {
        public static string clientFormID;
        public static string IDofClient = WorkerWindow.clientID;
        public static string query = $"SELECT id_zgloszenia FROM zgloszenie_szkody_samochodowej WHERE id_klienta = '{IDofClient}'";
        private static string ExecuteQuery(string query, string columnName)
        {
            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = MainWindow.connect.connection;
                MySqlDataReader dataReader = cmd.ExecuteReader();

                string result = null;
                while (dataReader.Read())
                {
                    result += dataReader[columnName] + " ";
                }
                dataReader.Close();
                MainWindow.connect.CloseConnection();
                return result;
            }
            else
            {
                return null;
            }
        }
        public WorkerDelete()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            var dane = ExecuteQuery(query, "id_zgloszenia");
            textBox2.Text = dane;
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string choose = textBox1.Text;
            string query = $"DELETE FROM zgloszenie_szkody_samochodowej WHERE id_zgloszenia = '{textBox1.Text}' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }
            MessageBox.Show("Pomyślnie usunięto zgłoszenie");
            this.Close();
        }

        private void textBox2_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WorkerWindow workerWindow = new WorkerWindow();
            workerWindow.Show();
            this.Close();
        }
    }
}
