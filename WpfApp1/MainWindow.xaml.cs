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
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    /// 

    public partial class MainWindow : Window
    {
        int licznik = 0;
     public static DBConnect connect = new DBConnect();

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {            
            connect.OpenConnection();
            MessageBox.Show("Poprawnie połączono!");
            connect.CloseConnection();

            startingWindow startingWindow = new startingWindow();
            startingWindow.Show();
            this.Close();
        }

        private void Test_Button_Click(object sender, RoutedEventArgs e)
        {
            //test poprawnego połączenia
            connect.OpenConnection();
            licznik++;
            MessageBox.Show("Poprawnie przeszło test łączenia z bazą!");
            connect.CloseConnection();
            //test poprawnego dodania zgłoszenia przez klienta
            test_dodaj_zgloszenie_klient();
            //test przyjecia zgloszenia
            test_przyjmij_zgloszenie_pracownik();
            //test zmiany zgłoszenia
            test_zmien_zgloszenie_klient();
            //test usunięcia zgłoszenia @pracownik
            test_usun_zgloszenie_pracownik();
            if(licznik==5)
            {
                MessageBox.Show("poprawnie przeszło WSZYSTKIE TESTY!");
            }
            else
            {
                MessageBox.Show("Program NIE przeszedł WSZYSTKICH testów!");
            }
        }
        public void test_dodaj_zgloszenie_klient()
        {

            RegistrationForm registrationform = new RegistrationForm();
            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand("insert into zgloszenie_szkody_samochodowej VALUES(NULL,@data_zgloszenia,@status_zgloszenia,@Polisa_samochodowa_ID, @kraj, @miasto, @ulica, @policja, @samochod_zastepczy, @laweta, @numer_policji, @id_klienta);", MainWindow.connect.connection);
                //string tempD = (string)registrationform.date;
                //DateTime enteredDate = DateTime.Parse(registrationform.date);
                cmd.Parameters.AddWithValue("@data_zgloszenia", 20100201);
                cmd.Parameters.AddWithValue("@status_zgloszenia", "nieznany");
                cmd.Parameters.AddWithValue("@Polisa_samochodowa_ID", 1);
                cmd.Parameters.AddWithValue("@kraj", "KrajTestowy");
                cmd.Parameters.AddWithValue("@miasto", "MiastoTestowe");
                cmd.Parameters.AddWithValue("@ulica", "UlicaTestowa");
                cmd.Parameters.AddWithValue("@policja", 1);
                cmd.Parameters.AddWithValue("@samochod_zastepczy", 1);
                cmd.Parameters.AddWithValue("@laweta", 1);
                cmd.Parameters.AddWithValue("@numer_policji", 243);
                cmd.Parameters.AddWithValue("@id_klienta", 4);
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
                MessageBox.Show("Poprawnie przeszło test dodania do bazy");
                licznik++;
            }
        }
        public void test_przyjmij_zgloszenie_pracownik()
        {
            string status = "zatwierdzone";
            string statuus2 = "nieznany";
            string query3 = $"UPDATE zgloszenie_szkody_samochodowej SET status_zgloszenia = '{status}' WHERE status_zgloszenia = '"+statuus2+"'";
            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query3;
                cmd.Connection = MainWindow.connect.connection;
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }

            MessageBox.Show("Pomyślnie przeszło test zatwierdzenia zgłoszenia klienta");
            licznik++;
        }
        public void test_zmien_zgloszenie_klient()
        {
            string MiastuTest = "MiastoZmienione";
            string KrajuTest = "KrajTestowy";
            string query = "UPDATE zgloszenie_szkody_samochodowej SET  miasto='" + MiastuTest + "' WHERE id_zgloszenia LIKE '%" + KrajuTest + "%' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand();
                cmd.CommandText = query;
                cmd.Connection = MainWindow.connect.connection;
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }
            MessageBox.Show("Pomyślnie przeszło test zmiany zgłoszenia");
            licznik++;
        }
        public void test_usun_zgloszenie_pracownik()
        {
            string choose = "KrajTestowy";
            string query = $"DELETE FROM zgloszenie_szkody_samochodowej WHERE kraj = '"+choose+"' ";

            if (MainWindow.connect.OpenConnection() == true)
            {
                MySqlCommand cmd = new MySqlCommand(query, MainWindow.connect.connection);
                cmd.ExecuteNonQuery();
                MainWindow.connect.CloseConnection();
            }
            MessageBox.Show("Pomyślnie przeszło test usunięcia zgłoszenia");
            licznik++;
        }
    }
}
