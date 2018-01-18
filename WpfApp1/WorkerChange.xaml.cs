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
    /// Interaction logic for WorkerChange.xaml
    /// </summary>
    public partial class WorkerChange : Window
    {
        public static string clientFormID;
        public WorkerChange()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string IDofClient = WorkerWindow.clientID;
            string IDofClientForm = WorkerChange.clientFormID;
            string query = "SELECT id_zgloszenia FROM zgloszenie_szkody_samochodowej WHERE id_klienta LIKE '%" + IDofClient + "%' AND id_zgloszenia LIKE '%" + IDofClientForm + "%' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();
                if (dataReader.Read() == false)
                    MessageBox.Show("Zgłoszenie nie istnieje. Proszę podać inny numer");
            else
            {
                WorkerChangeForm workerChangeForm = new WorkerChangeForm();
                workerChangeForm.Show();
                this.Close();
            }
                dataReader.Close();
                MainWindow.connect.CloseConnection();


            }
            
            else
            {
            }

        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            clientFormID = textBox.Text;
        }
    }
}
