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
using MySql.Data.MySqlClient;
namespace WpfApp1
{
  public  class DBConnect
    {
            public MySqlConnection connection;
            private string server;
            private string database;
            private string uid;
            private string password;

            public DBConnect()
            {
                Initialize();
            }

            public void Initialize()
            {
                server = "mysql.agh.edu.pl";
                database = "jakubs1";
                uid = "jakubs1";
                password = "2n3k7t2NKukesf22";
                string connectionString;
                connectionString = "SERVER=" + server + ";" + "DATABASE=" +
                database + ";" + "UID=" + uid + ";" + "PASSWORD=" + password + ";";

             connection = new MySqlConnection(connectionString);
            }

            public bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (MySqlException ex)
                {
                    
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server. Contact administrator");
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }

        public void Insert()
        {
            if (this.OpenConnection() == true)
            {   
                MySqlCommand cmd = new MySqlCommand("insert into zgloszenie_szkody_samochodowej VALUES(NULL,@data_zgloszenia,@status_zgloszenia,@Polisa_samochodowa_ID, @kraj, @miasto, @ulica, @policja, @samochod_zastepczy, @laweta, @numer_policji, @id_klienta);", connection);                
                DateTime enteredDate = DateTime.Parse("22-02-2017");
                cmd.Parameters.AddWithValue("@data_zgloszenia", enteredDate);
                cmd.Parameters.AddWithValue("@status_zgloszenia", "blabla");
                cmd.Parameters.AddWithValue("@Polisa_samochodowa_ID", 1);
                cmd.Parameters.AddWithValue("@kraj", "polska");
                cmd.Parameters.AddWithValue("@miasto", "krakow");
                cmd.Parameters.AddWithValue("@ulica", "czarnowiejska");
                cmd.Parameters.AddWithValue("@policja", 1);
                cmd.Parameters.AddWithValue("@samochod_zastepczy", 1);
                cmd.Parameters.AddWithValue("@laweta", 1);
                cmd.Parameters.AddWithValue("@numer_policji", 222);
                cmd.Parameters.AddWithValue("@id_klienta", 5);

                cmd.ExecuteNonQuery();

                this.CloseConnection();
            } 
        }

        public bool CloseConnection()
            {
                try
                {
                    connection.Close();
                    return true;
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }                
            }

        public List<string>[] Select()
        {
            string query = "SELECT * FROM klienci";

            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();

            if (this.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, connection);
                MySqlDataReader dataReader = cmd.ExecuteReader();

                while (dataReader.Read())
                {
                    MessageBox.Show(dataReader["ID"] + "");
                    MessageBox.Show(dataReader["imie"] + "");
                }

                dataReader.Close();
                this.CloseConnection();

                return list;
            }
            else
            {
                return list;
            }
        }
    }


}

