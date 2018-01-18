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

      //  DBConnect connect1 = new DBConnect();
        

        public ClientWindow()
        {
            InitializeComponent();
           // connect1 = MainWindow.connect;

        }
     
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ClientSend clientSend = new ClientSend();
            clientSend.Show();
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void button_Click_3(object sender, RoutedEventArgs e)
        {
            //connect1.Select();

            string id = textBox.Text;

            string query = "SELECT imie, nazwisko FROM klienci WHERE ID LIKE '%" +  textBox.Text + "%' ";
            

            //Create a list to store the result
            // List<string>[] list = new List<string>[3];
            //  list[0] = new List<string>();
            // list[1] = new List<string>();
            //  list[2] = new List<string>();
            //   int ID;

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
                    //list[0].Add(dataReader["ID"] + "");
                    //list[1].Add(dataReader["imie"] + "");
                    //list[2].Add(dataReader["pesel"] + "");
                    //ID = Convert.ToInt32(dataReader["ID"] + "");
                    // MessageBox.Show(dataReader["ID"] + "");
                    textBox1.Text = dataReader["imie"] + "" + " " + dataReader["nazwisko"] + "";
                    // textBox1.Text =  dataReader["nazwisko"] + "";
                    //  dataReader["ID"] + ""


                  

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
                MainWindow.connect.CloseConnection();

                //return list to be displayed
             //   return list;
            }
            else
            {
             //   return list;
            }

            //string name = Convert.ToString(list[0]);
            //   MessageBox.Show(name);
        }


















        }
   }
//}
