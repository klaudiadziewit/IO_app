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
        public ClientDelete()
        {
            InitializeComponent();
        }


        private void button_Click(object sender, RoutedEventArgs e)
        {

            string id_zgloszenia1 = textBox.Text;

            string query = "DELETE FROM zgloszenie_szkody_samochodowej WHERE id_zgloszenia LIKE '%" + id_zgloszenia1 + "%' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }

            MessageBox.Show("Zgłoszenie zostało usuniete");
            this.Close();
        }
    }
}
