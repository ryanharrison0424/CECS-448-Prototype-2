using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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

namespace CECS448.Prototype2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString;
            SqlConnection cnn;
            connectionString = @"Data Source = DESKTOP-VJ5Q3QK\SQLEXPRESS; Initial Catalog = 448AppDatabase; Integrated Security = True";
            cnn = new SqlConnection(connectionString);
            cnn.Open();

            string sql;
            SqlCommand command;
            SqlDataReader reader;
            int count;

            sql = "Select MAX(acctNumber) from UserInfo";
            command = new SqlCommand(sql, cnn);
            reader = command.ExecuteReader();
            reader.Read();
            count = reader.GetInt32(0);
    
            Button b = sender as Button;

            if (b.Equals(LogIn))
            {
                var logIn = new LogIn(cnn, count);
                logIn.Show();
                this.Close();
            }
            else
            {
                var signUp = new SignUp(cnn, count);
                signUp.Show();
                this.Close();
            }

         
        }
    }
}
