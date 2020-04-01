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
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Window
    {
        private SqlConnection cnn;
        private int count;
        public SignUp(SqlConnection cnn, int count)
        {
            InitializeComponent();
            this.cnn = cnn;
            this.count = count;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string fname = firstName.Text;
            string lname = lastName.Text;
            string uname = username.Text;
            string mEmail = email.Text;
            string mPassword = password.Password.ToString();

            string sql;
            SqlCommand command;
            SqlDataAdapter adapter = new SqlDataAdapter();
          
            sql = "Insert into UserInfo ([First Name], [Last Name], [Username], [Email], [Password], [acctNumber]) values('" + fname + "', '" + lname + "', '" + uname
                + "', '" + mEmail + "', '" + mPassword +  "', '" + count++ + "')";
            command = new SqlCommand(sql, cnn);

            adapter.InsertCommand = new SqlCommand(sql, cnn);
            adapter.InsertCommand.ExecuteNonQuery();

            var account = new Account(cnn);
            account.Show();
            this.Close();
        }
    }
}
