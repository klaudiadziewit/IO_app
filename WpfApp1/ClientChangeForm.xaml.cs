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
    /// Interaction logic for ClientChangeForm.xaml
    /// </summary>
    public partial class ClientChangeForm : Window
    {

        public static string C1, C2, C3, clientID;
         RegistrationForm registrationform = new RegistrationForm();
        public void uzupelnij()
        {




            

            string query = "SELECT data_zgloszenia,kraj,miasto,ulica,policja,samochod_zastepczy,laweta,numer_policji FROM zgloszenie_szkody_samochodowej WHERE id_zgloszenia LIKE '%" + clientID + "%' ";

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
                    DateTime enteredDate = DateTime.Parse(dataReader["data_zgloszenia"]+"");
                    TextBox1.Text = Convert.ToString(enteredDate);
                    TextBox2.Text = dataReader["kraj"] + "";
                    TextBox3.Text = dataReader["miasto"] + "";
                    TextBox4.Text = dataReader["ulica"] + "";

                    C1 = dataReader["policja"] + "";
                    C2 = dataReader["samochod_zastepczy"] + "";
                    C3 = dataReader["laweta"] + "";
                    TextBox.Text = dataReader["numer_policji"] + "";

                }
                //close Data Reader
                dataReader.Close();

                MainWindow.connect.CloseConnection();
            }
            else
            {
            }
            if (C1 == "1")
            {
                CheckBox1.IsChecked = true;
            }
            else
            {
                CheckBox2.IsChecked = true;
            }

            if (C2 == "1")
            {
                CheckBox3.IsChecked = true;
            }
            else
            {
                CheckBox4.IsChecked = true;
            }

            if (C3 == "1")
            {
                CheckBox5.IsChecked = true;
            }
            else
            {
                CheckBox6.IsChecked = true;
            }

        }
        public ClientChangeForm()
        {
            InitializeComponent();
            uzupelnij();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

            int licznik = 0;




            if (TextBox1.Text == "")
            {
                licznik++;
            }
            if (TextBox2.Text == "")
            {
                licznik++;
            }
            if (TextBox3.Text == "")
            {
                licznik++;
            }
            if (TextBox4.Text == "")
            {
                licznik++;
            }

            if (CheckBox1.IsChecked == false && CheckBox2.IsChecked == false)
            {
                licznik++;
            }

            if (CheckBox1.IsChecked == true)
            {
                if (TextBox4.Text == "") { licznik++; }
            }
            if (CheckBox3.IsChecked == false && CheckBox4.IsChecked == false)
            {
                licznik++;
            }
            if (CheckBox5.IsChecked == false && CheckBox6.IsChecked == false)
            {
                licznik++;
            }
            if (licznik != 0)
            {
                TextBox5.Text = "Niepoprawnie uzupełniono";

            }

            else
            {
                TextBox5.Text = "Poprawnie uzupełniono";
                //update
                //string query = "UPDATE zgloszenie_szkody_samochodowej SET imie='Joe', age='22' WHERE name='John Smith'";
                //string query = "SELECT data_zgloszenia,kraj,miasto,ulica,policja,samochod_zastepczy,laweta,numer_policji FROM zgloszenie_szkody_samochodowej WHERE id_zgloszenia LIKE '%" + clientID + "%' ";

                string query = "UPDATE zgloszenie_szkody_samochodowej SET data_zgloszenia='"+TextBox1.Text+ "', kraj='"+TextBox2.Text+ "', miasto='" + TextBox3.Text + "', ulica='" + TextBox4.Text + "', policja='" + CheckBox1.IsChecked + "', samochod_zastepczy='" + CheckBox3.IsChecked + "', laweta='" + CheckBox5.IsChecked + "',numer_policji='" + TextBox.Text + "' WHERE id_zgloszenia LIKE '%" + clientID + "%' "; 


                //Open connection
                if (MainWindow.connect.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query;
                    //Assign the connection using Connection
                    cmd.Connection = MainWindow.connect.connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    MainWindow.connect.CloseConnection();
                }
            }

            //RegistrationForm registrationform = new RegistrationForm();
            //registrationform.date = Convert.ToInt32(TextBox1.Text);
            registrationform.countryName = TextBox2.Text;
            registrationform.cityName = TextBox3.Text;
            registrationform.streetName = TextBox4.Text;

            if (CheckBox1.IsChecked == true)
            {
                CheckBox2.IsEnabled = false;
                registrationform.haveThePoliceBeenThere = true;
                registrationform.policeNumberOfAccident = Convert.ToInt16(TextBox5.Text);
            }
            else
            {
                CheckBox2.IsEnabled = true;
                registrationform.haveThePoliceBeenThere = false;
                TextBox5.IsEnabled = false;
            }


            if (CheckBox3.IsChecked == true)
            {
                CheckBox4.IsEnabled = false;
                registrationform.isCarriageNeeded = true;

            }
            else
            {
                CheckBox4.IsEnabled = true;
                registrationform.isCarriageNeeded = false;

            }



            if (CheckBox5.IsChecked == true)
            {
                CheckBox6.IsEnabled = false;
                registrationform.isReplacementCarNeeded = true;

            }
            else
            {
                CheckBox6.IsEnabled = true;
                registrationform.isReplacementCarNeeded = false;

            }

            this.Close();
            MessageBox.Show("Poprawnie zmieniono zgloszenie!");


        }
    }
}
