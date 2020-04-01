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
using System.Windows.Shapes;

namespace CECS448.Prototype2
{
    /// <summary>
    /// Interaction logic for Add.xaml
    /// </summary>
    public partial class Add : Window
    {
        private SqlConnection cnn;
 
        public Add(SqlConnection cnn)
        {
            InitializeComponent();
            this.cnn = cnn;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button b = sender as Button;
            var statistics = new Statistics(cnn);

            if (b.Equals(Facebook))
            {
                System.Diagnostics.Process.Start("https://www.facebook.com/");
                statistics.Show();
                this.Close();
            }
            else if (b.Equals(Snapchat))
            {
                System.Diagnostics.Process.Start("https://www.snapchat.com/");
                statistics.Show();
                this.Close();
            }
            else if (b.Equals(Instagram))
            {
                System.Diagnostics.Process.Start("https://www.instagram.com/");
                statistics.Show();
                this.Close();
            }
            else if (b.Equals(Linkedin))
            {
                System.Diagnostics.Process.Start("https://www.linkedin.com/");
                statistics.Show();
                this.Close();
            }
            else
            {
                System.Diagnostics.Process.Start("https://twitter.com/explore");
                statistics.Show();
                this.Close();
            }
        }
    }
}
