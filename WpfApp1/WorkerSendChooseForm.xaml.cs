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
    /// Logika interakcji dla klasy WorkerSendChooseForm.xaml
    /// </summary>
    public partial class WorkerSendChooseForm : Window
    {
        public static string clientFormID;
        public static string IDofClient = WorkerWindow.clientID;
        public static string status = "zatwierdzone";
        public static string query = $"SELECT id_zgloszenia FROM zgloszenie_szkody_samochodowej WHERE id_klienta = '{IDofClient}' AND status_zgloszenia != '{status}'";

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

    public WorkerSendChooseForm()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            var dane = ExecuteQuery(query, "id_zgloszenia");
            textBox2.Text = dane;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clientFormID = textBox1.Text;
            if (true)
            {
                WorkerSend workerSend = new WorkerSend();
                workerSend.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Nie ma takiego zgłoszenia. Proszę wpisać poprawny numer");
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            WorkerWindow workerWindow = new WorkerWindow();
            workerWindow.Show();
            this.Close();
        }
    }
}
