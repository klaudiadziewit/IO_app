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
    /// Interaction logic for ClientChange.xaml
    /// </summary>
    public partial class ClientChange : Window
    {
        public static string id_zgl;
        public ClientChange()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
           
           //id_zgl = (textBox.Text);
            ClientChangeForm.clientID = textBox.Text;
            ClientChangeForm clientChangeForm = new ClientChangeForm();
            clientChangeForm.Show();
            this.Close();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
