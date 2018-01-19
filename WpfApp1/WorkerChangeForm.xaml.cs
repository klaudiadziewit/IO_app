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
    /// Logika interakcji dla klasy WorkerChangeForm.xaml
    /// </summary>
    public partial class WorkerChangeForm : Window
    {

        public static string IDofClient = WorkerWindow.clientID;
        public static string IDofClientForm = WorkerChange.clientFormID;
        RegistrationForm registrationform = new RegistrationForm();
        Client client = new Client();

        public WorkerChangeForm()
        {
            InitializeComponent();
            string query = "SELECT ID, imie, nazwisko, pesel  FROM  klienci WHERE ID LIKE '%" + IDofClient + "%'";
            if (MainWindow.connect.OpenConnection() == true)
            {
                //Create Command
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                //Create a data reader and Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                //Read the data and store them in the list
                while (dataReader.Read())
                {
                    textBox1.Text = dataReader["imie"] + "";
                    textBox2.Text = dataReader["nazwisko"] + "";
                    textBox3.Text = dataReader["ID"] + "";
                    textBox4.Text = dataReader["pesel"] + "";


                    // textBox1.Text =  dataReader["nazwisko"] + "";
                    //  dataReader["ID"] + ""
                }
                //close Data Reader
                dataReader.Close();


                string query2 = "SELECT data_zgloszenia, status_zgloszenia, kraj, miasto, ulica, policja, samochod_zastepczy, laweta, numer_policji FROM zgloszenie_szkody_samochodowej WHERE id_klienta LIKE '%" + IDofClient + "%' AND id_zgloszenia LIKE '%" + IDofClientForm + "%'";
                MySqlCommand cmd2 = new MySqlCommand(query2, MainWindow.connect.connection);
                MySqlDataReader dataReader2 = cmd2.ExecuteReader();
                while (dataReader2.Read())
                {
                    textBox5.Text = dataReader2["data_zgloszenia"] + "";
                    textBox6.Text = dataReader2["kraj"] + "";
                    textBox7.Text = dataReader2["miasto"] + "";
                    textBox8.Text = dataReader2["ulica"] + "";
                    textBox9.Text = dataReader2["policja"] + "";
                    textBox10.Text = dataReader2["numer_policji"] + "";
                    textBox11.Text = dataReader2["samochod_zastepczy"] + "";
                    textBox12.Text = dataReader2["laweta"] + "";
                    textBox13.Text = dataReader2["status_zgloszenia"] + "";

                    // textBox1.Text =  dataReader["nazwisko"] + "";
                    //  dataReader["ID"] + ""
                }
                //close Data Reader
                dataReader2.Close();

                MainWindow.connect.CloseConnection();
            }
            else
            {
            } 
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {


            int counter = 0;
            if (textBox1.Text == "") counter++;
            else if (textBox2.Text == "") counter++;
            else if (textBox3.Text == "") counter++;
            else if (textBox4.Text == "") counter++;
            else if (textBox5.Text == "") counter++;
            else if (textBox6.Text == "") counter++;
            else if (textBox7.Text == "") counter++;
            else if (textBox8.Text == "") counter++;
            else if (textBox9.Text == "") counter++;
            else if (textBox10.Text == "") counter++;
            else if (textBox11.Text == "") counter++;
            else if (textBox12.Text == "") counter++;
            else if (textBox13.Text == "") counter++;
            else if (textBox1.Text == "") counter++;
            if (counter == 0)
            {


                string query3 = "UPDATE zgloszenie_szkody_samochodowej SET data_zgloszenia='" + textBox5.Text + "', kraj='" + textBox6.Text + "', miasto='" + textBox7.Text + "', ulica='" + textBox8.Text + "', policja='" + textBox9.Text + "', samochod_zastepczy='" + textBox11.Text + "', laweta='" + textBox12.Text + "',numer_policji='" + textBox10.Text + "' WHERE id_zgloszenia LIKE '%" + IDofClientForm + "%' ";


                //Open connection
                if (MainWindow.connect.OpenConnection() == true)
                {
                    //create mysql command
                    MySqlCommand cmd = new MySqlCommand();
                    //Assign the query using CommandText
                    cmd.CommandText = query3;
                    //Assign the connection using Connection
                    cmd.Connection = MainWindow.connect.connection;

                    //Execute query
                    cmd.ExecuteNonQuery();

                    //close connection
                    MainWindow.connect.CloseConnection();
                }


         

                //registrationform.date = Convert.ToInt32(textBox5.Text);
                registrationform.countryName = textBox6.Text;
                registrationform.cityName = textBox7.Text;
                registrationform.streetName = textBox8.Text;
                registrationform.haveThePoliceBeenThere = Convert.ToBoolean(textBox9.Text);
                registrationform.policeNumberOfAccident = Convert.ToInt32(textBox10.Text);
                //registrationform.isReplacementCarNeeded =textBox11.Text = false;
                registrationform.isCarriageNeeded = Convert.ToBoolean(textBox12.Text);

                MessageBox.Show("Pomyślnie zmieniono zgłoszenie");
                this.Close();
            }
            else
                MessageBox.Show("Nie udało się zmienić zgłoszenia. Wypełnij ponownie wszystkie pola");
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WorkerChange workerChange = new WorkerChange();
            workerChange.Show();
            this.Close();
        }
    }
}
