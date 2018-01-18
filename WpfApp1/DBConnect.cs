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

            //Constructor
            public DBConnect()
            {
                Initialize();
            }

            //Initialize values
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

            //open connection to database
            public bool OpenConnection()
            {
                try
                {
                    connection.Open();
                    //MessageBox.Show("Poprawnie połączono");
                    return true;
                }
                catch (MySqlException ex)
                {
                    //When handling errors, you can your application's response based 
                    //on the error number.
                    //The two most common error numbers when connecting are as follows:
                    //0: Cannot connect to server.
                    //1045: Invalid user name and/or password.
                    switch (ex.Number)
                    {
                        case 0:
                            MessageBox.Show("Cannot connect to server.  Contact administrator");
                            break;

                        case 1045:
                            MessageBox.Show("Invalid username/password, please try again");
                            break;
                    }
                    return false;
                }
            }

        //Insert statement
        public void Insert()
        {/*

            //string query = "INSERT INTO tableinfo (name, age) VALUES('John Smith', '33')";
            //string query = "insert into zgloszenie_szkody_samochodowej ( data_zgloszenia,status_zgloszenia, Polisa_samochodowa_ID, kraj, miasto, ulica, policja, samochod_zastepczy, laweta, numer_policji, id_klienta) VALUES('1','333', 'zate', '4', ' Polska', 'Krakow','ulica', 'd', 'p', 'g','4', '5' )";
            //string query = "insert into zgloszenie_szkody_samochodowej VALUES(@data_zgloszenia,@status_zgloszenia,@Polisa_samochodowa_ID, @kraj, @miasto, @ulica, @policja, @samochod_zastepczy, @laweta, @numer_policji, @id_klienta)";

            //open connection
            if (this.OpenConnection() == true)
            {
                //create command and assign the query and connection from the constructor
                //MySqlCommand cmd = new MySqlCommand(query, connection);
                //string query = "insert into zgloszenie_szkody_samochodowej VALUES(@data_zgloszenia,@status_zgloszenia,@Polisa_samochodowa_ID, @kraj, @miasto, @ulica, @policja, @samochod_zastepczy, @laweta, @numer_policji, @id_klienta)";
                string query = "insert into zgloszenie_szkody_samochodowej VALUES(@kraj, @miasto, @ulica)";

                //MySqlCommand cmd = new MySqlCommand("insert into zgloszenie_szkody_samochodowej VALUES(@id_zgloszenia,@data_zgloszenia,@status_zgloszenia,@Polisa_samochodowa_ID, @kraj, @miasto, @ulica, @policja, @samochod_zastepczy, @laweta, @numer_policji, @id_klienta)"),connection;
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //cmd.Parameters.AddWithValue("@data_zgloszenia", "222");
                //cmd.Parameters.AddWithValue("@status_zgloszenia", "dfas");
                //cmd.Parameters.AddWithValue("@Polisa_samochodowa_ID", "222");
                cmd.Parameters.AddWithValue("@kraj", "polska");
                cmd.Parameters.AddWithValue("@miasto", "krka");
                cmd.Parameters.AddWithValue("@ulica", "banan");
                //cmd.Parameters.AddWithValue("@policja", "1");
                //cmd.Parameters.AddWithValue(" @samochod_zastepczy", "1");
                //cmd.Parameters.AddWithValue(" @laweta", "1");
                //cmd.Parameters.AddWithValue(" @numer_policji", "222");
                //cmd.Parameters.AddWithValue(" @id_klienta", "5");

                //Execute command
                cmd.ExecuteNonQuery();

                //close connection
                this.CloseConnection();
            } */
        }

       
        //Close connection
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

            //Create a list to store the result
            List<string>[] list = new List<string>[3];
            list[0] = new List<string>();
            list[1] = new List<string>();
            list[2] = new List<string>();
            int ID;

            //Open connection
            if (this.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    //list[0].Add(dataReader["ID"] + "");
                    //list[1].Add(dataReader["imie"] + "");
                    //list[2].Add(dataReader["pesel"] + "");
                    //ID = Convert.ToInt32(dataReader["ID"] + "");
                    MessageBox.Show(dataReader["ID"] + "");
                    MessageBox.Show(dataReader["imie"] + "");
                }


                //close Data Reader
                dataReader.Close();

                // for( int i=0; i<2; i++) 
                // {
                //Console.WriteLine(list[i]);
                //string name = (list[i])
                //MessageBox.Show(name);
                // }
                // close Connection
                //MessageBox.Show(ID);
                this.CloseConnection();

                //return list to be displayed
                return list;
            }
            else
            {
                return list;
            }

            //string name = Convert.ToString(list[0]);
            //   MessageBox.Show(name);
        }


    }


}

