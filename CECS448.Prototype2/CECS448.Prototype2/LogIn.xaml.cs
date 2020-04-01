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
using System.Data.SqlClient;
using System.Data;

namespace CECS448.Prototype2
{
    /// <summary>
    /// Interaction logic for LogIn.xaml
    /// </summary>
    public partial class LogIn : Window
    {
        private SqlConnection cnn;
        private int number;
        public LogIn(SqlConnection cnn, int number)
        {
            InitializeComponent();
            this.cnn = cnn;
            this.number = number;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button b = sender as Button;

            if (b.Equals(Account))
            {
                string mEmail = email.Text;
                string mPassword = password.Password.ToString();

                SqlCommand command;
                SqlDataReader reader;
                string sql;
                int count;

                sql = "Select Count(*) from UserInfo where Email = '" + mEmail + "' AND Password = '" + mPassword + "'";
                command = new SqlCommand(sql, cnn);
                reader = command.ExecuteReader();
                reader.Read();
                count = reader.GetInt32(0);
                
                if(count == 1)
                {
                    var account = new Account(cnn);
                    account.Show();
                    this.Close();
                }
                else
                {
                    email.Clear();
                    password.Clear();
                    MessageBox.Show("The email and/or password entered was incorrect. Please try again.");
                }

            }
            else
            {
                var signUp = new SignUp(cnn, number);
                signUp.Show();
                this.Close();
            }
        
        }
    }
}
