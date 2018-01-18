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
    /// Logika interakcji dla klasy ClientSend.xaml
    /// </summary>
    public partial class ClientSend : Window
    {
        RegistrationForm registrationform = new RegistrationForm();
        public ClientSend()
        {
            InitializeComponent();
            button.IsEnabled = false;
            ComboBox1.IsEnabled = false;
            textBox.IsEnabled = false;

           
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_1(object sender, RoutedEventArgs e)
        {

        }

        private void CheckBox_Checked_2(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                TextBox6.Text = "Niepoprawnie uzupełniono";

            }

            else
            {
                TextBox6.Text = "Poprawnie uzupełniono";
                button.IsEnabled = true;
                ComboBox1.IsEnabled = true;
                textBox.IsEnabled = true;
            }

            //RegistrationForm registrationform = new RegistrationForm();
           registrationform.date= Convert.ToInt32( TextBox1.Text);
           registrationform.countryName = TextBox2.Text;
           registrationform.cityName = TextBox3.Text;
           registrationform.streetName = TextBox4.Text;

            if(CheckBox1.IsChecked==true)
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
                registrationform.isCarriageNeeded = true;

            }
            else
            {
                CheckBox6.IsEnabled = true;
                registrationform.isCarriageNeeded = false;

            }
           
     


        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            
            
                if (ComboBox1.Text == "OC")
                {
                   // OC oc = new OC();
                    //oc.OCinsuranceAmount = Convert.ToInt16(textBox.Text);
                }
                else if (ComboBox1.Text == "AC")
                {
                   // AC ac = new AC();
                   // ac.ACinsuranceAmount = Convert.ToInt16(textBox.Text);
                }
                else if (ComboBox1.Text == "Kradzież")
                {
                   // Theft theft = new Theft();
                   // theft.theftinsuranceAmount = Convert.ToInt16(textBox.Text);
                }

            if (ComboBox1.Text != "")
            {
                if (textBox.Text == "")
                {
                    MessageBox.Show("Uzupełnij kwotę ubezpieczenia!");
                }
                else
                {
                    /*
                    //string query = "INSERT INTO zgloszenie_szkody_samochodowej (data_zgloszenia, kraj, miasto, ulica, policja, samochod_zastepczy, laweta, numer_policji, id_klienta) VALUES("+registrationform.date+ ", " + registrationform.countryName + ", " + registrationform.cityName + " , " + registrationform.streetName + ", " + registrationform.haveThePoliceBeenThere + "," + registrationform.date + "" + registrationform.isReplacementCarNeeded + " , " + registrationform.isCarriageNeeded + ", " + registrationform.policeNumberOfAccident + " ," + ClientWindow.client_id + " )";
                    //string query = "INSERT INTO zgloszenie_szkody_samochodowej (data_zgloszenia, kraj, miasto, ulica, policja, samochod_zastepczy, laweta, numer_policji, id_klienta) VALUES('" + registrationform.date + "', '" + registrationform.countryName + "', '" + registrationform.cityName + "' ,'" + registrationform.streetName + "','" + registrationform.haveThePoliceBeenThere +"','" + registrationform.date + "','" + registrationform.isReplacementCarNeeded + "' ,'" + registrationform.isCarriageNeeded +"','" + registrationform.policeNumberOfAccident + "','" + ClientWindow.client_id + "' )";

                    string query = "insert into zgloszenie_szkody_samochodowej (data_zgloszenia, kraj, miasto, ulica) VALUES('222', ' Polska', 'Krakow')";
                    //open connection
                    //open connection
                    if (MainWindow.connect.OpenConnection() == true)
                    {
                        //create command and assign the query and connection from the constructor
                        MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);

                        MySqlDataReader MyReadaer2;
                       // MainWindow.connect.OpenConnection();
                        MyReadaer2 = cmd.ExecuteReader();

                        while (MyReadaer2.Read())
                        {

                        }
                        MainWindow.connect.CloseConnection();


                        //Execute command
                      //  cmd.ExecuteNonQuery();

                        //close connection
                        MainWindow.connect.CloseConnection();
                    }
                    
                 //   DBConnect wyslij = new DBConnect();
                 //   wyslij.Insert(query);


    */
                }
            }
            else
            {
                MessageBox.Show("Wybierz typ ubezpiecznie!");
            }
            
        }
    }
}
