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
    /// Interaction logic for ClientDelete.xaml
    /// </summary>
    public partial class ClientDelete : Window
    {
        public static string clientFormID;
        public static string IDofClient = ClientWindow.client_id;
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

        public ClientDelete()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            var dane = ExecuteQuery(query, "id_zgloszenia");
            textBox2.Text = dane;
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {

            string id_zgloszenia1 = textBox.Text;

            string query = $"DELETE FROM zgloszenie_szkody_samochodowej WHERE id_zgloszenia LIKE '{id_zgloszenia1}' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }

            MessageBox.Show("Zgłoszenie zostało usunięte");
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClientWindow clientWindow = new ClientWindow();
            clientWindow.Show();
            this.Close();
        }
    }
}
