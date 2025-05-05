using MySqlConnector;
using Mysqlx.Notice;
using System;
using System.Collections.Generic;
using System.Diagnostics;
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


namespace student
{
    public partial class MainWindow
    {
        public void subAttendDisplay()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string task = "SELECT * FROM subattendance";
            MySqlCommand command = new MySqlCommand(task, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int d = 1;
            while (reader.Read())
            {
                string x = "SA" + d;
                Label textBlock = (Label)this.FindName(x);
                d++;
                textBlock.Content = reader[1].ToString();
            }
            reader.Close();
            connection.Close();
        }

        public void labAttendDisplay()
        {
            MySqlConnection connection = new MySqlConnection(connectionString);
            connection.Open();
            string task = "SELECT * FROM labattendance";
            MySqlCommand command = new MySqlCommand(task, connection);
            MySqlDataReader reader = command.ExecuteReader();
            int d = 1;
            while (reader.Read())
            {
                string x = "LA" + d;
                Label textBlock = (Label)this.FindName(x);
                d++;
                textBlock.Content = reader[1].ToString();
            }
            reader.Close();
            connection.Close();
        }
    }
}
