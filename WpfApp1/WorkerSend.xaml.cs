﻿using MySql.Data.MySqlClient;
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
    /// Interaction logic for WorkerSend.xaml
    /// </summary>
    public partial class WorkerSend : Window
    {
        string IDofClient = WorkerWindow.clientID;
        string IDofClientForm = WorkerSendChooseForm.clientFormID;
        public WorkerSend()
        {
            InitializeComponent();
            string name, surname, personalID, date, country, city, street, police, numberPolice, replacementCar, carriage, status;
            string query = "SELECT ID, imie, nazwisko, pesel  FROM  klienci WHERE ID LIKE '%" + IDofClient + "%'";
           // string query2 = "SELECT data_zgloszenia, status_zgloszenia, kraj, miasto, ulica, policja, samochod_zastepczy, laweta, numer_policji FROM zgloszenie_szkody_samochodowej WHERE id_klienta LIKE '%" + IDofClient + "%'";
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
                    //textBox5.Text = dataReader2["data_zgloszenia"] + "";
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

        private void button_Click(object sender, RoutedEventArgs e)
        {
            string status = "zatwierdzony";
            string query3= "UPDATE zgloszenie_szkody_samochodowej SET status_zgloszenia = 'zatwierdzone' WHERE id_zgloszenia = '" + IDofClientForm + "'";
            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query3;
                cmd.Connection = MainWindow.connect.connection;
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }

            MessageBox.Show("To zgłoszenie zostało pomyślnie przyjęte");
            this.Close();
        }

        private void button_Copy_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("To zgłoszenie zostało anulowane");
            this.Close();
        }
    }
}
