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
       
     public static DBConnect connect = new DBConnect();

        public MainWindow()
        {
            InitializeComponent();
          
    }


     

        private void Button_Click(object sender, RoutedEventArgs e)
        {
              
        //  connection = new MySqlConnection(connectionString);

        //  DBConnect connect = new DBConnect();
        //this.connection.CloseConnection();
        // DBConnect connect = new DBConnect();
        connect.OpenConnection();
          //  kupal.Select();
            //kupal.Count();
            connect.CloseConnection();

            startingWindow startingWindow = new startingWindow();
            startingWindow.Show();
            this.Close();
        }
    }
}
