using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
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

namespace CECS448.Prototype2
{
    /// <summary>
    /// Interaction logic for Account.xaml
    /// </summary>
    public partial class Account : Window
    {
        private SqlConnection cnn;
        public Account(SqlConnection cnn)
        {
            InitializeComponent();
            this.cnn = cnn;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {

            Button b = sender as Button;

            if(b.Equals(statistics))
            {
                var statistics = new Statistics(cnn);
                statistics.Show();
                this.Close();
            }
            else
            {
                var add = new Add(cnn);
                add.Show();
                this.Close();
            }
        }
    }
}
    


